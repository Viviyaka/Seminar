namespace seminar2new
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 6, 18, 7, 10, 22, 3, 19, 50, 31, 87, 16 };
            int maxNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }
            Console.WriteLine($"Maximalni cislo: {maxNumber}");
            Console.WriteLine("");

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int tmp_value = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tmp_value;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]}");
            }
            Console.WriteLine("");
            Console.Write("Napiste cislo: ");
            int cNumber = int.Parse(Console.ReadLine());
            int numberIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == cNumber)
                {
                    numberIndex = i;
                    break;
                }
            }

            Console.WriteLine($"Index cisla {cNumber}: {numberIndex}");


            while (true)
            {

            }
        }
    }
}