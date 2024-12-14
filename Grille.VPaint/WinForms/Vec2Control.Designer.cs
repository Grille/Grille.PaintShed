namespace Grille.VPaint.WinForms
{
    partial class Vec2Control
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
            LabelX = new Label();
            LabelY = new Label();
            NumericUpDownY = new NumericUpDown();
            NumericUpDownX = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownX).BeginInit();
            SuspendLayout();
            // 
            // LabelX
            // 
            LabelX.Location = new Point(3, 3);
            LabelX.Margin = new Padding(3);
            LabelX.Name = "LabelX";
            LabelX.Size = new Size(90, 23);
            LabelX.TabIndex = 26;
            LabelX.Text = "Position X";
            LabelX.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelY
            // 
            LabelY.Location = new Point(3, 32);
            LabelY.Margin = new Padding(3);
            LabelY.Name = "LabelY";
            LabelY.Size = new Size(90, 23);
            LabelY.TabIndex = 25;
            LabelY.Text = "Position Y";
            LabelY.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NumericUpDownY
            // 
            NumericUpDownY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericUpDownY.DecimalPlaces = 2;
            NumericUpDownY.Location = new Point(99, 32);
            NumericUpDownY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericUpDownY.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            NumericUpDownY.Name = "NumericUpDownY";
            NumericUpDownY.Size = new Size(314, 23);
            NumericUpDownY.TabIndex = 24;
            NumericUpDownY.ValueChanged += NumericUpDownY_ValueChanged;
            // 
            // NumericUpDownX
            // 
            NumericUpDownX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumericUpDownX.DecimalPlaces = 2;
            NumericUpDownX.Location = new Point(99, 3);
            NumericUpDownX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericUpDownX.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            NumericUpDownX.Name = "NumericUpDownX";
            NumericUpDownX.Size = new Size(314, 23);
            NumericUpDownX.TabIndex = 23;
            NumericUpDownX.ValueChanged += NumericUpDownX_ValueChanged;
            // 
            // Vec2Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LabelX);
            Controls.Add(LabelY);
            Controls.Add(NumericUpDownY);
            Controls.Add(NumericUpDownX);
            Margin = new Padding(0);
            Name = "Vec2Control";
            Size = new Size(416, 58);
            ((System.ComponentModel.ISupportInitialize)NumericUpDownY).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownX).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Label LabelX;
        public Label LabelY;
        public NumericUpDown NumericUpDownY;
        public NumericUpDown NumericUpDownX;
    }
}
