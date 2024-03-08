using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;


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

        private Cell[,] grid, next_grid;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = resX;
            _graphics.PreferredBackBufferHeight = resY;
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            TargetElapsedTime = TimeSpan.FromSeconds(1f / 165f);
        }


        protected override void LoadContent()
        {
            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            r = new Random();


            grid = new Cell[cols, rows];
            next_grid = new Cell[cols, rows];

            //dynamic cell size according to set resolution
            cell_size = resX / cols;

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    grid[x, y] = new Cell(x * resY / rows, y * resX / cols, cell_size, texture);
                }
            }
    
        }

        protected override void Update(GameTime gameTime)
        {
            CheckControls();


            Array.Copy(grid, next_grid, grid.Length);
            // Update the next grid's state based on the current grid's state
            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = cols - 1; x >= 0; x--)
                {
                    if (grid[x, y].GetElement() != null)
                    {


                        // Update neighbors and cell state
                        next_grid[x, y].UpdateNeighbours(
                            x > 0 ? grid[x - 1, y] : null,
                            x < cols - 1 ? grid[x + 1, y] : null,
                            y < rows - 1 ? grid[x, y + 1] : null,
                            x > 0 && y < rows - 1 ? grid[x - 1, y + 1] : null,
                            x < cols - 1 && y < rows - 1 ? grid[x + 1, y + 1] : null
                        );

                        next_grid[x, y].UpdateCell(r);
                    }
                }
            }
            Array.Copy(next_grid, grid, grid.Length);





            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 0, 0));

            _spriteBatch.Begin();

            //Placement preview
            DrawPreview();

            foreach (Cell c in grid)
            {

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


            if (currentMouse.LeftButton == ButtonState.Pressed
                /*&& prevMouse.LeftButton == ButtonState.Released*/)
                grid[(int)mouseCellX, (int)mouseCellY].SetElement(new Stone());

            if (currentMouse.RightButton == ButtonState.Pressed)
                grid[(int)mouseCellX, (int)mouseCellY].SetElement(new Sand());
      


            //Clear canvas
            if (currentMouse.MiddleButton == ButtonState.Pressed)
            {
                grid[(int)mouseCellX, (int)mouseCellY].SetElement(null);
            }


        }

        private void DrawPreview()
        {
      /*      Cell preview = grid[(int)Math.Floor((double)Mouse.GetState().X / cell_size), (int)Math.Floor((double)Mouse.GetState().Y / cell_size)];
            preview.SetPreviewColor(Color.White);
            preview.Draw(_spriteBatch);*/
        }
    }
}