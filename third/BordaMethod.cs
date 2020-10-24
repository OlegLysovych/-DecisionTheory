using System;
using System.Collections.Generic;
using System.Linq;

namespace third
{
    public class BordaMethod
    {

        public BordaMethod()
        {
        }
        //За правилом Борда кандидат, що останній в пріорітетності отримує 1 бал, дальше n+1
        public List<(string, int)> CountVotesByBorda(List<int> Votes, string[,] Candidates)
        {
            //ініціалізується список з кортежем Кандидат + його бали
            List<(string, int)> BordaCountedPoints = new List<(string, int)>();
            //допоміжний масив для виключення вже пройдених рядків із отримувача індексів кандидата в масиів
            int[] looper = new int[2] { 0, 0 };
            //прохід по кожному кандидаті в масиві
            foreach (var item in Candidates)
            {
                var indexes = ArrayIndexes.CoordinatesOf(Candidates, item, looper);//отримати індекс кандидата в масиів
                switch (indexes.Item2)
                {
                    case 0://якщо пріорітет найвищий, тобто перший індекс, множаться кількість голосів на 3 бали
                        BordaCountedPoints.Add((item, Votes[indexes.Item1] * 3));
                        break;
                    case 1://кількість голосів на 2 бали
                        BordaCountedPoints.Add((item, Votes[indexes.Item1] * 2));
                        break;
                    case 2://кількість голосів на 1 бал
                        BordaCountedPoints.Add((item, Votes[indexes.Item1] * 1));
                        break;
                    default:
                        System.Console.WriteLine($"Man, here we have a problem: {indexes.Item1}{indexes.Item2}{item}");//exception
                        break;
                }

                if (indexes.Item2 == 2)
                {
                    looper[0] = indexes.Item1 + 1;
                    // looper[1] = 0;
                }
            }
            return BordaCountedPoints;
        }

        public List<(string, int)> CountAllVotesForEachCandidate(List<(string, int)> countedVotes)
        {

            List<(string, int)> counted = new List<(string, int)>();
            var A = countedVotes
                .Where(votes => votes.Item1.Contains("a"))//Сумування балів для кандидата А
                .Select(x => x.Item2)
                .Sum();
            counted.Add(("a", A));

            var B = countedVotes
                .Where(votes => votes.Item1.Contains("b"))//Сумування балів для кандидата B
                .Select(x => x.Item2)
                .Sum();
            counted.Add(("b", B));

            var C = countedVotes
                .Where(votes => votes.Item1.Contains("c"))//Сумування балів для кандидата C
                .Select(x => x.Item2)
                .Sum();
            counted.Add(("c", C));
            return counted;
        }
    }
}