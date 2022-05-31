namespace LifeGame
{
    public class LifeGameProcessor
    {
        private readonly int _row;
        private readonly int _col;
        private bool[,] _field;

        public LifeGameProcessor(int xSize, int ySize, Point[] points)
        {
            _row = xSize;
            _col = ySize;
            _field = new bool[_row, _col];
            for (int row = 0; row < _row; row++)
            {
                for (int col = 0; col < _col; col++)
                {
                    _field[row, col] = false;
                }
            }
            for (int k = 0; k < points.Length; k++)
                _field[points[k].X, points[k].Y] = true;
        }

        public Point[] Process()
        {
            List<Point> list = new();
            _field = NextGeneration(_field);
            for (int i = 0; i < _field.GetLength(0); i++)
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    if (_field[i, j])
                    {
                        list.Add(new Point { X=i, Y=j });
                    }
                }
            return list.ToArray();
        }

        private static int CountNeighbours(int x, int y, bool[,] arr)
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = x + i;
                    int row = y + j;
                    bool isSelfChecking = col == x && row == y;

                    if (col < 0 || row < 0)
                        continue;
                    else if (col > arr.GetLength(0) - 1 || row > arr.GetLength(1)-1)
                        continue;
                    else if (arr[col, row] && !isSelfChecking)
                        count++;
                }
            }
            return count;
        }

        private static bool[,] NextGeneration(bool[,] grid)
        {
            bool[,] newGeneration = new bool[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    var n = CountNeighbours(i, j, grid);

                    if (!grid[i, j] && n == 3)
                    {
                        newGeneration[i, j] = true;
                    }
                    else if (grid[i, j] && (n < 2) || n > 3)
                    {
                        newGeneration[i, j] = false;
                    }
                    else
                    {
                        newGeneration[i, j] = grid[i, j];
                    }
                }
            }
            return newGeneration;
        }
    }
}