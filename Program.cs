namespace SubWizard
{
    public class Program
    {
        public static void Main()
        {
            string cipher = Console.ReadLine() ?? throw new Exception("Error reading input!");
            int letters = cipher.Count(c => !char.IsPunctuation(c) && c != ' '); //get # of all characters
            Dictionary<char, double> cipherLetters = [];
            foreach (char c in cipher.Where(c => !char.IsPunctuation(c) && c != ' '))
            {
                if (cipherLetters.ContainsKey(c))
                {
                    continue;
                }
                cipherLetters.Add(c, (double)cipher.Count(x => x == c) / letters);
                Console.WriteLine($"{c} - {cipherLetters[c]}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{(char)('a' + i)} - {Data.LetterFreq[i]}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}