﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pixel_Sim.Elements;
using Pixel_Sim.Elements.Abstraction;

namespace Pixel_Sim.Logic
{
    internal static class GridLogic
    {
        public static void UpdateGrid(Cell[,] grid, int rows, int cols)
        {

            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (grid[x, y].Element is not None)
                        grid[x, y].UpdateNeighbours(
                            y > 0 ? grid[x, y - 1] : null, //up
                            y > 0 && x > 0 ? grid[x - 1, y - 1] : null, //up_left
                            y > 0 && x < cols - 1 ? grid[x + 1, y - 1] : null, //up_right
                            x > 0 ? grid[x - 1, y] : null, //left
                            x < cols - 1 ? grid[x + 1, y] : null, //right
                            y < rows - 1 ? grid[x, y + 1] : null, //down
                            x > 0 && y < rows - 1 ? grid[x - 1, y + 1] : null, //down_left
                            x < cols - 1 && y < rows - 1 ? grid[x + 1, y + 1] : null //down_right
                        );


                }
            }

            for (int y = rows - 1; y >= 0; y--)
            {
                //Remove left bias by updating each row randomly from left-right or right-left
                if (new Random().NextDouble() < 0.5f)
                    for (int x = 0; x < cols; x++)
                    {
                        if (grid[x, y].Element is not None)
                            grid[x, y].UpdateCell(grid);
                    }
                else
                    for (int x = cols - 1; x >= 0; x--)
                    {
                        if (grid[x, y].Element is not None)
                            grid[x, y].UpdateCell(grid);
                    }
            }

        }

        public static void SwapCell(Cell[,] grid, Cell current, Cell destination)
        {

            // Update grid content
            grid[current.X, current.Y] = destination;
            grid[destination.X, destination.Y] = current;

            // Update cell coords
            int tmpX = current.X;
            int tmpY = current.Y;
            current.X = destination.X;
            current.Y = destination.Y;
            destination.X = tmpX;
            destination.Y = tmpY;
        }
    
        public static void SpreadFire(Cell destination)
        {
            destination.Element = new Fire();
        }
    }
}
