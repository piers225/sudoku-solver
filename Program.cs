
using Solver;

int [,] matrix = new int[3,3] {
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};
/*
int [,] matrix = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};
*/

var gridIterator = new GridIterator<int>(matrix);

foreach(var iteration in gridIterator.Values()) {
    var grid = new Grid(iteration);
    if (grid.isValid()) {
        printGrid(iteration);
        Console.WriteLine();
    }
}

void printGrid(int[,] grid) 
{
    foreach(var row in ArrayHelper.GetRows(grid))
    {
        Console.WriteLine(string.Join(",", row));
    }
}