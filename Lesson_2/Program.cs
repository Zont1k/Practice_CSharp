class Program
{
    static void Main(string[] args)
    {
        string[] vowels = { "A", "E", "I", "O", "U" };
        string[] consonants = { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z" };

        Console.WriteLine("write something...:");
        string words = Console.ReadLine().ToUpper();
        char[] charArrayLetters = words.ToCharArray();
        int countConsonants = 0;
        int countVowels = 0;

        for (int i = 0; i < charArrayLetters.Length; i++)
        {
            char currentLetter = charArrayLetters[i];

            if (Array.Exists(consonants, c => c[0] == currentLetter))
            {
                countConsonants++;
            }
            if (Array.Exists(vowels, v => v[0] == currentLetter))
            {
                countVowels++;
            }
        }
        Console.WriteLine($"Count of vowels letters: {countConsonants}");
        Console.WriteLine($"Count of consonants letters: {countVowels}");
    }
}
