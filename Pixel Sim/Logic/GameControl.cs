using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Pixel_Sim.Logic
{
    internal static class GameControl
    {
        private static Keys currentKey;
        private static string element_name = "None";
        private static Dictionary<Keys, string> elementNames = new Dictionary<Keys, string>
        {
            { Keys.Z, "Sand" },
            { Keys.X, "Water" },
            { Keys.C, "Stone" },
        };



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
                grid[(int)mouseCellX, (int)mouseCellY].Element = new None();

            if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
                foreach (Cell c in grid)
                    c.Element = new None();

            //Get new key with each keyboard button stroke. Also get element name for text preview
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                currentKey = Keyboard.GetState().GetPressedKeys()[0];
                if (elementNames.ContainsKey(currentKey))
                    element_name = elementNames[currentKey];
                else
                    element_name = "None";
            }

            //Figure out which element to add based on keyboard pressed key
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && grid[(int)mouseCellX, (int)mouseCellY].Element is None)
            {
                switch (currentKey)
                {
                    case Keys.Z:
                        for (int i = (int)mouseCellX - 3; i < (int)mouseCellX + 3; i++)
                            for (int j = (int)mouseCellY - 3; j < (int)mouseCellY + 3; j++)
                                grid[i, j].Element = new Sand(r.NextDouble() < 0.5f);
                        break;
                    case Keys.X:
                        for (int i = (int)mouseCellX - 3; i < (int)mouseCellX + 3; i++)
                            for (int j = (int)mouseCellY - 3; j < (int)mouseCellY + 3; j++)
                                grid[i, j].Element = new Water(r.NextDouble() < 0.5f);
                        break;
                    case Keys.C:
                        grid[(int)mouseCellX, (int)mouseCellY].Element = new Stone();
                        break;
                    default:
                        break;
                }

            }

        }

        public static string GetElementName() { return element_name; }
    }
}
