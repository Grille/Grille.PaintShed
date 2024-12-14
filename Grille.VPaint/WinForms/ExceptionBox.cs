using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.VPaint.WinForms;

public static class ExceptionBox
{
    public static DialogResult Show(IWin32Window owner, Exception exception)
    {
        return MessageBox.Show(owner, exception.Message, exception.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static DialogResult Show(IWin32Window owner, Action action)
    {
        try
        {
            action();
            return DialogResult.None;
        }
        catch (Exception ex)
        {
            return Show(owner, ex);
        }
    }
}
