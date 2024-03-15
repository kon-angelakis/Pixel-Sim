using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Sim.Elements.Abstraction;
using Pixel_Sim.Logic;
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
        private int rows = 9 * 20;
        private int cols = 16 * 20;
        public int cell_size;

        private SpriteFont font;

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

            font = Content.Load<SpriteFont>("Fonts/PlacementPreview");

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

            GameControl.CheckControls(this, grid);
            GridLogic.UpdateGrid(grid, rows, cols);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 0, 0));

            _spriteBatch.Begin();

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (grid[x, y].Element is not None)
                        _spriteBatch.Draw(texture, new Rectangle(grid[x, y].X * cell_size, grid[x, y].Y * cell_size, cell_size, cell_size), grid[x, y].Element.Color);

                }
            }
            _spriteBatch.DrawString(font, GameControl.GetElementName(), new Vector2(Mouse.GetState().X, Mouse.GetState().Y - 35), Color.White);
          
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
