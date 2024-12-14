using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grille.VPaint.IO;

namespace Grille.VPaint;

public class UndoRedoBuffer
{
    public byte[][] buffers;

    int position;

    int count;

    int size;

    public UndoRedoBuffer()
    {
        size = 8;
        buffers = new byte[size][];
    }

    public void Backup(World world)
    {
        return;

        using var stream = new MemoryStream();
        BinarySerializer.Save(stream, world, false);
        var array = stream.ToArray();

        if (position == size - 1)
        {
            for (int i = 0; i < size - 1; i++)
            {
                buffers[i] = buffers[i + 1];
            }
            buffers[position] = array;

            Console.WriteLine(position);
        }
        else
        {
            Console.WriteLine(position);

            buffers[position] = array;
            position++;
            count = position;
        }
    }

    public void Undo(World world)
    {
        return;
        if (position > 0)
        {

            using var stream = new MemoryStream(buffers[--position]);
            BinarySerializer.Load(stream, world);
        };
    }

    public void Redo(World world)
    {

    }
}
