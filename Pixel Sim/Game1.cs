using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Pixel_Sim
{
    public class Game1 : Game
    {
        private const int resX = 1920;
        private const int resY = 1080;

        private MouseState currentMouse, prevMouse;
        private GraphicsDeviceManager _graphics;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch;
        private Texture2D texture;

        private Random r;

        //Make them so they are multiples of resX and resY standard 16:9 resolution
        private int rows = 9 * 20;
        private int cols = 16 * 20;
        private int cell_size;

        private Cell[,] grid;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = resX;
            _graphics.PreferredBackBufferHeight = resY;
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 165.0f);
        }


        protected override void LoadContent()
        {
            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            r = new Random();


            grid = new Cell[cols, rows];

            //dynamic cell size according to set resolution
            cell_size = resX / cols;

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    grid[x, y] = new Cell(x * resY / rows, y * resX / cols, cell_size, texture, Color.Gold);

                }
            }

        }

        protected override void Update(GameTime gameTime)
        {
            CheckControls();

            //Start from bottom left corner of the grid
            for (int y = rows - 2; y >= 0; y--)
            {
                for (int x = 1; x < cols -2 ; x++)
                {
                    //Don't update cells with no element, save resources 
                    if (grid[x, y].getElement() != null)
                    {
                        grid[x, y].UpdateNeighbours(grid[x - 1, y], grid[x + 1, y], grid[x, y + 1], grid[x - 1, y + 1], grid[x + 1, y + 1]);
                        grid[x, y].UpdateCell(r);

                    }

                }
            }
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 0, 0));

            _spriteBatch.Begin();

            //Placement preview
            grid[(int)Math.Floor((double)Mouse.GetState().X / cell_size), (int)Math.Floor((double)Mouse.GetState().Y / cell_size)].Draw(_spriteBatch);

            foreach (Cell c in grid)
            {
                //If not empty cell draw
                if (c.getElement() != null)
                    c.Draw(_spriteBatch);

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CheckControls()
        {
            double mouseX = Mouse.GetState().X;
            double mouseY = Mouse.GetState().Y;

            double mouseCellX = Math.Floor(mouseX / cell_size);
            double mouseCellY = Math.Floor(mouseY / cell_size);

            prevMouse = currentMouse;
            currentMouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();


            if (currentMouse.LeftButton == ButtonState.Pressed)
            {
                if ((int)mouseCellX > 0 && (int)mouseCellX < cols - 2)
                    grid[(int)mouseCellX, (int)mouseCellY].setElement(new Sand());
            }


            //Clear canvas
            if (currentMouse.MiddleButton == ButtonState.Pressed)
            {
                foreach (Cell c in grid)
                {
                    c.setElement(null);
                }
            }


        }

    }
}