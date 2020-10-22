using System.Collections.Generic;

namespace second
{
    public class Calculate
    {
        double[,] _array = new double[4, 6];
        List<double> income;
        List<double> profit; 

        public Calculate(double[,] array)
        {
            _array = array;
        }
        //Обраховується дохід для кожного можливого варіанту рішень
        public List<double> IncomeOneBranchTreeCalculating()
        {
            income = new List<double>();
            //Добавляємо в список дохід для кожного рішення. Одне рішення це один рядок масиву. Цикл проходить в по рядкам масиву
            //формула =  "ймовірність * прибуток - ймовірність * збитки"
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                income.Add(_array[i,0]*(_array[i,2] * _array[i,3] - _array[i,4] * _array[i,5]));
            }
            return income;
        }
        //Обраховується чистий прибуток при кожному можливому рішенні.
        public List<double> ProfitOneBranchTreeCalculating(List<double> _income)
        {
            profit = new List<double>();
            for (int i = 0; i < _array.GetLength(0); i++)//Для кожного рядка масиву(кожного можливого рішення)
            {
                if( i == 2 || i ==3)
                {
                    //Прибуток з побудови великого заводу за 4 роки і додаткових дослідженнях 1 рік
                    //Дохід(список доходу) - вкладені кошти(другий стовпець масиву)
                    profit.Add(_income[i] * 4 -_array[i,1]);
                }else
                    //Прибуток з великого і малого заводу за 5 років
                    profit.Add(_income[i] * 5 -_array[i,1]);
            }
            return profit;
        }

    }
}