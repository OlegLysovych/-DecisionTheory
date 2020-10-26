using System;
using System.Collections.Generic;

namespace fourth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tHello World!");
            Console.WriteLine("\tHere we make desicion with Delphi method");

            Reader read = new Reader();

            List<string> Automobiles = read.ReadListOfStringFromFile("Automobiles.txt");
            List<double> Weights = read.ReadListOfDoubleFromFile("Koeficient.txt");
            List<string> Parametres = read.ReadListOfStringFromFile("Parametres.txt");
            int[,] Points = read.ReadMatrixFromFile("Points.txt");
            Outputer.OutputMyTask(Automobiles,Parametres,Points,Weights);

            Count counter = new Count(Weights, Points, Automobiles, Parametres);
            var points = counter.CountEachParameterForEachCar();
            
            Outputer.OutputMyTask(Automobiles,Parametres,Points,Weights, points);
            System.Console.WriteLine();

            counter.SumCarPoints(points).ForEach(x => {
                System.Console.WriteLine($"{x.Item1} has {x.Item2:0.00} Points");
            });            
            System.Console.WriteLine();

            counter.ParameterMaximum(points).ForEach(x => {
                System.Console.WriteLine($"{x.Item1} has {x.Item2} maximum value");
            });
        }
    }
}
