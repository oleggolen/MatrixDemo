using System;

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for(int j=0;j<matrix.GetLength(1);j++)
            Console.Write($"{matrix[i,j]} ");
        Console.WriteLine();
    }
}

int[,] CreateMatrix(int length, int width, int leftBound, int rightBound)
{
    int[,] matrix = new int[length, width];
    Random random = new Random();
    for(int i=0;i<matrix.GetLength(0);i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = random.Next(leftBound, rightBound);
    return matrix;
}

int CountElementInMatrix(int[,] matrix, int element)
{
    int amount = 0;
    for(int i=0;i<matrix.GetLength(0);i++)
        for(int j=0;j<matrix.GetLength(1);j++)
            if (matrix[i, j] == element)
                amount++;
    return amount;
}

bool HasMeetElement(int[,] matrix, int element, int row, int column)
{
    for(int i=0;i<matrix.GetLength(0);i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i == row && j == column)
            return false;
        if (matrix[i, j] == element)
            return true;
    }
    return false;
}

int CountUniqueElements(int[,] matrix)
{
    int amount = 0;
    for(int i=0;i<matrix.GetLength(0);i++)
        for(int j=0;j<matrix.GetLength(1);j++)
            if (HasMeetElement(matrix, matrix[i, j], i, j) == false)
                amount++;
    return amount;
}

int[] GetUniqueElements(int[,] matrix)
{
    int[] uniqueElements = new int[CountUniqueElements(matrix)];
    int index = 0;
    for(int i=0;i<matrix.GetLength(0);i++)
        for(int j=0;j<matrix.GetLength(1);j++)
            if (HasMeetElement(matrix, matrix[i, j], i, j) == false)
            {
                uniqueElements[i] = matrix[i, j];
                index++;
            }
    return uniqueElements;
}

void PrintArray(int[] array)
{
    for(int i=0;i<array.Length;i++)
        Console.Write($"{array[i]} ");
    Console.WriteLine();
}

int[,] CountFrequencyElements(int[,] matrix)
{
    int[] uniqueElements = GetUniqueElements(matrix);
    PrintArray(uniqueElements);
    Console.WriteLine();
    int[,] frequencies = new int[uniqueElements.Length, 2];
    for (int i = 0; i < frequencies.GetLength(0); i++)
    {
        frequencies[i,0] = uniqueElements[i];
        frequencies[i, 1] = CountElementInMatrix(matrix,uniqueElements[i]);
    }
    return frequencies;
}

var matrix = CreateMatrix(5, 5, 5, 70);
PrintMatrix(matrix);
Console.WriteLine("\n");
var frequencies = CountFrequencyElements(matrix);
PrintMatrix(frequencies);
