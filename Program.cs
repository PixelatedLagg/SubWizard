using ExtendedNumerics;
using SubWizard.Data;
using System.Numerics;

namespace SubWizard
{
    public class Program
    {
        static BigDecimal[] expected =
        [
            0.0846402860096712,
            0.018296526718835086,
            0.0437750575370124,
            0.03238955368790574,
            0.10772176322650225,
            0.011227836840112776,
            0.023643469967582403,
            0.026430828106619526,
            0.08956630698939853,
            0.001561218150763426,
            0.007672746241673479,
            0.05577434674781033,
            0.030104955866114096,
            0.0719479487121524,
            0.07199344608861344,
            0.03252432893515823,
            0.0016834029290581443,
            0.07043308637891531,
            0.0716180211960545,
            0.06606991659100463,
            0.03762718877433788,
            0.009464312744959735,
            0.006411696316744151,
            0.0030025406994062735,
            0.02019654294337122,
            0.004222671600222851
        ];
        static int[] uniqueChars;

        public static void Main()
        {
            Gather.Init();
            string input = Console.ReadLine() ?? "";
            BigDecimal.AlwaysTruncate = true;
            BigDecimal.Precision = 20;
            BigInteger upper = UpperBound(input);
            Console.WriteLine($"Upperbound of estimate: {upper}");
            string[] words = input.Split(' ');
            
            uniqueChars = UniqueChars(words);
            List<List<int>> combos = Combinations.GenerateCombinations(uniqueChars.Length);
            int x = 0;
            List<(BigDecimal, List<int>)> results = [];
            foreach (List<int> transposition in combos)
            {
                Console.WriteLine(x);
                results.Add((ChiSquare(transposition, words), transposition));
                x++;
            }
            
            IOrderedEnumerable<(BigDecimal, List<int>)> orderedResults = results.OrderByDescending(x => x.Item1);
            for (int i = 0; i < results.Count; i++)
            {
                if (i == 2000)
                {
                    break;
                }
                Console.WriteLine($"{i}: RChiSq-{orderedResults.ElementAt(i).Item1}, \"{ReplaceCombineTransposition(words, orderedResults.ElementAt(i).Item2)}\"");
            }
        }

        public static int[] UniqueChars(string[] s)
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
            return [.. chars];
        }

        public static string ReplaceCombineTransposition(string[] words, List<int> transposition)
        {
            string s = "";
            foreach (string word in words)
            {
                s += word + ' ';
            }
            s = s.TrimEnd();
            for (int i = 0; i < uniqueChars.Length; i++)
            {
                s = s.Replace((char)('a' + uniqueChars[i]), (char)('a' + transposition[i]));
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

        public static BigDecimal ChiSquare(List<int> transposition, string[] words)
        {
            BigDecimal result = 0;
            for (int i = 0; i < uniqueChars.Length; i++)
            {
                result += BigDecimal.Pow(Gather.FreqLetterWords(words, (char)('a' + transposition[i])) - expected[transposition[i]], 2) / expected[transposition[i]];
            }
            return result;
        }
    }
}