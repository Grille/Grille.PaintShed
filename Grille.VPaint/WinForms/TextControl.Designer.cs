namespace Grille.VPaint.WinForms
{
    partial class TextControl
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
            TextBox = new TextBox();
            Button = new Button();
            SuspendLayout();
            // 
            // TextBox
            // 
            TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox.Location = new Point(99, 3);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(432, 23);
            TextBox.TabIndex = 5;
            TextBox.TextChanged += TextBox_TextChanged;
            // 
            // Button
            // 
            Button.Location = new Point(3, 3);
            Button.Name = "Button";
            Button.Size = new Size(90, 23);
            Button.TabIndex = 4;
            Button.Text = "Edit Text";
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // TextControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TextBox);
            Controls.Add(Button);
            Margin = new Padding(0);
            Name = "TextControl";
            Size = new Size(534, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox TextBox;
        public Button Button;
    }
}
