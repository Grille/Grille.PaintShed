using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Grille.VPaint;

public partial class ColorControl : UserControl
{
    public event EventHandler? ColorChanged;

    bool _edit = false;

    Color _color;

    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            updateTBColor();
            updateTBText();
        }
    }

    public ColorControl()
    {
        InitializeComponent();
    }

    private void buttonSC_Click(object sender, EventArgs e)
    {
        ColorDialog.Color = Color;
        if (ColorDialog.ShowDialog() == DialogResult.OK)
        {
            if (Color.ToArgb() == ColorDialog.Color.ToArgb())
            {
                return;
            }
            Color = ColorDialog.Color;
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    void updateTBColor()
    {
        textBox1.BackColor = Color.FromArgb(255, _color);
        textBox1.ForeColor = (_color.R > 128 || _color.G > 128 || _color.B > 128) ? Color.Black : Color.White;
    }

    void updateTBText()
    {
        _edit = true;
        textBox1.Text = $"{_color.ToArgb() & 0x00ffffff:X6}";
        _edit = false;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (_edit)
        {
            return;
        }
        if (!int.TryParse(textBox1.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int argb))
        {
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Red;
            return;
        }
        if (Color.ToArgb() == argb)
        {
            return;
        }
        _color = Color.FromArgb(255, Color.FromArgb(argb));
        updateTBColor();
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }
}
