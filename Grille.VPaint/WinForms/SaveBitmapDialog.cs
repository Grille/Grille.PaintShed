using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Grille.VPaint.IO;

namespace Grille.VPaint.WinForms;

public static class SaveBitmapDialog
{
    public static void Show(IWin32Window owner, Image image)
    {
        using var dialog = new SaveFileDialog()
        {
            Title = "Save Image",
            Filter = "Bitmap Image (*.bmp)|*.bmp",
            FilterIndex = 0,
            DefaultExt = "bmp",
            AddExtension = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ExceptionBox.Show(owner, () =>
            {
                BmpFile.Save(dialog.FileName, (Bitmap)image);
            });
        }

    }
}
