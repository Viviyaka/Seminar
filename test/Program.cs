using System.Data;
using System.Runtime.ConstrainedExecution;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Zapis souradice vrcholu trojuhelniku ");

            string Vstup = Console.ReadLine();

            while (true)
            {

                if (Vstup = "q")
                {
                break;
                }

             int[] Vrchol1 = new int[2];
             int[] Vrchol2 = new int[2];
             int[] Vrchol3 = new int[2];

             List<int> list = new List<int>();

             Console.WriteLine(VypocetVzdalenosti (Vrchol1, Vrchol2));
             Console.WriteLine(VypocetVzdalenosti (Vrchol2, Vrchol3));
             Console.WriteLine(VypocetVzdalenosti (Vrchol3, Vrchol1));


            }            
        }
        float VypocetVzdalenosti(int[] Vrchol1, int[] Vrchol2)
        {

            int[] Vektor = [Vrchol2[0] - Vrchol1[0], Vrchol2[1] - Vrchol1[1]];
            int[] Vzdalenost = Math.Sqrt(Math.Pow(Vektor[0],2) + Math.Pow(Vektor[1],2));
            return Vzdalenost;
        }
    }
}
//nestihla jsem to