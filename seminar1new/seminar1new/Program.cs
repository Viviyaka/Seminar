namespace seminar1new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsValue = 0;

            Console.Write("Pocet studentu: ");
            studentsValue = int.Parse(Console.ReadLine());

            string[] studentsName = new string[studentsValue];
            int[] studentsAge = new int[studentsValue];
            float[] studentsMark = new float[studentsValue];

            for (int i = 0; i < studentsValue; i++)
            {
                Console.WriteLine("---");
                Console.Write($"Napiste jmeno studenta {i + 1}: ");
                studentsName[i] = Console.ReadLine();
                Console.Write($"Napiste vek studenta {i + 1}: ");
                studentsAge[i] = int.Parse(Console.ReadLine());
                Console.Write($"Napiste prumernou znamku studenta {i + 1}: ");
                studentsMark[i] = float.Parse(Console.ReadLine());
                Console.WriteLine("---");
            }

            StudentsList();

        void StudentsList()
        {
            Console.WriteLine("");
            Console.WriteLine("a: Vsechny studenty ");
            Console.WriteLine("b: Vsechny studenty ktere maji prumernou znamku lepsi nez 2 ");
            Console.WriteLine("c: Prumerny vek vsech studentu ");
            Console.WriteLine("d: Ukoncit program");
            Console.Write("Vyberte co chcete udelat: ");

            string worldValue = Console.ReadLine();

            if (worldValue == "a")
            {
                for (int i = 0; i < studentsValue; i++)
                {
                    Console.WriteLine($"{studentsName[i]} ({studentsAge[i]}): {studentsMark[i]}");
                }
            }
            else if (worldValue == "b")
            {
                for (int i = 0; i < studentsValue; i++)
                {
                    if (studentsMark[i] < 2.0)
                    {
                        Console.WriteLine($"{studentsName[i]} ({studentsAge[i]}): {studentsMark[i]}");

                    }
                }
            }
            else if (worldValue == "c")
            {
                float middleAge = 1.0f;
                int summAge = 0;

                for (int i = 0; i < studentsValue; i++)
                {
                    summAge += studentsAge[i];
                }

                middleAge = summAge / studentsValue;
                Console.WriteLine($"Prumerny vek: {middleAge}");


            }
            else if (worldValue == "d")
            {
                Environment.Exit(0);
            }

            if (worldValue != "d")
            {
                StudentsList();
            }
        }

            while (true)
            {
            }
        }
    }
}