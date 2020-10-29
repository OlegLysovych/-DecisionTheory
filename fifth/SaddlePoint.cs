using System.Collections.Generic;
using System.Linq;

namespace fifth
{
    public class SaddlePoint
    {
        private readonly int[,] _martix;
        public int MaxiMinStrategyForRow;
        public int MiniMaxStrategyForCol;

        public SaddlePoint(int[,] martix)
        {
            _martix = martix;
        }
        //Вертає тру ор фолс чи є в матриці седлова точка
        public bool IsThereASaddlePoint()
        {
            if (MaxMinRow() == MinMaxCol())//Порівнюється Максімінна і Мінімаксна стратегії
            {
                return true;
            }
            return false;
        }
        // Шукаю Мінімуми в кожному рядку матриці(стратегії гравця А)
        private int MaxMinRow()
        {
            List<int> EachRowMin = new List<int>();
            List<int> EachRowMaxMin = new List<int>();

            for (int i = 0; i < _martix.GetLength(0); i++)
            {
                for (int j = 0; j < _martix.GetLength(1); j++)
                {
                    EachRowMin.Add(_martix[i, j]);
                }
                EachRowMaxMin.Add(EachRowMin.Min());//Вибираю з рядка мінімальний і добавляю в окремий список
            }
            MaxiMinStrategyForRow = EachRowMaxMin.Max();//Із списку мінімальних обирається максимальне значення (Максимінна стратегія)
            return EachRowMaxMin.Max();
        }

        // Шукаю Максимуми в кожному стовпці матриці(стратегії гравця Б)
        private int MinMaxCol()
        {
            List<int> EachColMax = new List<int>();
            List<int> EachColMinMax = new List<int>();

            for (int i = 0; i < _martix.GetLength(0); i++)
            {
                for (int j = 0; j < _martix.GetLength(1); j++)
                {
                    EachColMax.Add(_martix[j, i]);
                }
                EachColMinMax.Add(EachColMax.Max());//Обирається з рядка максимальний елемент
            }
            MiniMaxStrategyForCol = EachColMinMax.Min();//Серед максимальних обирається мін(Мінімаксна стратегія)
            return EachColMinMax.Min();
        }
    }
}