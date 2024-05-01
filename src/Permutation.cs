namespace SubWizard
{
    public static class Permutation
    {
        public static IEnumerable<int[]> Generate(int n)
        {
            int[] permutation = new int[n];
            bool[] used = new bool[26];
            return GenerateRecursive(0, n, permutation, used);
        }
        
        private static IEnumerable<int[]> GenerateRecursive(int index, int n, int[] permutation, bool[] used)
        {
            if (index == n)
            {
                yield return permutation;
            }
            for (int i = 0; i < 26; i++)
            {
                if (!used[i])
                {
                    permutation[index] = i;
                    used[i] = true;
                    GenerateRecursive(index + 1, n, permutation, used);
                    used[i] = false;
                }
            }
        }

        public static int[] ConvertToChars(int[] x, int[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (x[j] == i)
                    {
                        x[j] = chars[i];
                    }
                }
            }
            return x;
        }
    }
}