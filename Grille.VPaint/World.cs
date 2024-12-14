using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Grille.VPaint.IO;
using Grille.VPaint.UnsafeDrawing;

namespace Grille.VPaint;

public class World
{
    public Camera Camera { get; }
    public List<Decal> DecalList { get; }
    public List<Canvas> CanvasList { get; }

    public List<Projector> ProjectorsList { get; }

    public Color SelectedColor { get; set; }
    public Decal? SelectedDecal { get; set; }

    public Vector2 LastWorldPos;

    public Vector2 Delta { get; private set; }

    public TimeSpan DecalBufferUpdateTime { get; private set; }

    public event EventHandler? WorldChanged;

    private UndoRedoBuffer UndoRedoBuffer;

    public VirtualDirectory VirtualDirectory { get; set; }

    public WorldStrings Strings { get; }

    public World()
    {
        Camera = new()
        {
            Scale = 1,
        };
        DecalList = new();
        CanvasList = new();
        ProjectorsList = new();

        SelectedColor = Color.Red;

        UndoRedoBuffer = new();

        VirtualDirectory = new();
        Strings = new();
    }

    public void Backup()
    {
        UndoRedoBuffer.Backup(this);
    }

    public void Undo()
    {
        UndoRedoBuffer.Undo(this);

        
        Console.WriteLine("undo");
    }

    public void Redo()
    {
        UndoRedoBuffer.Redo(this);
    }

    void OnWorldChanged()
    {
        Backup();
        WorldChanged?.Invoke(this, EventArgs.Empty);
    }

    public void MouseLeftDown(ToolMode tool)
    {
        switch (tool)
        {
            case ToolMode.SetColor:
            case ToolMode.ReplaceColor:
            case ToolMode.PickPaintColor:
            case ToolMode.PickFinalColor:
            {
                var canvas = GetHooveredCanvas();
                if (canvas != null)
                {
                    MouseLeftDownColorAction(tool, canvas);
                }
                break;
            }
            case ToolMode.AddDecal:
            {
                var decal = new Decal();
                decal.Location = LastWorldPos;
                decal.Update();
                if (GlobalObjects.MainForm.TabControl.SelectedIndex == 1)
                {
                    SelectedDecal = decal;
                    GlobalObjects.DecalPanel.Decal = decal;
                }
                DecalList.Add(decal);
                UpdateDecalBuffers();
                OnWorldChanged();
                break;
            }
        }
    }

    public void MouseLeftDownColorAction(ToolMode tool, Canvas canvas)
    {
        var form = GlobalObjects.MainForm;

        var local = LastWorldPos - canvas.Position;

        switch (tool)
        {
            case ToolMode.SetColor:
            {
                var color = (Color)canvas.GetPickColor(local);
                //if (color.ToArgb() == Color.Black.ToArgb()) break;
                SetPaintByPick(color, form.PaintPanel.Color);
                OnWorldChanged();
                break;
            }
            case ToolMode.ReplaceColor:
            {
                var color = (Color)canvas.GetPaintColor(local);
                ReplacePaint(color, form.PaintPanel.Color);
                OnWorldChanged();
                break;
            }
            case ToolMode.PickPaintColor:
            {
                form.PaintPanel.Color = canvas.GetPaintColor(local);
                break;
            }
            case ToolMode.PickFinalColor:
            {
                form.PaintPanel.Color = canvas.GetFinalColor(local);
                break;
            }
        }
    }

    public void MouseMove(ToolMode tool, Vector2 position)
    {
        Delta = position - LastWorldPos;
        LastWorldPos = position;


    }

    public void MouseLeftUp(ToolMode toolMode)
    {

    }

    public void UpdateDecalBuffers()
    {
        var timestamp = DateTime.Now;

        foreach (var canvas in CanvasList)
        {
            canvas.BeginDecalProjection();
        }

        foreach (var decal in DecalList)
        {
            foreach (var canvas in CanvasList)
            {
                if (canvas.TryAddDecal(decal, out var location))
                {
                    canvas.AddDecal(decal, location);
                    if (canvas.Counterpart != null)
                    {
                        if (decal.CloneMode == CloneMode.SamePosition)
                        {
                            canvas.Counterpart.AddDecal(decal, location);
                        }
                        else if (decal.CloneMode == CloneMode.OppositePosition)
                        {
                            float oppositeX = canvas.Counterpart.Width - location.X;
                            var opposite = new Vector2(oppositeX, location.Y);
                            canvas.Counterpart.AddDecal(decal, opposite);
                        }
                    }
                }
            }
        }

        foreach (var projector in ProjectorsList)
        {
            projector.Target.AddProjectorAsDecal(projector);
        }

        foreach (var canvas in CanvasList)
        {
            canvas.EndDecalProjection();
        }

        DecalBufferUpdateTime = DateTime.Now - timestamp;
    }

    public Decal? GetHooveredDecal()
    {
        foreach (var decal in DecalList)
        {
            if (decal.Bounds.IsInside(LastWorldPos))
            {
                return decal;
            }
        }
        return null;
    }

    public void GetHooveredDecals(IList<Decal> list)
    {
        foreach (var decal in DecalList)
        {
            if (decal.Bounds.IsInside(LastWorldPos))
            {
                list.Add(decal);
            }
        }
    }

    public Canvas? GetHooveredCanvas()
    {
        foreach (var canvas in CanvasList)
        {
            if (canvas.Bounds.IsInside(LastWorldPos))
            {
                return canvas;
            }
        }
        return null;
    }

    public Canvas? GetCanvasByName(string name)
    {
        foreach (var canvas in CanvasList)
        {
            if (canvas.Name == name)
            {
                return canvas;
            }
        }
        return null;
    }

    public void SetPaintByPick(Color pick, Color color)
    {
        foreach (var canvas in CanvasList)
        {
            canvas.SetPaintByPick(pick, color);
        }
    }

    public void ReplacePaint(Color pick, Color color)
    {
        foreach (var canvas in CanvasList)
        {
            canvas.ReplacePaint(pick, color);
        }
    }

    public void Draw(Graphics g, Font font, RenderMode mode)
    {
        Rectangle DrawRect(float x, float y, float width, float height)
        {
            var drawpos = Camera.WorldToScreenSpace(new Vector2(x, y));
            return new Rectangle((int)drawpos.X, (int)drawpos.Y, (int)(width * Camera.Scale), (int)(height * Camera.Scale));
        }

        using var pen0 = new Pen(Color.Black, 1);
        using var pen1 = new Pen(Color.White, 1);
        using var pen2 = new Pen(Color.Lime, 1);
        using var pen3 = new Pen(Color.Magenta, 1);
        pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        pen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

        foreach (var canvas in CanvasList)
        {
            var drawrect = DrawRect(canvas.Left, canvas.Top, canvas.Width, canvas.Height);
            g.DrawImage(canvas.GetImage(mode), drawrect);
            g.DrawString($"{canvas.Name} <{canvas.Width},{canvas.Height}>", font, Brushes.White, drawrect);
        }

        if (GlobalObjects.MainForm.TabControl.SelectedIndex == 1)
        {
            foreach (var decal in DecalList)
            {
                var bounds = decal.Bounds;
                var drawrect = DrawRect(bounds.BeginX, bounds.BeginY, bounds.Width, bounds.Height);
                g.DrawRectangle(pen0, drawrect);
                g.DrawRectangle(pen1, drawrect);
            }

            foreach (var projector in ProjectorsList)
            {
                var bounds = projector.Bounds;
                var drawrect = DrawRect(bounds.BeginX, bounds.BeginY, bounds.Width, bounds.Height);
                g.DrawRectangle(pen0, drawrect);
                g.DrawRectangle(pen3, drawrect);
            }
        }

        if (SelectedDecal != null)
        {
            var bounds = SelectedDecal.Bounds;
            var drawrect = DrawRect(bounds.BeginX, bounds.BeginY, bounds.Width, bounds.Height);
            g.DrawRectangle(pen0, drawrect);
            g.DrawRectangle(pen2, drawrect);
        }
    }

    public void Clear()
    {
        DecalList.Clear(); 
        CanvasList.Clear();
        ProjectorsList.Clear();
    }
}
