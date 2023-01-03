

internal static class ArrayHelper 
{
    
    private static T[] GetColumn<T>(T[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
    }

    private static T[] GetRow<T>(T[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
    }

    internal static IEnumerable<T> GetDiagonalOne<T>(T[,] matrix) 
    {
        return Enumerable.Range(0, matrix.GetLength(1)).Select((x, i) => matrix[i, x]);     
    }

    internal static IEnumerable<T> GetDiagonalTwo<T>(T[,] matrix) 
    {
        var length = matrix.GetLength(0) - 1;
        return Enumerable.Range(0, matrix.GetLength(0)).Select((x, i) => matrix[length - i, x]);     
    }

    internal static IEnumerable<T[]> GetRows<T>(T[,] matrix) 
    {
        return Enumerable.Range(0, matrix.GetLength(1)).Select(s => ArrayHelper.GetRow(matrix, s));
    }

    internal static IEnumerable<T[]> GetColumns<T>(T[,] matrix) 
    {
        return Enumerable.Range(0, matrix.GetLength(1)).Select(s => ArrayHelper.GetColumn(matrix, s));
    }
}