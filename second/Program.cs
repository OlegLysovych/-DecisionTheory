using System;

namespace second
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tHello World!");
            Console.WriteLine("\tHere we count some choice with Tree desicion\n");

            string path = "data.txt";
            Reader read = new Reader(path);
            var array = read.ReadMatrixTaskFromFile();   

            Calculate calculate = new Calculate(array);
            System.Console.WriteLine();
            var income = calculate.IncomeOneBranchTreeCalculating();
            var profit = calculate.ProfitOneBranchTreeCalculating(income);
            for (int r = 0; r < income.Count; r++)
            {
                System.Console.Write($"Income from {read.Factory[r]} :\t {income[r]}\n"); 
            }
            System.Console.WriteLine("\n");
            for (int r = 0; r < profit.Count; r++)
            {
                System.Console.Write($"Profit from {read.Factory[r]} :\t {profit[r]}\n");
            }
        }
    }
}
