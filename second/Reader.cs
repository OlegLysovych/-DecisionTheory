using System;
using System.Collections.Generic;
using System.IO;

namespace second
{
    public class Reader
    {
        string _path;
        StreamReader _reader;
        // List<string> list;
        double[,] ArrayOfDoubleFromTask = new double[4,6];
        public List<string> Factory = new List<string>() {"Big", "Small", "Big_with_Additional_Research", "Not build anything"};
        enum factory 
        {
            Big,
            Small,
            Big_with_Additional_Research
        }

        public Reader(string path)
        {
            _path = path;
            _reader = new StreamReader(_path);
        }

        public double[,] ReadMatrixTaskFromFile()
        {
            string str = _reader.ReadToEnd();
            int i = 0 ; int j = 0;
            foreach (var row in str.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    double.TryParse(col.Trim(), out ArrayOfDoubleFromTask[i, j]);
                    j++;
                }
                i++; 
            }
            for (int r = 0; r < ArrayOfDoubleFromTask.GetLength(0); r++)
            {
                System.Console.Write($"{Factory[r]}\t");
                for (int c = 0; c < ArrayOfDoubleFromTask.GetLength(1); c++)
                {
                    System.Console.Write($" {ArrayOfDoubleFromTask[r,c]} \t");
                }
                System.Console.WriteLine();
            }
            return ArrayOfDoubleFromTask;
        } 
    }
}