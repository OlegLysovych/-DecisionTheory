using System;
using System.Collections.Generic;
using System.IO;

namespace fourth
{
    public class Reader
    {
        StreamReader _readerList;
        StreamReader _readerMatrix;
        public Reader()
        {
        }

        public List<double> ReadListOfDoubleFromFile(string pathToList)
        {
            List<double> ListFromTask = new List<double>();

             _readerList = new StreamReader(pathToList);
            string list = _readerList.ReadToEnd();

            foreach (var element in list.Split(' '))
            {
                ListFromTask.Add(double.Parse(element.Trim()));
            }
            return ListFromTask;
        }
        public List<string> ReadListOfStringFromFile(string pathToList)
        {
            List<string> ListFromTask = new List<string>();

             _readerList = new StreamReader(pathToList);
            string list = _readerList.ReadToEnd();

            foreach (var element in list.Split(' '))
            {
                ListFromTask.Add(element.Trim());
            }
            return ListFromTask;
        }

        public int[,] ReadMatrixFromFile(string pathToMatrix)
        {
            int[,] ArrayOfPointsFromTask = new int[5,5];

            _readerMatrix = new StreamReader(pathToMatrix);

            string matrix = _readerMatrix.ReadToEnd();

            int i = 0 ; int j = 0;
            foreach (var row in matrix.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    ArrayOfPointsFromTask[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++; 
            }    
            return ArrayOfPointsFromTask;
        } 


    }
}