namespace Grille.VPaint.WinForms
{
    partial class PaintPanel
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
            RadioButtonSC = new RadioButton();
            RadioButtonPPC = new RadioButton();
            colorDialog1 = new ColorDialog();
            RadioButtonPFC = new RadioButton();
            radioButtonRC = new RadioButton();
            colorControl1 = new ColorControl();
            label11 = new Label();
            textControlKuid = new TextControl();
            textControlUsername = new TextControl();
            textControlDesc = new TextControl();
            textControlOrigin = new TextControl();
            textControlEra = new TextControl();
            textControlCompany = new TextControl();
            textControlAlias = new TextControl();
            SuspendLayout();
            // 
            // RadioButtonSC
            // 
            RadioButtonSC.AutoSize = true;
            RadioButtonSC.Checked = true;
            RadioButtonSC.Location = new Point(3, 32);
            RadioButtonSC.Name = "RadioButtonSC";
            RadioButtonSC.Size = new Size(73, 19);
            RadioButtonSC.TabIndex = 2;
            RadioButtonSC.TabStop = true;
            RadioButtonSC.Text = "Set Color";
            RadioButtonSC.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPPC
            // 
            RadioButtonPPC.AutoSize = true;
            RadioButtonPPC.Location = new Point(3, 82);
            RadioButtonPPC.Name = "RadioButtonPPC";
            RadioButtonPPC.Size = new Size(109, 19);
            RadioButtonPPC.TabIndex = 3;
            RadioButtonPPC.Text = "Pick Paint Color";
            RadioButtonPPC.UseVisualStyleBackColor = true;
            // 
            // colorDialog1
            // 
            colorDialog1.Color = Color.Red;
            colorDialog1.FullOpen = true;
            // 
            // RadioButtonPFC
            // 
            RadioButtonPFC.AutoSize = true;
            RadioButtonPFC.Location = new Point(3, 107);
            RadioButtonPFC.Name = "RadioButtonPFC";
            RadioButtonPFC.Size = new Size(107, 19);
            RadioButtonPFC.TabIndex = 6;
            RadioButtonPFC.Text = "Pick Final Color";
            RadioButtonPFC.UseVisualStyleBackColor = true;
            // 
            // radioButtonRC
            // 
            radioButtonRC.AutoSize = true;
            radioButtonRC.Location = new Point(3, 57);
            radioButtonRC.Name = "radioButtonRC";
            radioButtonRC.Size = new Size(98, 19);
            radioButtonRC.TabIndex = 7;
            radioButtonRC.Text = "Replace Color";
            radioButtonRC.UseVisualStyleBackColor = true;
            // 
            // colorControl1
            // 
            colorControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            colorControl1.Color = Color.Empty;
            colorControl1.Location = new Point(0, 0);
            colorControl1.Margin = new Padding(0);
            colorControl1.Name = "colorControl1";
            colorControl1.Size = new Size(288, 29);
            colorControl1.TabIndex = 8;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.BackColor = SystemColors.InactiveCaption;
            label11.Location = new Point(3, 132);
            label11.Margin = new Padding(3);
            label11.Name = "label11";
            label11.Size = new Size(282, 23);
            label11.TabIndex = 26;
            label11.Text = "Meta";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textControlKuid
            // 
            textControlKuid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlKuid.ButtonText = "Kuid";
            textControlKuid.Location = new Point(0, 187);
            textControlKuid.Margin = new Padding(0);
            textControlKuid.Name = "textControlKuid";
            textControlKuid.Size = new Size(288, 29);
            textControlKuid.TabIndex = 27;
            textControlKuid.TextValueChanged += textControlKuid_TextValueChanged;
            // 
            // textControlUsername
            // 
            textControlUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlUsername.ButtonText = "Username";
            textControlUsername.Location = new Point(0, 216);
            textControlUsername.Margin = new Padding(0);
            textControlUsername.Name = "textControlUsername";
            textControlUsername.Size = new Size(288, 29);
            textControlUsername.TabIndex = 28;
            textControlUsername.TextValueChanged += textControlUsername_TextValueChanged;
            // 
            // textControlDesc
            // 
            textControlDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlDesc.ButtonText = "Description";
            textControlDesc.Location = new Point(0, 245);
            textControlDesc.Margin = new Padding(0);
            textControlDesc.Name = "textControlDesc";
            textControlDesc.Size = new Size(288, 29);
            textControlDesc.TabIndex = 29;
            textControlDesc.TextValueChanged += textControlDesc_TextValueChanged;
            // 
            // textControlOrigin
            // 
            textControlOrigin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlOrigin.ButtonText = "Origin";
            textControlOrigin.Location = new Point(0, 303);
            textControlOrigin.Margin = new Padding(0);
            textControlOrigin.Name = "textControlOrigin";
            textControlOrigin.Size = new Size(288, 29);
            textControlOrigin.TabIndex = 30;
            textControlOrigin.TextValueChanged += textControlOrigin_TextValueChanged;
            // 
            // textControlEra
            // 
            textControlEra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlEra.ButtonText = "Era";
            textControlEra.Location = new Point(0, 332);
            textControlEra.Margin = new Padding(0);
            textControlEra.Name = "textControlEra";
            textControlEra.Size = new Size(288, 29);
            textControlEra.TabIndex = 31;
            textControlEra.TextValueChanged += textControlEra_TextValueChanged;
            // 
            // textControlCompany
            // 
            textControlCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlCompany.ButtonText = "Company";
            textControlCompany.Location = new Point(0, 274);
            textControlCompany.Margin = new Padding(0);
            textControlCompany.Name = "textControlCompany";
            textControlCompany.Size = new Size(288, 29);
            textControlCompany.TabIndex = 32;
            textControlCompany.TextValueChanged += textControlCompany_TextValueChanged;
            // 
            // textControlAlias
            // 
            textControlAlias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textControlAlias.ButtonText = "Alias";
            textControlAlias.Location = new Point(0, 158);
            textControlAlias.Margin = new Padding(0);
            textControlAlias.Name = "textControlAlias";
            textControlAlias.Size = new Size(288, 29);
            textControlAlias.TabIndex = 33;
            textControlAlias.TextValueChanged += textControlAlias_TextValueChanged;
            // 
            // PaintPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textControlAlias);
            Controls.Add(textControlCompany);
            Controls.Add(textControlEra);
            Controls.Add(textControlOrigin);
            Controls.Add(textControlDesc);
            Controls.Add(textControlUsername);
            Controls.Add(textControlKuid);
            Controls.Add(label11);
            Controls.Add(colorControl1);
            Controls.Add(radioButtonRC);
            Controls.Add(RadioButtonPFC);
            Controls.Add(RadioButtonPPC);
            Controls.Add(RadioButtonSC);
            Name = "PaintPanel";
            Size = new Size(288, 456);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColorDialog colorDialog1;
        public RadioButton RadioButtonSC;
        public RadioButton RadioButtonPPC;
        public RadioButton RadioButtonPFC;
        public RadioButton radioButtonRC;
        private ColorControl colorControl1;
        private Label label11;
        private TextControl textControlKuid;
        private TextControl textControlUsername;
        private TextControl textControlDesc;
        private TextControl textControlOrigin;
        private TextControl textControlEra;
        private TextControl textControlCompany;
        private TextControl textControlAlias;
    }
}
