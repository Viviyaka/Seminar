namespace QuickSort
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string[] cislaText = input.Split(' ');

            int[] arr = new int[cislaText.Length];

            for (int i = 0; i < cislaText.Length; i++)
            {
                arr[i] = int.Parse(cislaText[i]);
            }

            QuickSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        // Базовый Partition (Lomuto)
        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                }
            }

            int temp = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp;

            return i + 1;
        }
    }
}
// BONUSOVÉ OTÁZKY(ODPOVĚDI):
//Bonus č. 1
//Pouzije se algoritmus "Median-of-Medians". Pole se rozdeli na petice prvku, v kazde se najde median a z nich se rekurzivne vybere median medianu. Tento pivot zarucuje dobre rozdeleni pole a linearni cas O(n) i v nejhorsim pripade
//Bonus č. 2
//Pravdepodobnost minima: 0 (nula). Pivot musi byt prostredni ze tri prvku. Pokud vybereme absolutni minimum (cislo 1), bude vzdy nejmensi, ne prostredni. Pravdepodobnost skoromedianu (stredni tretina): Priblizne 68.75 %.
//Bonus č. 3
//Po rozdeleni pole (Partition) musime rekurzi zavolat VZDY nejdrive pro tu MENSI cast.Vetsi cast pak zpracujeme dal v obycajnem cyklu (while) posunutim indexu. Tim hloubka rekurzivniho stacku nikdy neprekroci O(log n).
//Bonus č. 4
//U silne asymetrickych posloupnosti s extremnimi vykyvy (anomaliemi). pr.: { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1000} Median je 5.5 (stred), ale prumer je 104.5 (ovlivneny cislem 1000).
