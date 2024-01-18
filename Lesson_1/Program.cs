class Program
{
    static void Main(string[] args)
    {
        const int minRange = 1;
        const int maxRange = 100;

        int[] numbers = new int[10];

        FillArrayWithRandomNumbers(numbers, minRange, maxRange);

        var sum = numbers.Sum();

        var avg = numbers.Average();

        Console.WriteLine($"Summa: {sum}. Srednie arifmeticheskoe: {avg}");
    }

    private static void FillArrayWithRandomNumbers(int[] numbers, int minRange, int maxRange)
    {
        Random random = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(minRange, maxRange);
        }
    }
}