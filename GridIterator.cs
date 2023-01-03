

using System.Collections;

internal class GridIterator<T>
{
    private readonly T[,] source;

    public GridIterator(T[,] source) 
    {
        this.source = source;
    }

    internal IEnumerable<T[,]> Values() 
    {
        T[] data = source.Cast<T>().ToArray();

        return Permutate(data, Enumerable.Empty<T>()).Select(ToMatrix);
    }
    private IEnumerable<T[]> Permutate(IEnumerable<T> source, IEnumerable<T> prefix)
    {
        return source.Any() ? 
            source.SelectMany((c, i) => Permutate(source.Take(i).Concat(source.Skip(i + 1)), prefix.Append(c))) :
                new[] { prefix.ToArray() };
    }

    private T[,] ToMatrix(IEnumerable<T> sequence)
    {
        var items = sequence.ToList();

        return items.Aggregate(new T[source.GetLength(0), source.GetLength(1)], 
            (accum, item) => {
                var i = items.IndexOf(item);
                accum[i / source.GetLength(0) , i % source.GetLength(0)] = item;
                return accum;
            });
    }
}