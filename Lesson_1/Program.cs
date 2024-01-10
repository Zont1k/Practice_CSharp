class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int minRange = 1;
        int maxRange = 100;

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(minRange, maxRange);
        }

        int sum = 0;
       
        foreach (int i in numbers)
        {
            sum += i;
        }

        double sredArif = sum / numbers.Length;

        Console.WriteLine($"Summa: {sum}. Srednie arifmetichesoe: {sredArif}");
    }
}