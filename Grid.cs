namespace Solver;

internal class Grid 
{
    private readonly int[,] grid;

    public Grid(int[,] grid) 
    {
        this.grid = grid;
    }

    internal bool isValid()
    {
        var rows = ArrayHelper.GetRows(grid).Select(s => s.Sum());
        
        var columns = ArrayHelper.GetColumns(grid).Select(s => s.Sum());

        var diagonal1 = ArrayHelper.GetDiagonalTwo(grid).Sum();

        var diagonal2 = ArrayHelper.GetDiagonalOne(grid).Sum();

        var expected = rows.First();

        return rows.All(r => r == expected) && 
            columns.All(c => c == expected) && 
            diagonal1 == expected && 
            diagonal2 == expected;
    }

    void printArray( int[] array) 
    {
        Console.WriteLine($"{string.Join(",", array)}");
    }

} 