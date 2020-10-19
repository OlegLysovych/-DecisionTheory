using System.Collections.Generic;
using System.Linq;

namespace first
{
    public class Calculating
    {
        int[,] _array = new int[3, 3];
        List<int> maximusFromRow;
        List<int> minimumsFromRow;
        List<double> HurwitzRowResults;
        List<double> BayesLaplaceRowResults;
        public Calculating(int[,] array)
        {
            _array = array;
        }
        //Критерій Вальда відповідає песимістичній оцінці:
        //вибирається та альтернатива, для якої песимістична оцінка найбільша, тобто максимум з мінімумів, краща з гірших:
        public List<int> PessimisticWald()
        {
            minimumsFromRow = eachRowMinimum(3, 3);
            // int MaximumFromRowsMinimums = minimumsFromRow.Max();
            return minimumsFromRow;
        }
        //Згідно максимаксному критерію вибирається альтернатива з найбільшою оптимістичною оцінкою (краща з кращих):
        public List<int> OptimistricMaximum()
        {
            maximusFromRow = eachRowMaximum(3, 3);
            // int MaximumFromRowsMaximus = array.Cast<int>().Max();
            return maximusFromRow;
        }
        //Згідно критерію Гурвіця вибирається коефіцієнт оптимізму 0 ≤ α ≤ 1. Виберемо коефіцієнт оптимізму α = 0,3
        public List<double> Hurwitz()
        {
            HurwitzRowResults = HurwitzCalculating(3);
            return HurwitzRowResults;
        }

        //Критерій Байєса-Лапласа рівний математичному очікуванню прибутку. 
        //Вибирається та альтернатива, для якої значення критерію максимальне
        public List<double> BayesLaplace(double p1, double p2, double p3)
        {
            BayesLaplaceRowResults = BayesLaplaceCalculating(3,p1,p2,p3);
            return BayesLaplaceRowResults;
        }

        private List<double> BayesLaplaceCalculating(int row, double p1, double p2, double p3)
        {
            List<double> BayesLaplaceRows = new List<double>();

            for (int i = 0; i < row; i++)
            {
                double item = 
                                p1 * _array[i, 0] + 
                                p2 * _array[i, 1] + 
                                p3 * _array[i, 2];
                BayesLaplaceRows.Add(item);
            }
            return BayesLaplaceRows;
        }

    private List<double> HurwitzCalculating(int row)
    {
        List<double> HurwitzRows = new List<double>();
        double coefficient = 0.3;
        List<int> maximusFromRowForHurwitz = OptimistricMaximum();
        List<int> minimumsFromRowForHurwitz = PessimisticWald();
        for (int i = 0; i < row; i++)
        {
            double item = (coefficient * maximusFromRowForHurwitz.ElementAt(i)) +
                            ((1 - coefficient) * minimumsFromRowForHurwitz.ElementAt(i));
            HurwitzRows.Add(item);
        }
        return HurwitzRows;
    }

    private List<int> eachRowMinimum(int row, int column)
    {
        List<int> eachRowMinimum = new List<int>();
        for (int i = 0; i < row; i++)
        {
            // initialize the minimum element 
            // as first element 
            int minm = _array[i, 0];

            for (int j = 1; j < column; j++)
            {
                // check if any element is smaller 
                // than the minimum element of the row  
                // and replace it 
                if (_array[i, j] < minm)
                    minm = _array[i, j];
            }
            eachRowMinimum.Add(minm);
        }
        return eachRowMinimum;
    }
    private List<int> eachRowMaximum(int row, int column)
    {
        List<int> eachRowMaximum = new List<int>();
        for (int i = 0; i < row; i++)
        {
            // initialize the max element 
            // as first element 
            int max = _array[i, 0];

            for (int j = 1; j < column; j++)
            {
                // check if any element is smaller 
                // than the max element of the row  
                // and replace it 
                if (_array[i, j] > max)
                    max = _array[i, j];
            }
            eachRowMaximum.Add(max);
        }
        return eachRowMaximum;
    }
}
}