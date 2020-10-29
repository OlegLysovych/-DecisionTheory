using System.Collections.Generic;

namespace fifth
{
    public class Outputer
    {
        public static void OutputMyTask(int[,] Matrix)
        {
            System.Console.WriteLine("\tTask:\n");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    System.Console.Write($"{Matrix[r, c]}\t");
                }
                System.Console.WriteLine();
            }
        }

    }
}