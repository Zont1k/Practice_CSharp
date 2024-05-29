class Program
{
    static void Main(string[] args)
    {
        int[] array = { 9, 4, 7, 6, 2, 3, 8, 5, 0, 1 };

        BubbleSortMethod(array);

        PrintArray("BubbleSort:", array);

        QuickSortMethod(array, 0, array.Length - 1);

        PrintArray("QuickSort:", array);
    }

    public static void BubbleSortMethod(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int currentElement = array[i];

            for (int j = i + 1; j < array.Length; j++)
            {
                if (currentElement > array[j])
                {
                    currentElement = currentElement + array[j];
                    array[j] = currentElement - array[j];
                    currentElement = currentElement - array[j];
                }
            }
            array[i] = currentElement;
        }
    }
    public static void QuickSortMethod(int[] array, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high);

            QuickSortMethod(array, low, partitionIndex - 1);
            QuickSortMethod(array, partitionIndex + 1, high);
        }
    }

    public static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;

                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }

    static void PrintArray(string nameSortMethod, int[] arr)
    {
        Console.WriteLine($"{nameSortMethod}");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}