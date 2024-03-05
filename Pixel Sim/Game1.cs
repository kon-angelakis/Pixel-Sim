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

        private Cell[,] grid, grid_drawn;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = resX;
            _graphics.PreferredBackBufferHeight = resY;
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f);
        }


        protected override void LoadContent()
        {
            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            r = new Random();


            grid = new Cell[cols, rows];
            grid_drawn = new Cell[cols, rows];

            //dynamic cell size according to set resolution
            cell_size = resX / cols;

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    grid[x, y] = new Cell(x * resY / rows, y * resX / cols, cell_size, texture, Color.Gold);
                    grid_drawn[x, y] = new Cell(x * resY / rows, y * resX / cols, cell_size, texture, Color.Gold);

                }
            }

        }

        protected override void Update(GameTime gameTime)
        {
            CheckControls();

            for (int x = cols - 2; x >= 1; x--)
            {
                for (int y = rows - 2; y >= 0; y--)
                {
                    //Don't update empty cells save resources 
                    if (grid_drawn[x, y].getValue() != 0)
                    {
                        grid_drawn[x, y].UpdateNeighbours(grid_drawn[x - 1, y], grid_drawn[x + 1, y], grid_drawn[x, y + 1], grid_drawn[x - 1, y + 1], grid_drawn[x + 1, y + 1]);
                        grid_drawn[x, y].UpdateCell();

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
            grid_drawn[(int)Math.Floor((double)Mouse.GetState().X / cell_size), (int)Math.Floor((double)Mouse.GetState().Y / cell_size)].Draw(_spriteBatch);

            foreach (Cell c in grid_drawn)
            {
                //If not empty cell draw
                if (c.getValue() != 0)
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
                if (mouseCellX > 0 && mouseCellX < cols - 1)
                    grid_drawn[(int)mouseCellX, (int)mouseCellY].setValue(1);

            }

            //Clear canvas
            if (currentMouse.MiddleButton == ButtonState.Pressed)
            {
                foreach (Cell c in grid_drawn)
                {
                    c.setValue(0);
                }
            }


        }

    }
}