namespace Strom
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "65 3 5 * - 2 3 + /";
            string[] exp = expression.Split();
            Stack<Uzel> uzly = new Stack<Uzel>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (double.TryParse(exp[i], out double value))
                {
                    Uzel uzel = new Uzel(value);
                    uzly.Push(uzel);
                }
                else
                {
                    Uzel pravySyn = uzly.Pop();
                    Uzel levySyn = uzly.Pop();
                    Uzel uzel = new Uzel(exp[i], levySyn, pravySyn);
                    uzly.Push(uzel);
                }
            }
            Uzel koren = uzly.Pop();

            StringBuilder sbPrefix = new StringBuilder();
            StringBuilder sbInfix = new StringBuilder();
            StringBuilder sbPostfix = new StringBuilder();

            GenerujPrefix(koren, sbPrefix);
            GenerujInfix(koren, sbInfix);
            GenerujPostfix(koren, sbPostfix);

            Console.WriteLine("> " + sbPrefix.ToString().Trim());
            Console.WriteLine("> " + sbInfix.ToString().Trim());
            Console.WriteLine("> " + sbPostfix.ToString().Trim());

            double vysledek = VyhodnotStrom(koren);
            Console.WriteLine("> " + vysledek.ToString(System.Globalization.CultureInfo.InvariantCulture));

            // BONUS (+50b):
            Console.WriteLine("\nVykresleny vyrazovy strom:");
            VykresliStrom(koren, "", true);
        }
        static void GenerujPrefix(Uzel uzel, StringBuilder sb)
        {
            if (uzel == null) return;

            sb.Append(uzel.ToString()).Append(" ");
            GenerujPrefix(uzel.LevySyn, sb);
            GenerujPrefix(uzel.PravySyn, sb);
        }

        static void GenerujInfix(Uzel uzel, StringBuilder sb)
        {
            if (uzel == null) return;

            bool jeOperator = uzel.LevySyn != null;

            if (jeOperator) sb.Append("(");

            GenerujInfix(uzel.LevySyn, sb);

            if (jeOperator) sb.Append(" ").Append(uzel.ToString()).Append(" ");
            else sb.Append(uzel.ToString());

            GenerujInfix(uzel.PravySyn, sb);

            if (jeOperator) sb.Append(")");
        }
        static void GenerujPostfix(Uzel uzel, StringBuilder sb)
        {
            if (uzel == null) return;

            GenerujPostfix(uzel.LevySyn, sb);
            GenerujPostfix(uzel.PravySyn, sb);
            sb.Append(uzel.ToString()).Append(" ");
        }

        static double VyhodnotStrom(Uzel uzel)
        {
            if (uzel.LevySyn == null && uzel.PravySyn == null)
            {
                return uzel.Cislo;
            }

            double levaStrana = VyhodnotStrom(uzel.LevySyn);
            double pravaStrana = VyhodnotStrom(uzel.PravySyn);

            if (uzel.Operator == "+") return levaStrana + pravaStrana;
            if (uzel.Operator == "-") return levaStrana - pravaStrana;
            if (uzel.Operator == "*") return levaStrana * pravaStrana;
            if (uzel.Operator == "/") return levaStrana / pravaStrana;

            return 0;
        }

        // Vykresleni stromu do konzole pomoci textovych vetvi
        static void VykresliStrom(Uzel uzel, string odsazeni, bool jeLevy)
        {
            if (uzel == null) return;

            VykresliStrom(uzel.PravySyn, odsazeni + (jeLevy ? "│   " : "    "), false);

            Console.Write(odsazeni);
            Console.Write(jeLevy ? "└── " : "┌── ");
            Console.WriteLine(uzel.ToString());

            VykresliStrom(uzel.LevySyn, odsazeni + (jeLevy ? "    " : "│   "), true);
        }
    }

    class Uzel
    {
        public Uzel LevySyn { get; set; }
        public Uzel PravySyn { get; set; }
        public double Cislo { get; set; }
        public string Operator { get; set; }
        public Uzel(double cislo)
        {
            Cislo = cislo;
            LevySyn = null;
            PravySyn = null;
        }
        public Uzel(string op, Uzel levy, Uzel pravy)
        {
            Operator = op;
            LevySyn = levy;
            PravySyn = pravy;
        }

        // Technicky tip 1: prepsani systemove funkce ToString()
        public override string ToString()
        {
            if (LevySyn == null)
                return Cislo.ToString(System.Globalization.CultureInfo.InvariantCulture);
            else
                return Operator;
        }
    }
}