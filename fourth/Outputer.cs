using System.Collections.Generic;

namespace fourth
{
    public static class Outputer
    {
        public static void OutputMyTask(List<string> AutomobiliesList, List<string> Parameters, int[,] Points, List<double> Weight)
        {
            System.Console.WriteLine("\tTask:\n");
            System.Console.Write("Parameters\tWeight\t");
            AutomobiliesList.ForEach(x =>
            {
                System.Console.Write($"{x}\t ");
            });
            System.Console.WriteLine();
            for (int r = 0; r < Points.GetLength(0); r++)
            {
                System.Console.Write($"{Parameters[r]}   \t");
                System.Console.Write($"{Weight[r]}\t");

                for (int c = 0; c < Points.GetLength(1); c++)
                {
                    System.Console.Write($"{Points[r, c]}\t\t");
                }
                System.Console.WriteLine();
            }
        }
        public static void OutputMyTask(List<string> AutomobiliesList, List<string> Parameters, int[,] Points,
                                        List<double> Weight, List<(string, string, double)> ListTulpe)
        {
            System.Console.WriteLine("\nAfter Calculating:\n");
            System.Console.Write("Parameters\tWeight\t");
            AutomobiliesList.ForEach(x =>
            {
                System.Console.Write($"{x}\t ");
            });
            System.Console.WriteLine();
            for (int r = 0; r < Points.GetLength(0); r++)
            {
                System.Console.Write($"{Parameters[r]}   \t");
                System.Console.Write($"{Weight[r]}\t");

                for (int c = 0; c < Points.GetLength(1); c++)
                {
                    if (r == 0)
                        System.Console.Write("{0:0.00}\t\t",ListTulpe[c].Item3);
                    else if (r == 1)
                        System.Console.Write("{0:0.00}\t\t",ListTulpe[c+5].Item3);
                    else if (r == 2)
                        System.Console.Write("{0:0.00}\t\t",ListTulpe[c+10].Item3);
                    else if (r == 3)
                        System.Console.Write("{0:0.00}\t\t",ListTulpe[c+15].Item3);
                    else if (r == 4)
                        System.Console.Write("{0:0.00}\t\t",ListTulpe[c+20].Item3);
                }
                System.Console.WriteLine();
            }
        }
    }
}