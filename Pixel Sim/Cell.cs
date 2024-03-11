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
            this.x = x;
            this.y = y;

        }

        public void UpdateNeighbours(Cell l, Cell r, Cell d, Cell d_l, Cell d_r)
        {
            this.Left = l;
            this.Right = r;
            this.Down = d;
            this.Down_L = d_l;
            this.Down_R = d_r;
        }

        public void UpdateCell()
        {
            e.ChangeCell(this);
        }
        public void SetElement(Element e) { this.e = e; }

        public int GetX() {  return x; }
        public int GetY() { return y; }
        public Color GetCellColor() { return e.GetColor(); }
        public Element GetElement() { return e; }
    }
}
