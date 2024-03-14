using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal class Cell
    {
        private int x, y;
        private Element e = new None();
        public Cell Left, Right, Down, Down_L, Down_R;

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }

        //Setters and Getters
        public int X { set { this.x = value; } get { return (this.x); } }
        public int Y { set { this.y = value; } get { return (this.y); } }
        public Element Element { set { this.e = value; } get { return (this.e); } }

        public void UpdateNeighbours(Cell l, Cell r, Cell d, Cell d_l, Cell d_r)
        {
            this.Left = l;
            this.Right = r;
            this.Down = d;
            this.Down_L = d_l;
            this.Down_R = d_r;

        }

        public void UpdateCell(Cell[,] grid)
        {
            e.ChangeCell(this, grid);
        }
    }
}
