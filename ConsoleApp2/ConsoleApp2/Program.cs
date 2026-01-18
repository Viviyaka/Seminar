namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
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
=======
            int pocetUzivatelu = int.Parse(Console.ReadLine());

            List<int>[] pratele = new List<int>[pocetUzivatelu + 1];

            for (int i = 0; i <= pocetUzivatelu; i++)
            {
                pratele[i] = new List<int>();
            }

            string radekSPratelstvy = Console.ReadLine();

            string[] vsechnaPratelstvi = radekSPratelstvy.Split(' ');

            foreach (string pratelstvi in vsechnaPratelstvi)
            {
                string[] uzivatele = pratelstvi.Split('-');
                int uzivatel1 = int.Parse(uzivatele[0]);
                int uzivatel2 = int.Parse(uzivatele[1]);

                pratele[uzivatel1].Add(uzivatel2);
                pratele[uzivatel2].Add(uzivatel1);
            }

            string[] dotaz = Console.ReadLine().Split(' ');
            int zacatek = int.Parse(dotaz[0]);
            int konec = int.Parse(dotaz[1]);

            List<int> cesta = NajdiCestu(pratele, pocetUzivatelu, zacatek, konec);

            if (cesta != null)
            {
                Console.WriteLine(string.Join(" ", cesta));
            }
            else
            {
                Console.WriteLine("neexistuje");
            }
        }

        static List<int> NajdiCestu(List<int>[] pratele, int pocetUzivatelu, int zacatek, int konec)
        {
            if (zacatek == konec)
            {
                return new List<int> { zacatek };
            }

            Queue<int> fronta = new Queue<int>();


            bool[] navstiveno = new bool[pocetUzivatelu + 1];

            int[] odkud = new int[pocetUzivatelu + 1];
            for (int i = 0; i <= pocetUzivatelu; i++)
            {
                odkud[i] = -1;
            }

            fronta.Enqueue(zacatek);
            navstiveno[zacatek] = true;


            while (fronta.Count > 0)
            {

                int aktualniUzivatel = fronta.Dequeue();

                foreach (int pritel in pratele[aktualniUzivatel])
                {
                    if (!navstiveno[pritel])
                    {
                        navstiveno[pritel] = true;

                        odkud[pritel] = aktualniUzivatel;

                        fronta.Enqueue(pritel);

                        if (pritel == konec)
                        {
                            return SestrojCestu(odkud, zacatek, konec);
                        }
                    }
                }
            }

            return null;
        }

        static List<int> SestrojCestu(int[] odkud, int zacatek, int konec)
        {
            List<int> cesta = new List<int>();
            int aktualni = konec;

            while (aktualni != -1)
            {
                cesta.Add(aktualni);
                aktualni = odkud[aktualni];
            }

            cesta.Reverse();

            return cesta;
>>>>>>> Stashed changes
        }
    }
}
