using System.Collections.Generic;
using System.Linq;

namespace fourth
{
    public class Count
    {
        private readonly List<double> _weights;
        private readonly int[,] _points;
        private readonly List<string> _cars;
        private readonly List<string> _parametres;

        public Count(List<double> Weights, int[,] Points, List<string> Cars, List<string> Parametres)
        {
            _weights = Weights;
            _points = Points;
            _cars = Cars;
            _parametres = Parametres;
        }
        //Метод обрахування кількості "балів" для кожного автомобіля по кожному параметрі
        public List<(string, string, double)> CountEachParameterForEachCar()
        {
            List<(string, string, double)> CalculatedPointsWithWeight = new List<(string, string, double)>();
            for (int r = 0; r < _points.GetLength(0); r++)//Параметри = рядки
            {
                for (int c = 0; c < _points.GetLength(1); c++)//Автомобілі = стовпці
                {
                    //Добавлю в список дані: Параметр,Автомобіль,Кількість балів. Бали = вага * оцінка експерта
                    CalculatedPointsWithWeight.Add((_parametres[r], _cars[r], _points[r, c] * _weights[r]));
                }
            }
            return CalculatedPointsWithWeight;
        }
        
        //Метод для знаходження кращого автомобіля за заданими параметрами. Обраховується сума балів
        public List<(string, double)> SumCarPoints(List<(string, string, double)> CalculatedPointsWithWeight)
        {
            List<(string, double)> sumCarPoints = new List<(string, double)>();
            //Обрати із попередньо створеного списку кортежі із назвою потрібного автомобіля і додати всі його бали
            for (int i = 0; i < _cars.Count(); i++)
            {
                var Points = CalculatedPointsWithWeight
                    .Where(votes => votes.Item2.Contains(_cars[i]))//Із списку автомобілів обираю кожен
                    .Select(x => x.Item3)//обираю бали
                    .Sum();             //і сумую їх
                    sumCarPoints.Add((_cars[i], Points));//Добавляю в новий список
            }
            return sumCarPoints;
        }

        //Метод для знаходження максимального значення серед кожного параметру.
        public List<(string, double)> ParameterMaximum(List<(string, string, double)> CalculatedPointsWithWeight)
        {
            List<(string, double)> sumCarPoints = new List<(string, double)>();
            //Обрати із попередньо створеного списку кортежі із назвою потрібного параметру і знайти максимальне значення
            for (int i = 0; i < _parametres.Count(); i++)
            {
                var maximumValueFromParameter = CalculatedPointsWithWeight
                    .Where(votes => votes.Item1.Contains(_parametres[i]))
                    .Select(x => x.Item3)
                    .Max();
                    sumCarPoints.Add((_parametres[i], maximumValueFromParameter));
            }
            return sumCarPoints;
        }
    }
}