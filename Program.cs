using SubWizard.Data;
using System.Numerics;

namespace SubWizard
{
    public class Program
    {
        static double[] expected = new double[26];
        /*public static void Main()
        {
            /*Gather.Init();
            expected = Gather.TotalLetterFreq();
            
            
            string input = Console.ReadLine() ?? "";
            BigInteger upper = UpperBound(input);
            Console.WriteLine($"Upperbound of estimate: {upper}");
            string[] words = input.Split(' ');
            
            IEnumerable<int[]> permutations = Permutation.Generate(7);
            Console.WriteLine(permutations.Count());
            return;

            List<(double, int[])> results = [];
            foreach (int[] transposition in permutations)
            {
                results.Add((ChiSquare(transposition, words), transposition));
            }
            
            IOrderedEnumerable<(double, int[])> orderedResults = results.OrderByDescending(x => x.Item1);
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"{i}: ChiSquare-{orderedResults.ElementAt(i).Item1}, \"{ReplaceCombineTransposition(words, orderedResults.ElementAt(i).Item2)}\"");
            }
        }*/
        static void Main()
    {
        Console.WriteLine(Permutation.Generate(3).Count());
    }




        public static int UniqueChars(string[] s)
        {
            List<int> chars = [];
            foreach (string sub in s)
            {
                foreach (char c in sub)
                {
                    if (!chars.Contains(c - 'a'))
                    {
                        chars.Add(c - 'a');
                    }
                }
            }
            return chars.Count;
        }

        public static string ReplaceCombineTransposition(string[] words, int[] transposition)
        {
            string s = "";
            foreach (string word in words)
            {
                s += word + ' ';
            }
            s = s.TrimEnd();
            for (int i = 0; i < 26; i++)
            {
                s = s.Replace((char)('a' + i), (char)('a' + transposition[i]));
            }
            return s;
        }

        public static BigInteger UpperBound(string s)
        {
            List<char> found = [];
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (!found.Contains(c))
                {
                    found.Add(c);
                }
            }
            int n = found.Count;
            BigInteger result = 1;
            for (int i = 26; i > 0; i--)
            {
                if (n == 0)
                {
                    break;
                }
                n--;
                result *= i;
            }
            return result;
        }

        public static double ChiSquare(int[] transposition, string[] words)
        {
            double result = 0;
            for (int i = 0; i < 26; i++)
            {
                result += Math.Pow(Gather.FreqLetterWords(words, (char)('a' + transposition[i])) - expected[i], 2) / expected[i];
            }
            return result;
        }
    }
}