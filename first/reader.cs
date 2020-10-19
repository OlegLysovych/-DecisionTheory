using System;
using System.Collections.Generic;
using System.IO;

namespace first
{
    public class reader
    {
        string _path;
        StreamReader _reader;
        List<string> list;
        int[,] ArraOfIntegerFromTask = new int[3,3];

        public reader(string path)
        {
            _path = path;
            _reader = new StreamReader(_path);
        }

        public int[,] ReadMatrixTaskFromFile()
        {
            string str = _reader.ReadToEnd();
            int i = 0 ; int j = 0;
            foreach (var row in str.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    ArraOfIntegerFromTask[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++; 
            }
            // for (int r = 0; r < 3; r++)
            // {
            //     for (int c = 0; c < 3; c++)
            //     {
            //         System.Console.Write($" {ArraOfIntegerFromTask[r,c]} \t");
            //     }
            //     System.Console.WriteLine();
            // }
            return ArraOfIntegerFromTask;
        } 
    }
}