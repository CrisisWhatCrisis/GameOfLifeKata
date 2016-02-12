using System.Collections.Generic;
using System.Data;

namespace GameOfLife
{
    public class GameOfLife
    {
        const bool ALIVE = true;
        const bool DEAD = false;

        public List<List<bool>> ProcessGrid(List<List<bool>> grid)
        {
            var columnCount = grid.Count;
            for (var columnNo = 0; columnNo < columnCount; columnNo++)
            {
                var rowCount = grid[columnNo].Count;
                for (var rowNo = 0; rowNo < rowCount; rowNo++)
                {

                    var liveCount = GetLiveCountForCell(grid, columnNo, rowNo, rowCount, columnCount);
                    if (grid[columnNo][rowNo] == ALIVE)
                    {
                        if (liveCount < 2 || liveCount > 3)
                        {
                            grid[columnNo][rowNo] = DEAD;
                        }
                    }
                }
            }
            return grid;

        }

        private static int GetLiveCountForCell(List<List<bool>> grid, int columnNo, int rowNo, int rowCount, int columnCount)
        {

            var numberAlive = 0;
            var onTopRow = rowNo == 0;
            var onBottomRow = rowNo == rowCount-1;
            var onLeftEdge = columnNo == 0;
            var onRightEdge = columnNo == columnCount-1;


            if (!onTopRow)
            {
                if (grid[columnNo][rowNo - 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }
            if (!onBottomRow)
            {
                if (grid[columnNo][rowNo + 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }

            if (!onLeftEdge)
            {
                if (grid[columnNo - 1][rowNo] == ALIVE)
                {
                    numberAlive += 1;
                }
            }
            if (!onRightEdge)
            {
                if (grid[columnNo + 1][rowNo] == ALIVE)
                {
                    numberAlive += 1;
                }
            }

            if (!onLeftEdge && !onTopRow)
            {
                if (grid[columnNo - 1][rowNo - 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }

            if (!onRightEdge && !onTopRow)
            {
                if (grid[columnNo + 1][rowNo - 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }

            if (!onLeftEdge && !onBottomRow)
            {
                if (grid[columnNo - 1][rowNo + 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }

            if (!onRightEdge && !onBottomRow)
            {
                if (grid[columnNo + 1][rowNo + 1] == ALIVE)
                {
                    numberAlive += 1;
                }
            }
            return numberAlive;


        }
    }
}