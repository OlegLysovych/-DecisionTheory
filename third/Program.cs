using System;
using System.Collections.Generic;
using System.Linq;

namespace third
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tHello World!");
            Console.WriteLine("\tHere we count some votes in Group decision-making\n \t by Kondorse method and Borda method");

            string pathToCanidate = "CandidatesDataMatrix.txt";//path to priority of candidates
            string pathToVoters = "VotersCountedVotes.txt";//path to counted votes for each priority

            Reader read = new Reader(pathToCanidate, pathToVoters);

            List<int> CountedVotes = read.ReadVotesFromFile();
            string[,] CandidatesMatrix = read.ReadCandidatesFromFile();
            read.OutputMyTask(CountedVotes, CandidatesMatrix);

            System.Console.WriteLine("\n\tCount votes by Borda method:");

            BordaMethod borda = new BordaMethod();

            var votes = borda.CountVotesByBorda(CountedVotes, CandidatesMatrix);

            System.Console.WriteLine("\nPoints for each candidate at each position");
            votes.ForEach(tuple =>
            {
                Console.Write($"\t{tuple.Item1}: {tuple.Item2}");
            });

            System.Console.WriteLine("\nTotal candidates points");
            borda.CountAllVotesForEachCandidate(votes).ForEach(totalPoints =>
            {
                Console.Write($"\t{totalPoints.Item1}: {totalPoints.Item2}");
            });

            System.Console.WriteLine("\n\n\t Count votes by Condorcet method: ");

            CondorcetMethod condorcet = new CondorcetMethod();
            var eachElementComparedCondorset = condorcet.EachElementComparingCondorcet(CountedVotes, CandidatesMatrix);

            System.Console.WriteLine("Votes with comparing each pair of candidates at each position: ");

            eachElementComparedCondorset.ForEach(tuple =>
            {
                System.Console.WriteLine($"\t{tuple.Item1} better {tuple.Item2} by {tuple.Item3} votes");
            });

            System.Console.WriteLine("\nTotal comparing votes :");
            condorcet.CondorcetFinalCounting(eachElementComparedCondorset).ForEach(tuple =>
            {
                System.Console.WriteLine($"\t{tuple.Item1} better {tuple.Item2} by {tuple.Item3} votes");
            });


        }
    }
}
