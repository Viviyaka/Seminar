namespace Abeceda
{
    internal class Program
    {
        static void Main()
        {
            string vstup = Console.ReadLine();
            string[] useky = vstup.Split(' ');

            int MaxPocetPismen = 26;
            int A = 97;

            List<int>[] graf = new List<int>[MaxPocetPismen];
            int[] Predchudci = new int[MaxPocetPismen];
            bool[] exist = new bool[MaxPocetPismen];

            for (int i = 0; i < MaxPocetPismen; i++)
                graf[i] = new List<int>();

            foreach (string slovo in useky)
            {
                foreach (char znak in slovo)
                {
                    exist[znak - A] = true;
                }
            }
            for (int i = 0; i < useky.Length - 1; i++)
            {
                string slovo1 = useky[i];
                string slovo2 = useky[i + 1];

                int minimum = Math.Min(slovo1.Length, slovo2.Length);
                for (int j = 0; j < minimum; j++)
                {
                    if (slovo1[j] != slovo2[j])
                    {
                        int u = slovo1[j] - A;
                        int v = slovo2[j] - A;

                        if (!graf[u].Contains(v))
                        {
                            graf[u].Add(v);
                            Predchudci[v]++;
                        }

                        break;
                    }
                }
            }

            Queue<int> fronta = new Queue<int>();

            for (int i = 0; i < MaxPocetPismen; i++)
            {
                if (exist[i] && Predchudci[i] == 0)
                    fronta.Enqueue(i);
            }

            List<int> vysledek = new List<int>();
            while (fronta.Count > 0)
            {
                int vrchol = fronta.Dequeue();
                vysledek.Add(vrchol);

                foreach (int soused in graf[vrchol])
                {
                    Predchudci[soused]--;

                    if (Predchudci[soused] == 0)
                        fronta.Enqueue(soused);
                }
            }

            int pocetZnaku = 0;
            for (int i = 0; i < MaxPocetPismen; i++)
                if (exist[i])
                    pocetZnaku++;

            if (vysledek.Count != pocetZnaku)
            {
                Console.WriteLine("error");
            }
            else
            {
                for (int i = 0; i < vysledek.Count; i++)
                {
                    Console.Write((char)(vysledek[i] + A));

                    if (i < vysledek.Count - 1)
                        Console.Write(" -> ");
                }
            }
        }
    }
}
