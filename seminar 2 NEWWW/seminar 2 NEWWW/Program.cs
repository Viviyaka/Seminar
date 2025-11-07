namespace seminar_2_NEWWW
{
    internal class Program
    {
        static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

       
        static int[] SortArray(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                for (int j = 0; j < sortedArray.Length - i - 1; j++)
                {
                    if (sortedArray[j] < sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            return sortedArray;
        }
        static int BinarySearch(int[] sortedArray, int target)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (sortedArray[mid] == target)
                    return mid;

                if (sortedArray[mid] < target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 5, 6, 18, 7, 10, 22, 3, 19, 50, 31, 87, 16 };

            int maxNumber = FindMax(numbers);
            Console.WriteLine($"Maximální číslo: {maxNumber}");
            Console.WriteLine();

            int[] sortedNumbers = SortArray(numbers);
            Console.WriteLine("Seřazené pole (od největšího po nejmenší):");
            foreach (int n in sortedNumbers)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine("\n");

            Console.Write("Napište číslo, které chcete najít: ");
            int cNumber = int.Parse(Console.ReadLine());
            int index = BinarySearch(sortedNumbers, cNumber);

            Console.WriteLine($"Index čísla {cNumber}: {index}");

            Console.WriteLine("\nStiskněte libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }
    }
}
