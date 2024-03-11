using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;


namespace Pixel_Sim
{
    internal static class GameLogic
    {
        private static Keys currentKey;
        public static void UpdateGrid(Cell[,] grid, int rows, int cols)
        {
            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = cols - 1; x >= 0; x--)
                {
                    //If cell doesnt have an element no need to calculate neighbours
                    if (grid[x, y].GetElement() is not None)
                        grid[x, y].UpdateNeighbours(
                                x > 0 ? grid[x - 1, y] : null,
                                x < cols - 1 ? grid[x + 1, y] : null,
                                y < rows - 1 ? grid[x, y + 1] : null,
                                x > 0 && y < rows - 1 ? grid[x - 1, y + 1] : null,
                                x < cols - 1 && y < rows - 1 ? grid[x + 1, y + 1] : null
                            );
                    

                }
            }

            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = cols - 1; x >= 0; x--)
                {
                    if (grid[x, y].GetElement() is not None)
                        grid[x, y].UpdateCell();


                }
            }


        }

        public static void SwapCell(Cell current, Cell destination)
        {
            Element tmp = current.GetElement();
            current.SetElement(destination.GetElement());
            destination.SetElement(tmp);
        }

        public static void CheckControls(Game1 game, Cell[,] grid)
        {
            Random r = new Random();
            double mouseX = Mouse.GetState().X;
            double mouseY = Mouse.GetState().Y;

            double mouseCellX = Math.Floor(mouseX / game.cell_size);
            double mouseCellY = Math.Floor(mouseY / game.cell_size);
            
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();

            //Clear selected pixel with right click or whole canvas with middle
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                grid[(int)mouseCellX, (int)mouseCellY].SetElement(new None());

            if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
                foreach (Cell c in grid)
                    c.SetElement(new None());

            //Get new key with each keyboard button stroke
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
                currentKey = Keyboard.GetState().GetPressedKeys()[0];

            //Figure out which element to add based on keyboard pressed key
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                switch (currentKey)
                {
                    case Keys.Z:
                        grid[(int)mouseCellX, (int)mouseCellY].SetElement(new Sand(r.NextDouble() < 0.5f));
                        break;
                    case Keys.X:
                        grid[(int)mouseCellX, (int)mouseCellY].SetElement(new Water(r.NextDouble() < 0.5f));
                        break;
                    case Keys.C:
                        grid[(int)mouseCellX, (int)mouseCellY].SetElement(new Stone());
                        break;
                    default:
                        break;
                }

            }
            

            
        }
    }
}
