using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grille.VPaint.WinForms;

public static class SaveImageDialog
{
    public static void Show(IWin32Window owner, Image image)
    {
        using var dialog = new SaveFileDialog()
        {
            Title = "Save Image",
            Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap Image (*.bmp)|*.bmp|All Files (*.*)|*.*",
            FilterIndex = 3,
            DefaultExt = "bmp",
            AddExtension = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ExceptionBox.Show(owner, () =>
            {
                var format = GetFormat(dialog.FileName);
                image.Save(dialog.FileName, format);
            });
        }

    }

    public static ImageFormat GetFormat(string fileName) => Path.GetExtension(fileName).ToLower() switch
    {
        ".bmp" => ImageFormat.Bmp,
        _ => throw new ArgumentOutOfRangeException(),
    };

}
