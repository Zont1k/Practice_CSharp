namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minNumber = 1;
            int maxNumber = 10;

            int[,] array = new int[5, 5];

            // Todo: "new Method"
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minNumber, maxNumber);
                }
            }

            Console.WriteLine("Default matrix:/n");

            // Todo: "new Method"
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Not Default matrix:/n");

            // Todo: "Create new Method for transposing"
            // Todo: "Call Display Method for transpost Matrix"
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        const int minNumber = 1;
        const int maxNumber = 10;

        int[,] array = new int[5, 5];

        FillMatrixWithRandomValues(array, random, minNumber, maxNumber);

        Console.WriteLine("Default matrix:\n");
        DisplayMatrix(array);

        Console.WriteLine("Transposed matrix:\n");
        int[,] transposedArray = TransposeMatrix(array);
        DisplayMatrix(transposedArray);
    }

    static void FillMatrixWithRandomValues(int[,] matrix, Random random, int minValue, int maxValue)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    static void DisplayMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static int[,] TransposeMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] transposedMatrix = new int[cols, rows];

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                transposedMatrix[j, i] = matrix[i, j];
            }
        }

        return transposedMatrix;
    }
}

