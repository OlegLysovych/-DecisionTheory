using System;
using System.Linq;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tHello World!");
            Console.WriteLine("\tHere we count some choice under uncertainty");

            string path = "data.txt";
            reader read = new reader(path);
            int[,] array = read.ReadMatrixTaskFromFile();

            Calculating calculating = new Calculating(array);

            System.Console.WriteLine($"Pessimictic values from each row:\t");
            calculating.PessimisticWald().ForEach(Console.WriteLine);
            System.Console.WriteLine($"Maximum of pessimictic values:\t {calculating.PessimisticWald().Max()}\n");
            
            System.Console.WriteLine($"Optimistic values from each row:\t");
            calculating.OptimistricMaximum().ForEach(Console.WriteLine);
            System.Console.WriteLine($"Maximum of optimistic values:\t {calculating.OptimistricMaximum().Max()}\n");
            
            System.Console.WriteLine($"Hurwitz values from each row:\t");
            calculating.Hurwitz().ForEach(Console.WriteLine);
            System.Console.WriteLine($"Maximum of Hurwitz values:\t {calculating.Hurwitz().Max()}\n");

            double p1 = 0.5; double p2 = 0.35; double p3 = 0.15;            
            System.Console.WriteLine($"BayesLaplace values from each row:\t");
            calculating.BayesLaplace(p1,p2,p3).ForEach(Console.WriteLine);
            System.Console.WriteLine($"Maximum of BayesLaplace values\t {calculating.BayesLaplace(p1,p2,p3).Max()}\n");
            
            Console.ReadLine();
        }
    }
}
