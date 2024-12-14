using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grille.VPaint.WinForms;

public partial class Vec2Control : UserControl
{
    private string _text;

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get => _text;
        [MemberNotNull(nameof(_text))]
        set
        {
            _text = value;
            LabelX.Text = $"{_text} X";
            LabelY.Text = $"{_text} Y";
        }
    }

    bool _updateValue = false;

    private Vector2 _value;

    public Vector2 Value { get=> _value; 
        set
        {
            _updateValue = true;
            _value = value;
            NumericUpDownX.Value = (decimal)value.X;
            NumericUpDownY.Value = (decimal)value.Y;
            _updateValue = false;
        }
    }

    public event EventHandler? ValueChanged;

    public Vec2Control()
    {
        InitializeComponent();

        Text = "Position";
    }

    private void NumericUpDownX_ValueChanged(object sender, EventArgs e)
    {
        if (_updateValue) return;
        _value.X = (float)NumericUpDownX.Value;
        ValueChanged?.Invoke(this, EventArgs.Empty);
    }

    private void NumericUpDownY_ValueChanged(object sender, EventArgs e)
    {
        if (_updateValue) return;
        _value.Y = (float)NumericUpDownY.Value;
        ValueChanged?.Invoke(this, EventArgs.Empty);
    }
}
