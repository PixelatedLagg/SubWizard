namespace SubWizard
{
    public static class Combinations
    {
        public static List<List<int>> GenerateCombinations(int length)
        {
            List<List<int>> result = [];
            List<int> currentCombination = [];
            GenerateCombinationsHelper(length, currentCombination, result);
            return result;
        }

        // Helper method to recursively generate unique combinations
        private static void GenerateCombinationsHelper(int length, List<int> currentCombination, List<List<int>> result)
        {
            if (currentCombination.Count == length)
            {
                result.Add(new List<int>(currentCombination)); // Add current combination to result
                return;
            }
            for (int i = 0; i <= 25; i++)
            {
                if (!currentCombination.Contains(i))
                {
                    currentCombination.Add(i);
                    GenerateCombinationsHelper(length, currentCombination, result);
                    currentCombination.Remove(i);
                }
            }
        }
    }
}