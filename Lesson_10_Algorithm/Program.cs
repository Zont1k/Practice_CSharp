using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 4, 9, 7, 6, 2, 3, 8, 5, 0, 1 };

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }

        PrintArray(array);
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}
