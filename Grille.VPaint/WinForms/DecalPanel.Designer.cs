namespace Grille.VPaint.WinForms
{
    partial class DecalPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDownX = new NumericUpDown();
            numericUpDownY = new NumericUpDown();
            colorDialog1 = new ColorDialog();
            fontDialog1 = new FontDialog();
            buttonEF = new Button();
            buttonLI = new Button();
            openFileDialog1 = new OpenFileDialog();
            buttonCI = new Button();
            label1 = new Label();
            numericUpDownTOX = new NumericUpDown();
            label2 = new Label();
            numericUpDownTOY = new NumericUpDown();
            numericUpDownTSX = new NumericUpDown();
            numericUpDownTSY = new NumericUpDown();
            numericUpDownTA = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBoxCM = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            comboBoxSM = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            colorControlBC = new ColorControl();
            colorControlTC = new ColorControl();
            textControl1 = new TextControl();
            label12 = new Label();
            label13 = new Label();
            numericUpDown1 = new NumericUpDown();
            vec2Control1 = new Vec2Control();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTOX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTOY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTSX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTSY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownX
            // 
            numericUpDownX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownX.DecimalPlaces = 2;
            numericUpDownX.Location = new Point(99, 32);
            numericUpDownX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownX.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(294, 23);
            numericUpDownX.TabIndex = 2;
            numericUpDownX.ValueChanged += numericUpDownX_ValueChanged;
            // 
            // numericUpDownY
            // 
            numericUpDownY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownY.DecimalPlaces = 2;
            numericUpDownY.Location = new Point(99, 61);
            numericUpDownY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownY.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(294, 23);
            numericUpDownY.TabIndex = 3;
            numericUpDownY.ValueChanged += numericUpDownY_ValueChanged;
            // 
            // buttonEF
            // 
            buttonEF.Location = new Point(3, 380);
            buttonEF.Name = "buttonEF";
            buttonEF.Size = new Size(90, 23);
            buttonEF.TabIndex = 7;
            buttonEF.Text = "Edit Font";
            buttonEF.UseVisualStyleBackColor = true;
            buttonEF.Click += buttonEF_Click;
            // 
            // buttonLI
            // 
            buttonLI.Location = new Point(3, 90);
            buttonLI.Name = "buttonLI";
            buttonLI.Size = new Size(90, 23);
            buttonLI.TabIndex = 8;
            buttonLI.Text = "Load Image";
            buttonLI.UseVisualStyleBackColor = true;
            buttonLI.Click += buttonLI_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonCI
            // 
            buttonCI.Location = new Point(99, 90);
            buttonCI.Name = "buttonCI";
            buttonCI.Size = new Size(90, 23);
            buttonCI.TabIndex = 9;
            buttonCI.Text = "Clear Image";
            buttonCI.UseVisualStyleBackColor = true;
            buttonCI.Click += buttonCI_Click;
            // 
            // label1
            // 
            label1.Location = new Point(3, 438);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 5;
            label1.Text = "Offset X";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTOX
            // 
            numericUpDownTOX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTOX.DecimalPlaces = 2;
            numericUpDownTOX.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownTOX.Location = new Point(99, 438);
            numericUpDownTOX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownTOX.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownTOX.Name = "numericUpDownTOX";
            numericUpDownTOX.Size = new Size(294, 23);
            numericUpDownTOX.TabIndex = 4;
            numericUpDownTOX.ValueChanged += numericUpDownTOX_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = SystemColors.InactiveCaption;
            label2.Location = new Point(3, 409);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(390, 23);
            label2.TabIndex = 10;
            label2.Text = "Transforms";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTOY
            // 
            numericUpDownTOY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTOY.DecimalPlaces = 2;
            numericUpDownTOY.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownTOY.Location = new Point(99, 467);
            numericUpDownTOY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownTOY.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownTOY.Name = "numericUpDownTOY";
            numericUpDownTOY.Size = new Size(294, 23);
            numericUpDownTOY.TabIndex = 11;
            numericUpDownTOY.ValueChanged += numericUpDownTOY_ValueChanged;
            // 
            // numericUpDownTSX
            // 
            numericUpDownTSX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTSX.DecimalPlaces = 2;
            numericUpDownTSX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownTSX.Location = new Point(99, 496);
            numericUpDownTSX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownTSX.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownTSX.Name = "numericUpDownTSX";
            numericUpDownTSX.Size = new Size(294, 23);
            numericUpDownTSX.TabIndex = 12;
            numericUpDownTSX.ValueChanged += numericUpDownTSX_ValueChanged;
            // 
            // numericUpDownTSY
            // 
            numericUpDownTSY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTSY.DecimalPlaces = 2;
            numericUpDownTSY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownTSY.Location = new Point(99, 525);
            numericUpDownTSY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownTSY.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownTSY.Name = "numericUpDownTSY";
            numericUpDownTSY.Size = new Size(294, 23);
            numericUpDownTSY.TabIndex = 13;
            numericUpDownTSY.ValueChanged += numericUpDownTSY_ValueChanged;
            // 
            // numericUpDownTA
            // 
            numericUpDownTA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTA.DecimalPlaces = 2;
            numericUpDownTA.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownTA.Location = new Point(99, 554);
            numericUpDownTA.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownTA.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDownTA.Name = "numericUpDownTA";
            numericUpDownTA.Size = new Size(294, 23);
            numericUpDownTA.TabIndex = 14;
            numericUpDownTA.ValueChanged += numericUpDownTA_ValueChanged;
            // 
            // label3
            // 
            label3.Location = new Point(3, 467);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 15;
            label3.Text = "Offset Y";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(3, 496);
            label4.Margin = new Padding(3);
            label4.Name = "label4";
            label4.Size = new Size(90, 23);
            label4.TabIndex = 16;
            label4.Text = "Scale X";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(3, 525);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(90, 23);
            label5.TabIndex = 17;
            label5.Text = "Scale Y";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Location = new Point(3, 554);
            label6.Margin = new Padding(3);
            label6.Name = "label6";
            label6.Size = new Size(90, 23);
            label6.TabIndex = 18;
            label6.Text = "Angle";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(3, 119);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(90, 23);
            label7.TabIndex = 19;
            label7.Text = "Copy Mode";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxCM
            // 
            comboBoxCM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCM.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCM.FormattingEnabled = true;
            comboBoxCM.Items.AddRange(new object[] { "None", "Same Position", "Opposite Position" });
            comboBoxCM.Location = new Point(99, 119);
            comboBoxCM.Name = "comboBoxCM";
            comboBoxCM.Size = new Size(294, 23);
            comboBoxCM.TabIndex = 20;
            comboBoxCM.SelectedIndexChanged += comboBoxCM_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.Location = new Point(3, 61);
            label8.Margin = new Padding(3);
            label8.Name = "label8";
            label8.Size = new Size(90, 23);
            label8.TabIndex = 21;
            label8.Text = "Position Y";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Location = new Point(3, 32);
            label9.Margin = new Padding(3);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 22;
            label9.Text = "Position X";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxSM
            // 
            comboBoxSM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSM.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSM.FormattingEnabled = true;
            comboBoxSM.Items.AddRange(new object[] { "None", "Rectangle", "Elipse" });
            comboBoxSM.Location = new Point(99, 177);
            comboBoxSM.Name = "comboBoxSM";
            comboBoxSM.Size = new Size(294, 23);
            comboBoxSM.TabIndex = 24;
            comboBoxSM.SelectedIndexChanged += comboBoxSM_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.Location = new Point(3, 177);
            label10.Margin = new Padding(3);
            label10.Name = "label10";
            label10.Size = new Size(90, 23);
            label10.TabIndex = 23;
            label10.Text = "Shape Mode";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.BackColor = SystemColors.InactiveCaption;
            label11.Location = new Point(3, 293);
            label11.Margin = new Padding(3);
            label11.Name = "label11";
            label11.Size = new Size(390, 23);
            label11.TabIndex = 25;
            label11.Text = "Text";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // colorControlBC
            // 
            colorControlBC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            colorControlBC.Color = Color.Empty;
            colorControlBC.Location = new Point(0, 203);
            colorControlBC.Margin = new Padding(0);
            colorControlBC.Name = "colorControlBC";
            colorControlBC.Size = new Size(396, 29);
            colorControlBC.TabIndex = 26;
            colorControlBC.ColorChanged += colorControlBC_ColorChanged;
            // 
            // colorControlTC
            // 
            colorControlTC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            colorControlTC.Color = Color.Empty;
            colorControlTC.Location = new Point(0, 348);
            colorControlTC.Margin = new Padding(0);
            colorControlTC.Name = "colorControlTC";
            colorControlTC.Size = new Size(396, 29);
            colorControlTC.TabIndex = 27;
            colorControlTC.ColorChanged += colorControlTC_ColorChanged;
            // 
            // textControl1
            // 
            textControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControl1.ButtonText = "Edit Text";
            textControl1.Location = new Point(0, 319);
            textControl1.Margin = new Padding(0);
            textControl1.Name = "textControl1";
            textControl1.Size = new Size(396, 29);
            textControl1.TabIndex = 28;
            textControl1.TextValueChanged += textBoxText_TextChanged;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.BackColor = SystemColors.InactiveCaption;
            label12.Location = new Point(3, 148);
            label12.Margin = new Padding(3);
            label12.Name = "label12";
            label12.Size = new Size(390, 23);
            label12.TabIndex = 29;
            label12.Text = "Shape";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Location = new Point(3, 3);
            label13.Margin = new Padding(3);
            label13.Name = "label13";
            label13.Size = new Size(90, 23);
            label13.TabIndex = 31;
            label13.Text = "Z Index";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.Location = new Point(99, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(294, 23);
            numericUpDown1.TabIndex = 30;
            // 
            // vec2Control1
            // 
            vec2Control1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            vec2Control1.Location = new Point(0, 232);
            vec2Control1.Margin = new Padding(0);
            vec2Control1.Name = "vec2Control1";
            vec2Control1.Size = new Size(396, 58);
            vec2Control1.TabIndex = 32;
            vec2Control1.Text = "Size";
            vec2Control1.ValueChanged += vec2Control1_ValueChanged;
            // 
            // DecalPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(vec2Control1);
            Controls.Add(label13);
            Controls.Add(numericUpDown1);
            Controls.Add(label12);
            Controls.Add(textControl1);
            Controls.Add(colorControlTC);
            Controls.Add(colorControlBC);
            Controls.Add(label11);
            Controls.Add(comboBoxSM);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBoxCM);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDownTA);
            Controls.Add(numericUpDownTSY);
            Controls.Add(numericUpDownTSX);
            Controls.Add(numericUpDownTOY);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownTOX);
            Controls.Add(buttonCI);
            Controls.Add(buttonLI);
            Controls.Add(buttonEF);
            Controls.Add(numericUpDownY);
            Controls.Add(numericUpDownX);
            Name = "DecalPanel";
            Size = new Size(396, 822);
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTOX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTOY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTSX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTSY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private ColorDialog colorDialog1;
        private FontDialog fontDialog1;
        private Button buttonEF;
        private Button buttonLI;
        private OpenFileDialog openFileDialog1;
        private Button buttonCI;
        private Label label1;
        private NumericUpDown numericUpDownTOX;
        private Label label2;
        private NumericUpDown numericUpDownTOY;
        private NumericUpDown numericUpDownTSX;
        private NumericUpDown numericUpDownTSY;
        private NumericUpDown numericUpDownTA;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxCM;
        private Label label8;
        private Label label9;
        private ComboBox comboBoxSM;
        private Label label10;
        private Label label11;
        private ColorControl colorControlBC;
        private ColorControl colorControlTC;
        private TextControl textControl1;
        private Label label12;
        private Label label13;
        private NumericUpDown numericUpDown1;
        private Vec2Control vec2Control1;
    }
}
