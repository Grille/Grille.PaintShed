using System.Diagnostics;
using System.Reflection;

using Grille.IO;
using Grille.VPaint.IO;
using Grille.VPaint.WinForms;

namespace Grille.VPaint;



public partial class MainForm : Form
{
    string FileName = Path.GetFullPath("Skin.dat");

    static byte[]? clipboard;

    public MainForm()
    {
        InitializeComponent();

        toolStripComboBox1.SelectedIndex = 0;

        Icon = Properties.Resources.Icon;

        Text = $"Grille.VPaint v0.1";

        GlobalObjects.MainForm = this;
    }

    public ToolMode GetToolMode()
    {
        if (TabControl.SelectedIndex == 0)
        {
            if (PaintPanel.RadioButtonSC.Checked)
            {
                return ToolMode.SetColor;
            }
            else if (PaintPanel.radioButtonRC.Checked)
            {
                return ToolMode.SetColor;
            }
            else if (PaintPanel.RadioButtonPPC.Checked)
            {
                return ToolMode.PickPaintColor;
            }
            else if (PaintPanel.RadioButtonPFC.Checked)
            {
                return ToolMode.PickFinalColor;
            }
        }
        else if (TabControl.SelectedIndex == 1)
        {
            return ToolMode.EditDecals;
        }
        return ToolMode.None;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        ExceptionBox.Show(this, () =>
        {
            if (File.Exists(FileName))
            {
                BinarySerializer.Load(FileName, View.World);
                GlobalObjects.InavlidateWorld();
            }
        });
    }

    private void setColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.TriggerMouseDown(ToolMode.SetColor);
    }

    private void pickPaintColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.TriggerMouseDown(ToolMode.PickPaintColor);
    }

    private void pickFinalColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.TriggerMouseDown(ToolMode.PickFinalColor);
    }

    private void replaceColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.TriggerMouseDown(ToolMode.ReplaceColor);
    }

    private void addDecalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.TriggerMouseDown(ToolMode.AddDecal);
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        saveFileDialog1.InitialDirectory = Path.GetDirectoryName(FileName);
        saveFileDialog1.FileName = FileName;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FileName = Path.GetFullPath(saveFileDialog1.FileName);
            BinarySerializer.Save(FileName, View.World, true);
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        BinarySerializer.Save(FileName, View.World, true);
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        openFileDialog1.InitialDirectory = Path.GetDirectoryName(FileName);
        openFileDialog1.FileName = FileName;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FileName = Path.GetFullPath(openFileDialog1.FileName);
            BinarySerializer.Load(FileName, View.World);
            GlobalObjects.InavlidateWorld();
        }
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.World.Undo();
        GlobalObjects.InavlidateWorld();
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        View.World.Redo();
        GlobalObjects.InavlidateWorld();
    }

    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var decal = View.World.SelectedDecal;
        bool decalSelected = decal != null;
        removeDecalToolStripMenuItem.Enabled = decalSelected;
        copyDecalToolStripMenuItem.Enabled = decalSelected;

    }

    private void removeDecalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var decal = View.World.SelectedDecal;
        bool decalSelected = decal != null;

        if (decalSelected)
        {
            View.World.DecalList.Remove(decal!);
            View.World.UpdateDecalBuffers();
            View.World.SelectedDecal = null;
            GlobalObjects.InavlidateWorld();
        }
    }

    private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        View.Invalidate();
    }

    private void paintShedBaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            ExceptionBox.Show(this, () =>
            {
                TrainzPaintShed.LoadBase(folderBrowserDialog1.SelectedPath, View.World);
                GlobalObjects.InavlidateWorld();
            });
        }
    }

    private void paintShedMaskToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            ExceptionBox.Show(this, () =>
            {
                TrainzPaintShed.LoadMask(folderBrowserDialog1.SelectedPath, View.World);
                GlobalObjects.InavlidateWorld();
            });
        }
    }

    private void imageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ExceptionBox.Show(this, () =>
        {
            var image = View.World.GetCanvasByName("Main")!.GetImage();
            SaveBitmapDialog.Show(this, image);
        });
    }

    private void folderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            ExceptionBox.Show(this, () =>
            {
                TrainzPaintShed.Export(folderBrowserDialog1.SelectedPath, View.World);
            });
        }
    }

    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var mode = (RenderMode)(toolStripComboBox1.SelectedIndex + 1);
        View.RenderMode = mode;
    }

    private void copyDecalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ExceptionBox.Show(this, () =>
        {
            var decal = View.World.SelectedDecal;
            if (decal == null) throw new ArgumentException("No decal selected.");

            using var stream = new MemoryStream();
            using var bw = new BinaryViewWriter(stream);
            BinarySerializer.WriteDecal(bw, decal);

            clipboard = stream.ToArray();
        });
    }

    private void pasteDecalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ExceptionBox.Show(this, () =>
        {
            using var stream = new MemoryStream(clipboard!);
            using var br = new BinaryViewReader(stream);
            var decal = BinarySerializer.ReadDecal(br);
            decal.Location = View.World.LastWorldPos;
            decal.UpdateBounds();

            View.World.DecalList.Add(decal);
            View.World.UpdateDecalBuffers();
            GlobalObjects.InavlidateWorld();
        });
    }
}
