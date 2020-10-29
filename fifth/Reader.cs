using System.IO;

namespace fifth
{
    public class Reader
    {
        StreamReader _readerMatrix;

        public int[,] ReadMatrixFromFile(string pathToMatrix)
        {
            int[,] ArrayFromTask = new int[5, 5];

            _readerMatrix = new StreamReader(pathToMatrix);

            string matrix = _readerMatrix.ReadToEnd();

            int i = 0; int j = 0;
            foreach (var row in matrix.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    ArrayFromTask[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            return ArrayFromTask;
        }
    }
}