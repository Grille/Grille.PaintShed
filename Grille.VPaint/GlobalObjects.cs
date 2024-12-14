using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Grille.VPaint.WinForms;

namespace Grille.VPaint;

internal static class GlobalObjects
{
    public static MainForm MainForm;

    public static DecalPanel DecalPanel => MainForm.DecalPanel;

    public static PaintPanel PaintPanel => MainForm.PaintPanel;

    public static WorldView WorldView => MainForm.View;

    public static World World => WorldView.World;

    static GlobalObjects()
    {
        Unsafe.SkipInit(out MainForm);
    }

    public static void InavlidateWorld()
    {
        PaintPanel.PullData();
        WorldView.Invalidate();
    }
}
