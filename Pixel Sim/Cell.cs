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

        private int x;
        private int y;
        private int size;

        private Texture2D texture;

        private Color color;

        public Cell down, left, right, down_left, down_right;

        public Element E;


        public Cell(int x, int y, int size, Texture2D texture, Color color)
        {
            this.x = x;
            this.y = y;
            this.texture = texture;
            this.color = color;
            this.size = size;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, new Rectangle(x, y, size, size), color);
        }

        public void UpdateNeighbours(Cell left, Cell right, Cell down, Cell down_left, Cell down_right)
        {
            this.left = left;
            this.right = right;
            this.down = down;
            this.down_left = down_left;
            this.down_right = down_right;
        }


        public void UpdateCell(Random r)
        {
            E.UpdatePosition(this, left, right, down, down_left, down_right, r);
        }

        public void setElement(Element E)
        {
            this.E = E;
        }

        public Element getElement()
        {
            return (this.E);
        }

    }
}
