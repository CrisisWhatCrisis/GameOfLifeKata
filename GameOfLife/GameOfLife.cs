using System.Collections.Generic;

namespace GameOfLife
{
    public class GameOfLife
    {
        private const bool Live = true;
        private const bool Dead = false;

        public List<List<bool>> ProcessGrid(List<List<bool>> grid)
        {
            var rowCount = grid.Count;
            for (var row = 0; row < rowCount; row++)
            {
                var columnCount = grid[row].Count;
                for (var column = 0; column < columnCount; column++)
                {
                    var liveNeighbours = GetLiveNeighbourCountForCell(grid, row, column, rowCount, columnCount);

                    if (grid[row][column] == Live && liveNeighbours < 2 || liveNeighbours > 3)
                    {
                        grid[row][column] = Dead;
                    }
                    else if (grid[row][column] == Dead && liveNeighbours == 3)
                    {
                        grid[row][column] = Live;
                    }
                }
            }
            return grid;

        }

        private static int GetLiveNeighbourCountForCell(IReadOnlyList<List<bool>> grid, int row, int column, int rowCount, int columnCount)
        {
            return GetNeighbourCountForCell(grid, row, column, rowCount, columnCount, Live);
        }

        private static int GetNeighbourCountForCell(IReadOnlyList<List<bool>> grid, int row, int column, int rowCount, int columnCount, bool status)
        {
            var count = 0;
            var onTopRow = row == 0;
            var onBottomRow = row == rowCount - 1;
            var onLeftEdge = column == 0;
            var onRightEdge = column == columnCount - 1;

            if (!onTopRow && grid[row -1][column] == status) count++;

            if (!onBottomRow && grid[row + 1][column] == status) count++;

            if (!onLeftEdge && grid[row][column - 1] == status) count++;

            if (!onRightEdge && grid[row][column + 1] == status) count++;

            if (!onLeftEdge && !onTopRow && grid[row - 1][column - 1] == status) count++;

            if (!onRightEdge && !onTopRow && grid[row - 1][column + 1] == status) count++;

            if (!onLeftEdge && !onBottomRow && grid[row + 1][column - 1] == status) count++;

            if (!onRightEdge && !onBottomRow && grid[row + 1][column + 1] == status) count++;

            return count;
        }
    }
}