class Program
{
    static void Main(string[] args)
    {
        Random random  = new Random();

        int minNumber = 1;
        int maxNumber = 10;

        int[,] array = new int[5, 5];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0;  j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(minNumber, maxNumber);
            }
        }

        Console.WriteLine("Default matrix:/n");

        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]} \t");
            }
            Console.WriteLine(); 
        }

        Console.WriteLine("Not Default matrix:/n");

        for (int j = 0; j < array.GetLength(1);j++)
        {
            for(int i = 0; i < array.GetLength(0);i++)
            {
                Console.Write($"{array[i, j]} \t");
            }
            Console.WriteLine();
        }
    }
}