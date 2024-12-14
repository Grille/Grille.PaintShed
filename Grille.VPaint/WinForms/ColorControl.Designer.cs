namespace Grille.VPaint
{
    partial class ColorControl
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
            buttonSC = new Button();
            ColorDialog = new ColorDialog();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // buttonSC
            // 
            buttonSC.Location = new Point(3, 3);
            buttonSC.Name = "buttonSC";
            buttonSC.Size = new Size(90, 23);
            buttonSC.TabIndex = 2;
            buttonSC.Text = "Select Color";
            buttonSC.UseVisualStyleBackColor = true;
            buttonSC.Click += buttonSC_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(99, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // ColorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(buttonSC);
            Margin = new Padding(0);
            Name = "ColorControl";
            Size = new Size(336, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonSC;
        private TextBox textBox1;
        public ColorDialog ColorDialog;
    }
}
