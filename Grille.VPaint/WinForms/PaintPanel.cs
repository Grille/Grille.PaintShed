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

public partial class PaintPanel : UserControl
{
    public Color Color
    {
        get => colorControl1.Color;
        set => colorControl1.Color = value;
    }

    public PaintPanel()
    {
        InitializeComponent();

        Color = Color.Blue;
    }

    public void PullData()
    {
        textControlAlias.Text = GlobalObjects.World.Strings.Alias.Value;
        textControlKuid.Text = GlobalObjects.World.Strings.Kuid.Value;
        textControlUsername.Text = GlobalObjects.World.Strings.Username.Value;
        textControlDesc.Text = GlobalObjects.World.Strings.Description.Value;
        textControlCompany.Text = GlobalObjects.World.Strings.Company.Value;
        textControlOrigin.Text = GlobalObjects.World.Strings.Origin.Value;
        textControlEra.Text = GlobalObjects.World.Strings.Era.Value;
    }

    private void textControlKuid_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Kuid.Value = textControlKuid.Text;
    }

    private void textControlUsername_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Username.Value = textControlUsername.Text;
    }

    private void textControlDesc_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Description.Value = textControlDesc.Text;
    }

    private void textControlOrigin_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Origin.Value = textControlOrigin.Text;
    }

    private void textControlEra_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Era.Value = textControlEra.Text;
    }

    private void textControlCompany_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Company.Value = textControlCompany.Text;
    }

    private void textControlAlias_TextValueChanged(object sender, EventArgs e)
    {
        GlobalObjects.World.Strings.Alias.Value = textControlAlias.Text;
    }
}
