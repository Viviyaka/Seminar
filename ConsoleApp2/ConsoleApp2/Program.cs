namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int PocetLidi = Convert.ToInt32(Console.ReadLine());
            int[,] Matice = new int[PocetLidi, PocetLidi];

            string VstupniData = Console.ReadLine();
            string[] dvojice = VstupniData.Split();

            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] SeznamDvojic = dvojice[i].Split('-');
                int Vrchol1 = Convert.ToInt32(SeznamDvojic[0]);
                int Vrchol2 = Convert.ToInt32(SeznamDvojic[1]);

                Console.WriteLine(Vrchol1 + "," + Vrchol2); 
                i++;

                Matice[Vrchol1, Vrchol2] = 1;
                Matice[Vrchol2, Vrchol1] = 1;
            }
            for (int i = 0; i < PocetLidi; i++) 
            {
                for (int j = 0; j < PocetLidi; j++) 
                {
                    Console.Write($"{Matice[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
