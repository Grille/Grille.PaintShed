using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using System.Drawing.Drawing2D;

namespace Grille.VPaint.WinForms;

public class WorldView : Control
{
    public MainForm Form => ((MainForm)FindForm()!);

    public Camera Camera => World.Camera;

    public World World { get; }

    public event EventHandler? WorldChanged;

    private RenderMode _renderMode;

    public RenderMode RenderMode
    {
        get => _renderMode; 
        set
        {
            if (_renderMode != value)
            {
                _renderMode = value;
                Invalidate();
            }
        }
    }

    bool _enter = false;

    public WorldView()
    {
        _renderMode = RenderMode.None;
        DoubleBuffered = true;

        World = new World();

        World.WorldChanged += World_WorldChanged;
    }

    private void World_WorldChanged(object? sender, EventArgs e)
    {
        WorldChanged?.Invoke(this, e);
    }

    public void TriggerMouseDown(ToolMode tool)
    {
        World.MouseLeftDown(tool);

        Invalidate();
    }

    ToolMode ToolMode => Form.GetToolMode();

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        var tool = ToolMode;


        if (e.Button == MouseButtons.Left)
        {
            World.MouseLeftDown(tool);
            Invalidate();

            var selected = World.SelectedDecal;
            if (tool == ToolMode.EditDecals)
            {
                var list = new List<Decal>();
                World.GetHooveredDecals(list);
                if (list.Count == 1)
                {
                    World.SelectedDecal = list[0];
                }
                else if (list.Count > 1 && list[0] != World.SelectedDecal)
                {
                    World.SelectedDecal = list[0];
                }
                else if (list.Count > 1)
                {
                    World.SelectedDecal = list[1];
                }
                else
                {
                    World.SelectedDecal = null;
                }
            }
            else
            {
                World.SelectedDecal = null;
            }

            if (World.SelectedDecal != selected)
            {
                Form.DecalPanel.Decal = World.SelectedDecal;
                Invalidate();
            }
        }
    }

    protected override void OnDragEnter(DragEventArgs drgevent)
    {
        base.OnDragEnter(drgevent);

        drgevent.Effect = DragDropEffects.Copy;
    }

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
        base.OnDragDrop(drgevent);

        try
        {
            var path = ((string[])drgevent.Data!.GetData(DataFormats.FileDrop, false)!)[0];
            var bitmap = new Bitmap(path);
            var decal = new Decal();
            var local = PointToClient(new Point(drgevent.X, drgevent.Y));
            decal.Image = bitmap;
            decal.Text = null;
            decal.Location = Camera.ScreenToWorldSpace(new(local.X, local.Y));
            decal.Update();
            World.DecalList.Add(decal);
            World.UpdateDecalBuffers();
            Invalidate();
        }
        catch (Exception ex)
        {
            ExceptionBox.Show(this, ex);
        }
    }


    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        var tool = ToolMode;

        if (e.Button == MouseButtons.Left)
        {
            if (tool == ToolMode.EditDecals && World.SelectedDecal != null)
            {
                WorldChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        World.MouseLeftUp(tool);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        _enter = true;
        base.OnMouseEnter(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (_enter)
        {
            Camera.MouseMoveEventHandler(e, false);
            _enter = false;
        }

        bool move = e.Button.HasFlag(MouseButtons.Middle);

        Camera.MouseMoveEventHandler(e, move);

        base.OnMouseMove(e);

        var tool = ToolMode;

        var worldPos = Camera.ScreenToWorldSpace(new Vector2(e.X, e.Y));
        World.MouseMove(tool, worldPos);

        bool refresh = move;

        if (tool == ToolMode.EditDecals)
        {
            if (e.Button == MouseButtons.Left && World.SelectedDecal != null)
            {
                World.SelectedDecal.MoveBy(World.Delta);
                World.UpdateDecalBuffers();
                Form.DecalPanel.UpdateDecalInfo();
                refresh = true;
            }
        }

        if (refresh)
        {
            Refresh();
        }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        Camera.MouseScrollEventHandler(e, 1.5f);

        base.OnMouseWheel(e);

        Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (DesignMode)
        {
            return;
        }

        var timestamp = DateTime.Now;

        Camera.ScreenSize = new Vector2(Width, Height);

        var g = e.Graphics;

        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = PixelOffsetMode.Half;

        var zero = Camera.WorldToScreenSpace(Vector2.Zero);

        g.DrawLine(Pens.Red, new Point(0, (int)zero.Y), new Point(Width, (int)zero.Y));
        g.DrawLine(Pens.Green, new Point((int)zero.X, 0), new Point((int)zero.X, Height));

        World.Draw(g, Font, RenderMode);



        var sb = new StringBuilder();
        sb.AppendLine($"X:{(int)Camera.Position.X} Y:{(int)Camera.Position.Y}");
        sb.AppendLine($"Performance");
        sb.AppendLine($" - DecalBufferUpdateTime: {World.DecalBufferUpdateTime.TotalMilliseconds:F2}ms");
        sb.AppendLine($" - GdiDisplayTime: {(DateTime.Now - timestamp).TotalMilliseconds:F2}ms");

        g.DrawString(sb.ToString(), Font, Brushes.White, Point.Empty);

        base.OnPaint(e);
    }
}
