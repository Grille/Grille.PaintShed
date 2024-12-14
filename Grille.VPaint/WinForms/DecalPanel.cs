using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Grille.VPaint.WinForms
{
    public partial class DecalPanel : UserControl
    {
        public Color TextColor
        {
            get => _decal == null ? Color.Gray : _decal.TextColor;
            set
            {
                if (_decal == null)
                {
                    return;
                }

                _decal.TextColor = value;
                colorControlTC.Color = value;
            }
        }

        public Color ShapeColor
        {
            get => _decal == null ? Color.Gray : _decal.ShapeColor;
            set
            {
                if (_decal == null)
                {
                    return;
                }

                _decal.ShapeColor = value;
                colorControlBC.Color = value;
            }
        }

        private Decal? _decal;

        public Decal? Decal
        {
            get => _decal;
            set
            {
                _decal = value;
                UpdateDecalInfo();
            }
        }

        public DecalPanel()
        {
            InitializeComponent();

            SetEnabled(false);

            comboBoxSM.SelectedIndex = 0;
            comboBoxCM.SelectedIndex = 0;
        }

        public void UpdateDecalInfo()
        {
            if (Decal == null)
            {
                SetEnabled(false);
            }
            else
            {
                SetEnabled(true);
                numericUpDownX.Value = (decimal)Decal.Location.X;
                numericUpDownY.Value = (decimal)Decal.Location.Y;

                TextColor = Decal.TextColor;
                ShapeColor = Decal.ShapeColor;

                vec2Control1.Value = Decal.ShapeSize;

                textControl1.Text = Decal.Text!;

                comboBoxCM.SelectedIndex = (int)Decal.CloneMode;
                comboBoxSM.SelectedIndex = (int)Decal.Shape;

                numericUpDownTA.Value = (decimal)Decal.Angle;

                numericUpDownTOX.Value = (decimal)Decal.Offset.X;
                numericUpDownTOY.Value = (decimal)Decal.Offset.Y;
                numericUpDownTSX.Value = (decimal)Decal.Scale.X;
                numericUpDownTSY.Value = (decimal)Decal.Scale.Y;
            }
        }

        void SetEnabled(bool value)
        {
            numericUpDownX.Enabled = value;
            numericUpDownY.Enabled = value;

            colorControlBC.Enabled = value;
            colorControlTC.Enabled = value;

            buttonEF.Enabled = value;

            textControl1.Enabled = value;

            comboBoxSM.Enabled = value;
            comboBoxCM.Enabled = value;

            buttonLI.Enabled = value;
            buttonCI.Enabled = value;

            numericUpDownTA.Enabled = value;
            numericUpDownTOX.Enabled = value;
            numericUpDownTOY.Enabled = value;
            numericUpDownTSX.Enabled = value;
            numericUpDownTSY.Enabled = value;

            vec2Control1.Enabled = value;
        }

        bool GetNumber(NumericUpDown box, out float value)
        {
            value = (float)box.Value;
            return true;
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            if (GetNumber(numericUpDownX, out var value))
            {
                Decal.Location = new Vector2(value, Decal.Location.Y);
                Decal.UpdateBounds();
                UpdateView();
            }
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            if (GetNumber(numericUpDownY, out var value))
            {
                Decal.Location = new Vector2(Decal.Location.X, value);
                Decal.UpdateBounds();
                UpdateView();
            }
        }

        void UpdateView()
        {
            GlobalObjects.World.UpdateDecalBuffers();
            GlobalObjects.WorldView.Invalidate();
        }

        private void textBoxText_TextChanged(object? sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Text = textControl1.Text;
            Decal.Update();
            UpdateView();
        }

        private void buttonEF_Click(object sender, EventArgs e)
        {
            if (Decal == null) return;
            fontDialog1.Font = Decal.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Decal.Font = fontDialog1.Font;
                Decal.Update();
                UpdateView();
            }
        }

        private void buttonLI_Click(object sender, EventArgs e)
        {
            if (Decal == null) return;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using var stream = File.OpenRead(openFileDialog1.FileName);
                    var bitmap = new Bitmap(stream);
                    Decal.Image = bitmap;
                    Decal.Update();
                    UpdateView();
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(this, ex);
            }
        }

        private void buttonCI_Click(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Image = null;
            Decal.Update();
            UpdateView();
        }

        private void numericUpDownTOX_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Offset.X = (float)numericUpDownTOX.Value;
            Decal.Update();
            UpdateView();
        }

        private void numericUpDownTOY_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Offset.Y = (float)numericUpDownTOY.Value;
            Decal.Update();
            UpdateView();
        }

        private void numericUpDownTSX_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Scale.X = (float)numericUpDownTSX.Value;
            Decal.Update();
            UpdateView();
        }

        private void numericUpDownTSY_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Scale.Y = (float)numericUpDownTSY.Value;
            Decal.Update();
            UpdateView();
        }

        private void numericUpDownTA_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Angle = (float)numericUpDownTA.Value;
            Decal.Update();
            UpdateView();
        }

        private void comboBoxCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.CloneMode = (CloneMode)comboBoxCM.SelectedIndex;
            UpdateView();
        }

        private void comboBoxSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.Shape = (DecalShape)comboBoxSM.SelectedIndex;
            Decal.Update();
            UpdateView();
        }

        private void colorControlBC_ColorChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.ShapeColor = colorControlBC.Color;
            Decal.Update();
            UpdateView();
        }

        private void colorControlTC_ColorChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.TextColor = colorControlTC.Color;
            Decal.Update();
            UpdateView();
        }

        private void vec2Control1_ValueChanged(object sender, EventArgs e)
        {
            if (Decal == null) return;
            Decal.ShapeSize = vec2Control1.Value;
            Decal.Update();
            UpdateView();
        }
    }
}
