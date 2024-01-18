class Program
{
    public static HashSet<char> Vowels { get; set; } = new HashSet<char> { 'A', 'E', 'I', 'O', 'U' };
    public static HashSet<char> Consonants { get; set; } = new HashSet<char> { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };

    static void Main(string[] args)
    {
        Console.WriteLine("write something...:");
        string words = Console.ReadLine().ToUpperInvariant();
        char[] charArrayLetters = words.ToCharArray();

        CountVowelsAndConsonants(charArrayLetters, out int countConsonants, out int countVowels);
        Console.WriteLine($"Count of vowels letters: {countConsonants}");
        Console.WriteLine($"Count of consonants letters: {countVowels}");
    }

    private static void CountVowelsAndConsonants(char[] charArrayLetters, out int countConsonants, out int countVowels)
    {
        countConsonants = 0;
        countVowels = 0;
        
        for (int i = 0; i < charArrayLetters.Length; i++)
        {
            char currentLetter = charArrayLetters[i];

            if (Consonants.Contains(currentLetter))
            {
                countConsonants++;
            }

            if (Vowels.Contains(currentLetter))
            {
                countVowels++;
            }
        }
    }
}

// Todo: hashset 
// Todo: Tuple
