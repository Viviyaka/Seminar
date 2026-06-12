namespace Notace
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Zadej prefix nebo postfix: ");
            string volba = Console.ReadLine().ToLower().Replace("'", "").Replace("\"", "").Trim();

            Console.WriteLine("Zadej vyraz (casti oddelene mezerou):");
            string input = Console.ReadLine();

            string[] tokeny = input.Split(' ');

            if (volba == "postfix")
            {
                VyhodnotPostfix(tokeny);
            }
            else if (volba == "prefix")
            {
                VyhodnotPrefix(tokeny);
            }
            else
            {
                Console.WriteLine("Neplatna volba!");
            }
        }

        static void VyhodnotPostfix(string[] tokeny)
        {
            Stack<double> zasobnikCisel = new Stack<double>();
            // BONUS 40b: Zasobnik pro sestaveni infixoveho textu se zavorkami
            Stack<string> zasobnikInfixu = new Stack<string>();
            Stack<int> prioritaZasobnik = new Stack<int>();

            for (int i = 0; i < tokeny.Length; i++)
            {
                string t = tokeny[i];

                if (JeOperator(t))
                {
                    if (zasobnikCisel.Count < 2)
                    {
                        Console.WriteLine("> Neplatny vyraz: chybi operand/y");
                        return;
                    }

                    double b = zasobnikCisel.Pop();
                    double a = zasobnikCisel.Pop();

                    if (t == "/" && b == 0)
                    {
                        Console.WriteLine("> Deleni nulou neni definovano!");
                        return;
                    }

                    double vysledek = Spocti(a, b, t);
                    zasobnikCisel.Push(vysledek);

                    // BONUS 40b: Vytahneme i textove podvyrazy a obalime je zavorkami
                    string infixB = zasobnikInfixu.Pop();
                    string infixA = zasobnikInfixu.Pop();

                    int prioritaB = prioritaZasobnik.Pop();
                    int prioritaA = prioritaZasobnik.Pop();
                    int aktualniPriorita = ZiskejPrioritu(t);

                    if (prioritaA < aktualniPriorita && prioritaA != 0) infixA = "(" + infixA + ")";
                    if (prioritaB <= aktualniPriorita && prioritaB != 0) infixB = "(" + infixB + ")";

                    string novyInfix = infixA + " " + t + " " + infixB;
                    zasobnikInfixu.Push(novyInfix);
                    prioritaZasobnik.Push(aktualniPriorita);
                }
                else
                {
                    if (double.TryParse(t, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double cislo))
                    {
                        zasobnikCisel.Push(cislo);
                        zasobnikInfixu.Push(t);
                        prioritaZasobnik.Push(0);
                    }
                    else
                    {
                        Console.WriteLine("> Neplatny prvek ve vyrazu");
                        return;
                    }
                }
            }

            if (zasobnikCisel.Count > 1)
            {
                Console.WriteLine("> Neplatny vyraz: chybi operator/y");
                return;
            }

            Console.WriteLine("> " + zasobnikInfixu.Pop());
            Console.WriteLine("> " + zasobnikCisel.Pop());
        }

        //BONUS 20b: VYHODNOCENI PREFIXU 
        static void VyhodnotPrefix(string[] tokeny)
        {
            Stack<double> zasobnikCisel = new Stack<double>();
            Stack<string> zasobnikInfixu = new Stack<string>();
            Stack<int> prioritaZasobnik = new Stack<int>();

            for (int i = tokeny.Length - 1; i >= 0; i--)
            {
                string t = tokeny[i];

                if (JeOperator(t))
                {
                    if (zasobnikCisel.Count < 2)
                    {
                        Console.WriteLine("> Neplatny vyraz: chybi operand/y");
                        return;
                    }

                    double a = zasobnikCisel.Pop();
                    double b = zasobnikCisel.Pop();

                    if (t == "/" && b == 0)
                    {
                        Console.WriteLine("> Deleni nulou neni definovano!");
                        return;
                    }

                    double vysledek = Spocti(a, b, t);
                    zasobnikCisel.Push(vysledek);

                    string infixA = zasobnikInfixu.Pop();
                    string infixB = zasobnikInfixu.Pop();

                    int prioritaA = prioritaZasobnik.Pop();
                    int prioritaB = prioritaZasobnik.Pop();
                    int aktualniPriorita = ZiskejPrioritu(t);

                    if (prioritaA < aktualniPriorita && prioritaA != 0) infixA = "(" + infixA + ")";
                    if (prioritaB < aktualniPriorita && prioritaB != 0) infixB = "(" + infixB + ")";

                    string novyInfix = infixA + " " + t + " " + infixB;
                    zasobnikInfixu.Push(novyInfix);
                    prioritaZasobnik.Push(aktualniPriorita);
                }
                else
                {
                    if (double.TryParse(t, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double cislo))
                    {
                        zasobnikCisel.Push(cislo);
                        zasobnikInfixu.Push(t);
                        prioritaZasobnik.Push(0);
                    }
                    else
                    {
                        Console.WriteLine("> Neplatny prvek ve vyrazu");
                        return;
                    }
                }
            }

            if (zasobnikCisel.Count > 1)
            {
                Console.WriteLine("> Neplatny vyraz: chybi operator/y");
                return;
            }

            Console.WriteLine("> " + zasobnikInfixu.Pop());
            Console.WriteLine("> " + zasobnikCisel.Pop());
        }

        static bool JeOperator(string t)
        {
            return t == "+" || t == "-" || t == "*" || t == "/";
        }

        static int ZiskejPrioritu(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        static double Spocti(double a, double b, string op)
        {
            if (op == "+") return a + b;
            if (op == "-") return a - b;
            if (op == "*") return a * b;
            if (op == "/") return a / b;
            return 0;
        }
    }
}