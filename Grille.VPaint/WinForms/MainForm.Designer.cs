using Grille.VPaint.WinForms;

namespace Grille.VPaint
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            importToolStripMenuItem = new ToolStripMenuItem();
            paintShedBaseToolStripMenuItem = new ToolStripMenuItem();
            paintShedMaskToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            trainzFolderToolStripMenuItem = new ToolStripMenuItem();
            folderToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            quitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            displayToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            splitContainer1 = new SplitContainer();
            TabControl = new TabControl();
            tabPage1 = new TabPage();
            PaintPanel = new PaintPanel();
            tabPage2 = new TabPage();
            DecalPanel = new DecalPanel();
            View = new WorldView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            setColorToolStripMenuItem = new ToolStripMenuItem();
            replaceColorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            pickPaintColorToolStripMenuItem = new ToolStripMenuItem();
            pickFinalColorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            addDecalToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            removeDecalToolStripMenuItem = new ToolStripMenuItem();
            copyDecalToolStripMenuItem = new ToolStripMenuItem();
            pasteDecalToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            TabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, displayToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripSeparator3, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator4, importToolStripMenuItem, exportToolStripMenuItem, toolStripSeparator5, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(186, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(183, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(186, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(186, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(186, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(183, 6);
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { paintShedBaseToolStripMenuItem, paintShedMaskToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(186, 22);
            importToolStripMenuItem.Text = "Import";
            // 
            // paintShedBaseToolStripMenuItem
            // 
            paintShedBaseToolStripMenuItem.Name = "paintShedBaseToolStripMenuItem";
            paintShedBaseToolStripMenuItem.Size = new Size(160, 22);
            paintShedBaseToolStripMenuItem.Text = "PaintShed-Base";
            paintShedBaseToolStripMenuItem.Click += paintShedBaseToolStripMenuItem_Click;
            // 
            // paintShedMaskToolStripMenuItem
            // 
            paintShedMaskToolStripMenuItem.Name = "paintShedMaskToolStripMenuItem";
            paintShedMaskToolStripMenuItem.Size = new Size(160, 22);
            paintShedMaskToolStripMenuItem.Text = "PaintShed-Mask";
            paintShedMaskToolStripMenuItem.Click += paintShedMaskToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { trainzFolderToolStripMenuItem, folderToolStripMenuItem, imageToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportToolStripMenuItem.Size = new Size(186, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // trainzFolderToolStripMenuItem
            // 
            trainzFolderToolStripMenuItem.Enabled = false;
            trainzFolderToolStripMenuItem.Name = "trainzFolderToolStripMenuItem";
            trainzFolderToolStripMenuItem.Size = new Size(180, 22);
            trainzFolderToolStripMenuItem.Text = "Trainz Folder <WIP>";
            // 
            // folderToolStripMenuItem
            // 
            folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            folderToolStripMenuItem.Size = new Size(180, 22);
            folderToolStripMenuItem.Text = "PaintShed Folder";
            folderToolStripMenuItem.Click += folderToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(180, 22);
            imageToolStripMenuItem.Text = "Main Image";
            imageToolStripMenuItem.Click += imageToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(183, 6);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(186, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator7, copyToolStripMenuItem, pasteToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(184, 22);
            undoToolStripMenuItem.Text = "Undo <WIP>";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(184, 22);
            redoToolStripMenuItem.Text = "Redo <WIP>";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(181, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(184, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyDecalToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(184, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteDecalToolStripMenuItem_Click;
            // 
            // displayToolStripMenuItem
            // 
            displayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            displayToolStripMenuItem.Size = new Size(57, 20);
            displayToolStripMenuItem.Text = "Display";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.Items.AddRange(new object[] { "Default", "Base", "Mask", "Paint" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(View);
            splitContainer1.Size = new Size(800, 426);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 1;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabPage1);
            TabControl.Controls.Add(tabPage2);
            TabControl.Dock = DockStyle.Fill;
            TabControl.Location = new Point(0, 0);
            TabControl.Margin = new Padding(0);
            TabControl.Name = "TabControl";
            TabControl.Padding = new Point(0, 0);
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(266, 426);
            TabControl.TabIndex = 0;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(PaintPanel);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(258, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Paint";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // PaintPanel
            // 
            PaintPanel.Color = Color.Red;
            PaintPanel.Dock = DockStyle.Fill;
            PaintPanel.Location = new Point(0, 0);
            PaintPanel.Margin = new Padding(0);
            PaintPanel.Name = "PaintPanel";
            PaintPanel.Size = new Size(258, 398);
            PaintPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(DecalPanel);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(258, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Decals";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // DecalPanel
            // 
            DecalPanel.AutoScroll = true;
            DecalPanel.Decal = null;
            DecalPanel.Dock = DockStyle.Fill;
            DecalPanel.Location = new Point(0, 0);
            DecalPanel.Margin = new Padding(0);
            DecalPanel.Name = "DecalPanel";
            DecalPanel.ShapeColor = Color.Gray;
            DecalPanel.Size = new Size(258, 398);
            DecalPanel.TabIndex = 0;
            DecalPanel.TextColor = Color.Gray;
            // 
            // View
            // 
            View.AllowDrop = true;
            View.BackColor = Color.Navy;
            View.ContextMenuStrip = contextMenuStrip1;
            View.Dock = DockStyle.Fill;
            View.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            View.Location = new Point(0, 0);
            View.Margin = new Padding(0);
            View.Name = "View";
            View.RenderMode = RenderMode.None;
            View.Size = new Size(530, 426);
            View.TabIndex = 0;
            View.Text = "view1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { setColorToolStripMenuItem, replaceColorToolStripMenuItem, toolStripSeparator1, pickPaintColorToolStripMenuItem, pickFinalColorToolStripMenuItem, toolStripSeparator2, addDecalToolStripMenuItem, toolStripSeparator6, removeDecalToolStripMenuItem, copyDecalToolStripMenuItem, pasteDecalToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(159, 198);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // setColorToolStripMenuItem
            // 
            setColorToolStripMenuItem.Name = "setColorToolStripMenuItem";
            setColorToolStripMenuItem.Size = new Size(158, 22);
            setColorToolStripMenuItem.Text = "Set Color";
            setColorToolStripMenuItem.Click += setColorToolStripMenuItem_Click;
            // 
            // replaceColorToolStripMenuItem
            // 
            replaceColorToolStripMenuItem.Name = "replaceColorToolStripMenuItem";
            replaceColorToolStripMenuItem.Size = new Size(158, 22);
            replaceColorToolStripMenuItem.Text = "Replace Color";
            replaceColorToolStripMenuItem.Click += replaceColorToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(155, 6);
            // 
            // pickPaintColorToolStripMenuItem
            // 
            pickPaintColorToolStripMenuItem.Name = "pickPaintColorToolStripMenuItem";
            pickPaintColorToolStripMenuItem.Size = new Size(158, 22);
            pickPaintColorToolStripMenuItem.Text = "Pick Paint Color";
            pickPaintColorToolStripMenuItem.Click += pickPaintColorToolStripMenuItem_Click;
            // 
            // pickFinalColorToolStripMenuItem
            // 
            pickFinalColorToolStripMenuItem.Name = "pickFinalColorToolStripMenuItem";
            pickFinalColorToolStripMenuItem.Size = new Size(158, 22);
            pickFinalColorToolStripMenuItem.Text = "Pick Final Color";
            pickFinalColorToolStripMenuItem.Click += pickFinalColorToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(155, 6);
            // 
            // addDecalToolStripMenuItem
            // 
            addDecalToolStripMenuItem.Name = "addDecalToolStripMenuItem";
            addDecalToolStripMenuItem.Size = new Size(158, 22);
            addDecalToolStripMenuItem.Text = "Add Decal";
            addDecalToolStripMenuItem.Click += addDecalToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(155, 6);
            // 
            // removeDecalToolStripMenuItem
            // 
            removeDecalToolStripMenuItem.Name = "removeDecalToolStripMenuItem";
            removeDecalToolStripMenuItem.Size = new Size(158, 22);
            removeDecalToolStripMenuItem.Text = "Remove Decal";
            removeDecalToolStripMenuItem.Click += removeDecalToolStripMenuItem_Click;
            // 
            // copyDecalToolStripMenuItem
            // 
            copyDecalToolStripMenuItem.Name = "copyDecalToolStripMenuItem";
            copyDecalToolStripMenuItem.Size = new Size(158, 22);
            copyDecalToolStripMenuItem.Text = "Copy Decal";
            copyDecalToolStripMenuItem.Click += copyDecalToolStripMenuItem_Click;
            // 
            // pasteDecalToolStripMenuItem
            // 
            pasteDecalToolStripMenuItem.Name = "pasteDecalToolStripMenuItem";
            pasteDecalToolStripMenuItem.Size = new Size(158, 22);
            pasteDecalToolStripMenuItem.Text = "Paste Decal";
            pasteDecalToolStripMenuItem.Click += pasteDecalToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Grille.PaintShed ";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            TabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem newToolStripMenuItem;
        public Grille.VPaint.WinForms.WorldView View;
        private TabPage tabPage1;
        private TabPage tabPage2;
        public PaintPanel PaintPanel;
        public DecalPanel DecalPanel;
        public TabControl TabControl;
        private DecalPanel decalPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem setColorToolStripMenuItem;
        private ToolStripMenuItem pickPaintColorToolStripMenuItem;
        private ToolStripMenuItem pickFinalColorToolStripMenuItem;
        private ToolStripMenuItem replaceColorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem addDecalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem quitToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem removeDecalToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem paintShedBaseToolStripMenuItem;
        private ToolStripMenuItem paintShedMaskToolStripMenuItem;
        private ToolStripMenuItem folderToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStripMenuItem copyDecalToolStripMenuItem;
        private ToolStripMenuItem pasteDecalToolStripMenuItem;
        private ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem trainzFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
    }
}
