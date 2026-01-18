namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static bool JeSpravneUzavorkovani(string vyraz)
            {
                Stack<char> zasobnik = new Stack<char>();

                for (int i = 0; i < vyraz.Length; i++)
                {
                    char znak = vyraz[i];

                    if (znak == '(' || znak == '[' || znak == '{')
                    {
                        zasobnik.Push(znak);
                    }
                    else if (znak == ')' || znak == ']' || znak == '}')
                    {
                        if (zasobnik.Count == 0)
                        {
                            return false;
                        }

                        char oteviraci = zasobnik.Pop();

                        if (znak == ')' && oteviraci != '(') return false;
                        if (znak == ']' && oteviraci != '[') return false;
                        if (znak == '}' && oteviraci != '{') return false;
                    }
                }

                return zasobnik.Count == 0;
            }

            static void Uloha1()
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("  ÚLOHA 1: Kontrola uzávorkování");
                Console.WriteLine("========================================\n");

                while (true)
                {
                    Console.Write("Zadej výraz se závorkami (nebo 'x' pro konec): ");
                    string vstup = Console.ReadLine();

                    if (vstup == "x" || vstup == "X" || vstup == "")
                    {
                        break;
                    }

                    bool spravne = JeSpravneUzavorkovani(vstup);

                    if (spravne)
                    {
                        Console.WriteLine("-> SPRÁVNĚ uzávorkováno! ✓\n");
                    }
                    else
                    {
                        Console.WriteLine("-> ŠPATNĚ uzávorkováno! ✗\n");
                    }
                }
            }

            static void NajdiRozklady(int zbyvajici, int maxScitanec, Stack<int> zasobnik, ref int pocet)
            {
                if (zbyvajici == 0)
                {
                    pocet++;

                    int[] rozklad = zasobnik.ToArray();
                    Array.Reverse(rozklad);

                    Console.Write($"  {pocet}. ");
                    for (int i = 0; i < rozklad.Length; i++)
                    {
                        Console.Write(rozklad[i]);
                        if (i < rozklad.Length - 1)
                        {
                            Console.Write(" + ");
                        }
                    }
                    Console.WriteLine();

                    return;
                }

                for (int scitanec = Math.Min(zbyvajici, maxScitanec); scitanec >= 1; scitanec--)
                {
                    zasobnik.Push(scitanec);
                    NajdiRozklady(zbyvajici - scitanec, scitanec, zasobnik, ref pocet);
                    zasobnik.Pop();
                }
            }

            static void Uloha2()
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("  ÚLOHA 2: Rozklad na sčítance");
                Console.WriteLine("========================================\n");

                while (true)
                {
                    Console.Write("Zadej kladné celé číslo (nebo 0 pro konec): ");
                    string vstup = Console.ReadLine();

                    int cislo;

                    if (!int.TryParse(vstup, out cislo))
                    {
                        Console.WriteLine("-> To není platné číslo! Zkus to znovu.\n");
                        continue;
                    }

                    if (cislo == 0)
                    {
                        break;
                    }

                    if (cislo < 0)
                    {
                        Console.WriteLine("-> Číslo musí být kladné! Zkus to znovu.\n");
                        continue;
                    }

                    Console.WriteLine($"\nRozklady čísla {cislo}:");
                    Stack<int> zasobnik = new Stack<int>();
                    int pocet = 0;
                    NajdiRozklady(cislo, cislo, zasobnik, ref pocet);
                    Console.WriteLine($"-> Celkem: {pocet} rozkladů\n");
                }
            }

            static void Main()
            {
               Console.OutputEncoding = System.Text.Encoding.UTF8;

               Console.Clear();
               Console.WriteLine("\n╔════════════════════════════════════════╗");
               Console.WriteLine("║     BONUSOVÉ ÚLOHY - ZÁSOBNÍK          ║");
               Console.WriteLine("╚════════════════════════════════════════╝");

               while (true)
                {
                Console.WriteLine("\nVyber úlohu:");
                Console.WriteLine("  1 - Kontrola uzávorkování");
                Console.WriteLine("  2 - Rozklad na sčítance");
                Console.WriteLine("  0 - Konec programu");
                Console.Write("\nTvá volba: ");

                string volba = Console.ReadLine();

                if (volba == "1")
                {
                  Uloha1();
                }
                else if (volba == "2")
                {
                 Uloha2();
                }
                else if (volba == "0")
                {
                 Console.WriteLine("\nDěkuji za použití programu. Nashledanou!");
                 break;
                }
                else
                {
                 Console.WriteLine("\nNeplatná volba! Zkus to znovu.");
                }
                }
            }
        }
    }
}
