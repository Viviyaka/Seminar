namespace ConsoleApp4
{
    internal class Program
    {
        class KinoRezervace
        {
            const int POCET_RAD = 8;
            const int POCET_SEDADEL = 10;
            const int ZAKLADNI_CENA = 180;
            const int VIP_PRIPLATEK = 70;
            const int PRVNI_VIP_RADA = 7;

            static bool[,] obsazena = new bool[POCET_RAD, POCET_SEDADEL];

            static void Main()
            {
                while (true)
                {
                    ZobrazitMenu();
                    int volba = NacistCislo("Vyberte akci: ", 1, 5);

                    if (volba == 5)
                    {
                        Console.WriteLine("Děkujeme za použití rezervačního systému!");
                        break;
                    }

                    ZpracovatVolbu(volba);
                }
            }

            static void ZobrazitMenu()
            {
                Console.WriteLine("\n=== REZERVAČNÍ SYSTÉM KINA ===");
                Console.WriteLine("1. Zobrazit kinosál");
                Console.WriteLine("2. Rezervovat sedadlo");
                Console.WriteLine("3. Zkontrolovat dostupnost sedadla");
                Console.WriteLine("4. Zobrazit ceník");
                Console.WriteLine("5. Ukončit");
            }

            static void ZpracovatVolbu(int volba)
            {
                switch (volba)
                {
                    case 1:
                        ZobrazitKinosal();
                        break;
                    case 2:
                        RezorovatSedadlo();
                        break;
                    case 3:
                        ZkontrolovatDostupnost();
                        break;
                    case 4:
                        ZobrazitCenik();
                        break;
                }
            }

            static void ZobrazitKinosal()
            {
                Console.WriteLine("\n=== KINOSÁL ===");
                Console.WriteLine("       PLÁTNO");
                Console.WriteLine();

                for (int rada = 0; rada < POCET_RAD; rada++)
                {
                    Console.Write($"Řada {rada + 1}: ");

                    for (int sedadlo = 0; sedadlo < POCET_SEDADEL; sedadlo++)
                    {
                        string symbol = obsazena[rada, sedadlo] ? "X" : "O";
                        Console.Write(symbol + " ");
                    }

                    if (JeVipRada(rada + 1))
                    {
                        Console.Write(" (VIP)");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("\nO = volné, X = obsazené");
            }

            static void RezorovatSedadlo()
            {
                int rada = NacistCislo("Zadejte číslo řady: ", 1, POCET_RAD);
                int sedadlo = NacistCislo("Zadejte číslo sedadla: ", 1, POCET_SEDADEL);

                if (JeSedadloObsazene(rada, sedadlo))
                {
                    Console.WriteLine("Toto sedadlo je již obsazené!");
                    return;
                }

                OznacitJakoObsazene(rada, sedadlo);
                int cena = VypoctitatCenu(rada);

                Console.WriteLine($"\nRezervace úspěšná!");
                Console.WriteLine($"Řada {rada}, sedadlo {sedadlo}");
                Console.WriteLine($"Cena: {cena} Kč");
            }

            static void ZkontrolovatDostupnost()
            {
                int rada = NacistCislo("Zadejte číslo řady: ", 1, POCET_RAD);
                int sedadlo = NacistCislo("Zadejte číslo sedadla: ", 1, POCET_SEDADEL);

                if (JeSedadloObsazene(rada, sedadlo))
                {
                    Console.WriteLine("Sedadlo je obsazené.");
                }
                else
                {
                    Console.WriteLine("Sedadlo je volné.");
                    Console.WriteLine($"Cena: {VypoctitatCenu(rada)} Kč");
                }
            }

            static void ZobrazitCenik()
            {
                Console.WriteLine("\n=== CENÍK ===");
                Console.WriteLine($"Standardní sedadlo (řady 1-6): {ZAKLADNI_CENA} Kč");
                Console.WriteLine($"VIP sedadlo (řady {PRVNI_VIP_RADA}-{POCET_RAD}): {ZAKLADNI_CENA + VIP_PRIPLATEK} Kč");
            }

            static int NacistCislo(string vyzva, int min, int max)
            {
                while (true)
                {
                    Console.Write(vyzva);
                    string vstup = Console.ReadLine();

                    if (!int.TryParse(vstup, out int cislo))
                    {
                        Console.WriteLine("Neplatný vstup. Zadejte číslo.");
                        continue;
                    }

                    if (!JeCisloVRozsahu(cislo, min, max))
                    {
                        Console.WriteLine($"Číslo musí být mezi {min} a {max}.");
                        continue;
                    }

                    return cislo;
                }
            }

            static bool JeCisloVRozsahu(int cislo, int min, int max)
            {
                return cislo >= min && cislo <= max;
            }

            static bool JeSedadloObsazene(int rada, int sedadlo)
            {
                return obsazena[rada - 1, sedadlo - 1];
            }

            static void OznacitJakoObsazene(int rada, int sedadlo)
            {
                obsazena[rada - 1, sedadlo - 1] = true;
            }

            static int VypoctitatCenu(int rada)
            {
                if (JeVipRada(rada))
                {
                    return ZAKLADNI_CENA + VIP_PRIPLATEK;
                }

                return ZAKLADNI_CENA;
            }

            static bool JeVipRada(int rada)
            {
                return rada >= PRVNI_VIP_RADA;
            }
        }
    }
}
