using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Sim.Elements.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Logic
{
    internal class Cell
    {
        private int x, y;
        private Element e = new None();
        public Cell Up, Up_L, Up_R, Left, Right, Down, Down_L, Down_R;
        public List<Cell> Neighbours = new List<Cell>();

        public Cell(int x, int y)
        {
            X = x;
            Y = y;

        }

        //Setters and Getters
        public int X { set { x = value; } get { return x; } }
        public int Y { set { y = value; } get { return y; } }
        public Element Element { set { e = value; } get { return e; } }

        public void UpdateNeighbours(Cell u, Cell u_l, Cell u_r, Cell l, Cell r, Cell d, Cell d_l, Cell d_r)
        {
            Up = u;
            Up_L = u_l;
            Up_R = u_r;
            Left = l;
            Right = r;
            Down = d;
            Down_L = d_l;
            Down_R = d_r;
            Neighbours.Add(Up);
            Neighbours.Add(Up_L);
            Neighbours.Add(Up_R);
            Neighbours.Add(Left);
            Neighbours.Add(Right);
            Neighbours.Add(Down);
            Neighbours.Add(Down_L);
            Neighbours.Add(Down_R);
        }

        public void UpdateCell(Cell[,] grid)
        {
            e.ChangeCell(this, grid);
            Neighbours.Clear();
        }

        public void Reset()
        {
            UpdateNeighbours(null, null, null, null, null, null, null, null);
            e = new None();
        }
    }
}
