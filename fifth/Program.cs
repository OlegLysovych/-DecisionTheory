using System;

namespace fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tHello World!");
            Console.WriteLine("\tHere we make desicion with Normal-form game");

            Reader read = new Reader();

            int[,] matrix = read.ReadMatrixFromFile("dataSet.txt");
            Outputer.OutputMyTask(matrix);

            SaddlePoint saddlePoint = new SaddlePoint(matrix);

            System.Console.WriteLine($"\n\tIs there a saddle pont? \t {saddlePoint.IsThereASaddlePoint()}\n");
            System.Console.Write($"\tHere we have a poor strategy for : \n\tA\t {saddlePoint.MaxiMinStrategyForRow} in {Indexer.CoordinatesOf(matrix, saddlePoint.MaxiMinStrategyForRow)} \n\tB\t{saddlePoint.MiniMaxStrategyForCol} in {Indexer.CoordinatesOf(matrix, saddlePoint.MiniMaxStrategyForCol)}");
            ReduceDimencsonOfMatrix reducing = new ReduceDimencsonOfMatrix(matrix);

            var ListOfCalculationCols = reducing.CalculateReduceColsDimension();
            System.Console.WriteLine($"\n\tIs there need to reduse columns? \t {reducing.IsNeedToReduseCols()}");

            var ListOfCalculationRows = reducing.CalculateReduceColsDimension();
            System.Console.WriteLine($"\n\tIs there need to reduse rows? \t {reducing.IsNeedToReduseCols()}");

            MixedStrategy mixed = new MixedStrategy(matrix);
            System.Console.WriteLine(" % for each solution for B");
            mixed.SolveLinearForRow();
            System.Console.WriteLine(" % for each solution for A");
            mixed.SolveLinearForCol();
        }
    }
}
