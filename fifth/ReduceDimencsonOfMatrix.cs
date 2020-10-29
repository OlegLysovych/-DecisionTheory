using System.Collections.Generic;
using System.Linq;

namespace fifth
{
    public class ReduceDimencsonOfMatrix
    {
        private readonly int[,] _matrix;
        public int[,] ReducedMatrix;
        List<(string, string, int)> Checker = new List<(string, string, int)>();//індекс рядка Домінуючий, індекс рядка Домінований, Значення.


        public ReduceDimencsonOfMatrix(int[,] matrix)
        {
            _matrix = matrix;
        }

        //Перевірка на домінуючі рядки 
        public List<(string, string, int)> CalculateReduceRowsDimension()
        {
            // System.Console.WriteLine();
            for (int i = 0; i < _matrix.GetLength(0); i++)//Прохід по кожному рядку
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)//Обирається кожен окремий елемент рядка
                {
                    //Кожен елемент порівнюється з елементом такого ж індексу в кожному рядку
                    //Доопоміжний цикл для порівнюваних рядків
                    for (int k = 1; k < _matrix.GetLength(0) - i; k++)
                    {
                        //Елемент з індексом [i;j] більший за всі j-ті елементи інших рядків з індексами [k;j]
                        //То записую його в список кортежів в порядку Домінуючий ([i;j]), Домінований [k;j], Значення за координатами [i;j]
                        if (_matrix[i, j].CompareTo(_matrix[i + k, j]) == 1)
                        {
                            // System.Console.WriteLine($"[{i},{j}]: {_matrix[i, j]} better {_matrix[i + k, j]}: [{i + k},{j}]");
                            Checker.Add(($"[{i}]", $"[{i + k}]", _matrix[i, j]));
                        }
                        else
                        //Аналогічний запис, тільки якщо елемент іншого рядка домінує над [i;j], порядок запису в кортеж інший
                        if (_matrix[i, j].CompareTo(_matrix[i + k, j]) == -1)
                        {
                            // System.Console.WriteLine($"[{i + k},{j}]: {_matrix[i + k, j]} better {_matrix[i, j]}: [{i},{j}]");
                            Checker.Add(($"[{i + k}]", $"[{i}]", _matrix[i, j]));
                        }
                        else
                        //Порівнювані елементи однакові
                        if (_matrix[i, j].CompareTo(_matrix[i + k, j]) == 0)
                        {
                            // System.Console.WriteLine($"[{i},{j}]: {_matrix[i, j]} Equals {_matrix[i + k, j]}: [{i + k},{j}]");
                            Checker.Add(($"[{i + k}]", $"[{i}]", 0));
                        }
                    }
                }
                // System.Console.WriteLine();
            }

            return Checker;
        }
        //Перевірити записаний кортеж на рядки, що можуть бути видалені з матриці(доміновані або повторювані)
        public bool IsNeedToReduseRows()
        {
            int checker = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int k = 1; k < _matrix.GetLength(0) - i; k++)
                {
                    //Обираю елементи де Домінуючий рядок переважає Домінований у всіх елементах рядка(із 5-ти рядків)
                    if (Checker.Where(x => x.Item1.Contains($"{i}")).Where(x => x.Item2.Contains($"{i + k}")).Count() == _matrix.GetLength(0))
                    {
                        System.Console.WriteLine($"{i} row is better than the {i + k} row");
                        checker++;
                    }
                }
            }
            if (checker > 0)
                return true;

            return false;
        }
        public List<(string, string, int)> CalculateReduceColsDimension()
        {
            // System.Console.WriteLine();
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {

                    for (int k = 1; k < _matrix.GetLength(1) - j; k++)
                    {
                        if (_matrix[i, j].CompareTo(_matrix[i, j + k]) == 1)
                        {
                            // System.Console.WriteLine($"[{i},{j}]: {_matrix[i, j]} better {_matrix[i, j + k]}: [{i},{j+ k}]");
                            Checker.Add(($"[{j}]", $"[{j + k}]", _matrix[i, j]));
                        }
                        else
                        if (_matrix[i, j].CompareTo(_matrix[i, j + k]) == -1)
                        {
                            // System.Console.WriteLine($"[{i},{j + k}]: {_matrix[i, j + k]} better {_matrix[i, j]}: [{i},{j}]");
                            Checker.Add(($"[{j + k}]", $"[{j}]", _matrix[i, j]));
                        }
                        else
                        if (_matrix[i, j].CompareTo(_matrix[i + k, j]) == 0)
                        {
                            // System.Console.WriteLine($"[{i},{j}]: {_matrix[i, j]} Equals {_matrix[i, j + k]}: [{i},{j + k}]");
                            Checker.Add(($"[{j + k}]", $"[{j}]", 0));
                        }
                    }
                }
                // System.Console.WriteLine();
            }

            return Checker;
        }

        public bool IsNeedToReduseCols()
        {
            int checker = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int k = 1; k < _matrix.GetLength(0) - i; k++)
                {
                    if (Checker.Where(x => x.Item1.Contains($"{i}")).Where(x => x.Item2.Contains($"{i + k}")).Count() == _matrix.GetLength(1))
                    {
                        System.Console.WriteLine($"{i} column is better than the {i + k} column");
                        checker++;
                    }
                }
            }
            if (checker > 0)
                return true;

            return false;
        }
    }
}