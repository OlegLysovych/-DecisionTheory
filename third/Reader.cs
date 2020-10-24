using System;
using System.Collections.Generic;
using System.IO;

namespace third
{
    public class Reader
    {
        StreamReader _readerVotes;
        StreamReader _readerCandidates;
        // List<string> list;
        string[,] ArrayOfCandadatesFromTask = new string[5,3];
        public List<int> ListOfCountedVotes = new List<int>();

        public Reader(string pathToCandidate, string pathToVoters)
        {
            _readerCandidates = new StreamReader(pathToCandidate);
            _readerVotes = new StreamReader(pathToVoters);
        }

        public List<int> ReadVotesFromFile()
        {
            string voters = _readerVotes.ReadToEnd();
            foreach (var element in voters.Split(' '))
            {
                ListOfCountedVotes.Add(int.Parse(element.Trim()));
            }
            return ListOfCountedVotes;
        }

        public string[,] ReadCandidatesFromFile()
        {
            string candidates = _readerCandidates.ReadToEnd();

            int i = 0 ; int j = 0;
            foreach (var row in candidates.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    ArrayOfCandadatesFromTask[i, j] = col.Trim();
                    j++;
                }
                i++; 
            }    
            return ArrayOfCandadatesFromTask;
        } 

        public void OutputMyTask(List<int> VotesList, string[,] CandidatesMatrix)
        {
            System.Console.WriteLine("Task:");
            for (int r = 0; r < CandidatesMatrix.GetLength(0); r++)
            {
                System.Console.Write($"{VotesList[r]}\t");

                for (int c = 0; c < CandidatesMatrix.GetLength(1); c++)
                {
                    System.Console.Write($" {CandidatesMatrix[r,c]} -> \t");
                }
                System.Console.WriteLine();
            }
        }
    }
}