namespace tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pocet = Convert.ToInt32(Console.ReadLine());
            int[] cesty = Convert.ToInt32(Console.ReadLine().Split(" "));
            int[] dvojice = new int (cesty);
            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] seznamDvojice = dvojice[i];

                int a = Convert.ToInt32(seznamDvojice[0]) - 1;
                int b = Convert.ToInt32(seznamDvojice[1]) - 1;
                int[,] matice = new int[pocet, pocet];
                matice[a, b] = 1;
                matice[b, a] = 1;
            }

            
        }
    }
}