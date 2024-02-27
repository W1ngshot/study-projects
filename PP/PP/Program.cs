using System.Diagnostics;

int[][] GenerateMatrix(int n)
{
    var random = new Random();
    var matrix = CreateMatrix(n, n);
    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < n; j++)
        {
            matrix[i][j] = random.Next(10000);
        }
    }

    return matrix;
}

static int[][] CreateMatrix(int rows, int cols)
{
    var result = new int[rows][];
    for (var i = 0; i < rows; ++i)
        result[i] = new int[cols]; // автоинициализация в 0
    return result;
}

int[][] MultiplyMatrix(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var i = 0; i < a.Length; i++) 
    {
        for (var j = 0; j < a.Length; j++)
        {
            for (int k = 0; k < a.Length; k++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}


int[][] MultiplyMatrix2(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var i = 0; i < a.Length; i++) 
    {
        for (var k = 0; k < a.Length; k++)
        {
            for (int j = 0; j < a.Length; j++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}


int[][] MultiplyMatrix3(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var j = 0; j < a.Length; j++) 
    {
        for (var k = 0; k < a.Length; k++)
        {
            for (int i = 0; i < a.Length; i++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}


int[][] MultiplyMatrix4(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var j = 0; j < a.Length; j++) 
    {
        for (var i = 0; i < a.Length; i++)
        {
            for (int k = 0; k < a.Length; k++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}


int[][] MultiplyMatrix5(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var k = 0; k < a.Length; k++) 
    {
        for (var i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a.Length; j++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}


int[][] MultiplyMatrix6(int[][] a, int[][] b)
{
    var result = CreateMatrix(a.Length, a.Length);
    
    for (var k = 0; k < a.Length; k++) 
    {
        for (var j = 0; j < a.Length; j++)
        {
            var sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    return result;
}
var stopwatch = new Stopwatch();
//засекаем время начала операции

var a = GenerateMatrix(600);
var b = GenerateMatrix(600);

stopwatch.Start();
var result = MultiplyMatrix(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();

stopwatch.Start();
var result2 = MultiplyMatrix2(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();

stopwatch.Start();
var result3 = MultiplyMatrix3(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();

stopwatch.Start();
var result4 = MultiplyMatrix4(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();

stopwatch.Start();
var result5 = MultiplyMatrix5(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();

stopwatch.Start();
var result6 = MultiplyMatrix6(a, b);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);