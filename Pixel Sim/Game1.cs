using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Pixel_Sim
{
    public class Game1 : Game
    {
        private const int resX = 1920, resY = 1080;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Random r = new Random();

        private Cell[,] grid;
        private int rows = 9 * 12;
        private int cols = 16 * 12;
        public int cell_size;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = resY;
            _graphics.PreferredBackBufferWidth = resX;
            _graphics.IsFullScreen = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1f / 60f);
        }

        protected override void Initialize()
        {
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

            grid = new Cell[cols, rows];
            cell_size = resX / cols;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    grid[x, y] = new Cell(x, y);
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {

            GameLogic.UpdateGrid(grid, rows, cols);
            GameLogic.CheckControls(this, grid);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 0, 0));

            _spriteBatch.Begin();
            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = cols - 1; x >= 0; x--)
                {
                    if (grid[x, y].GetElement() is not None)
                        _spriteBatch.Draw(texture, new Rectangle(grid[x, y].GetX() * cell_size, grid[x, y].GetY() * cell_size, cell_size, cell_size), grid[x, y].GetCellColor());

                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
