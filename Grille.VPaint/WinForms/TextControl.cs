using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grille.VPaint.WinForms;

public partial class TextControl : UserControl
{
    EditTextDialog _dialog;

    public override string Text { 
        get => TextBox.Text; 
        set => TextBox.Text = value; 
    }

    public string ButtonText { get => Button.Text; set => Button.Text = value; }

    public event EventHandler? TextValueChanged;

    public TextControl()
    {
        InitializeComponent();

        _dialog = new EditTextDialog();
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextValueChanged?.Invoke(this, e);
    }

    private void Button_Click(object sender, EventArgs e)
    {
        _dialog.TextBox.Text = Text;
        if (_dialog.ShowDialog() == DialogResult.OK)
        {
            Text = _dialog.TextBox.Text;
            TextValueChanged?.Invoke(this, e);
        }
    }
}
