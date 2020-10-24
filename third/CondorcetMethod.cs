using System.Collections.Generic;
using System.Linq;

namespace third
{
    public class CondorcetMethod
    {
        //За методом Кондорсе переможцем вважається кандидат, що перемагає в попарному порівнянні серед всіх кандидатів
        public List<(string, string, int)> EachElementComparingCondorcet(List<int> Votes, string[,] Candidates)
        {
            //Ініціалізується список з кортежем Кандидат1, Кандидат 2, кількість голосів
            //Розуміється, що кандадат записаний в кортеж першим, переважає другого,
            //  на кількість голосів, що записані третіми в кортежі
            List<(string, string, int)> KondorseCountedPoints = new List<(string, string, int)>();
            //Прохід по кожному рядку масиву, рядок означає відповідне розподілення пріорітетності кандидатів
            for (int r = 0; r < Candidates.GetLength(0); r++)
            {
                //В кожному рядку міститься три кандидати, порівняння яких записуватиметься в список KondorseCountedPoints
                //Кандидат з найменшим індексом(найбільшою пріорітетністю) переважає наступного кандидата на кількість голосів, що відповідає рядку
                KondorseCountedPoints.Add((Candidates[r, 0], Candidates[r, 1], Votes[r]));//перший кандидат з другим
                KondorseCountedPoints.Add((Candidates[r, 1], Candidates[r, 2], Votes[r]));//другий кандидат з третім
                KondorseCountedPoints.Add((Candidates[r, 0], Candidates[r, 2], Votes[r]));//перший кандидат з третім
            }
            return KondorseCountedPoints;
        }

        //Останнім етапом є сумування балів, для двох порівнянь. Оскільки кандидатів три, то можливі 6 варіацій парного порівняння за умов вище.
        public List<(string, string, int)> CondorcetFinalCounting(List<(string, string, int)> eachElementComparingCondorset)
        {
            List<(string, string, int)> condorsetCounted = new List<(string, string, int)>();
            //Обрати із списку ті кортежі, де А переважає Б і просумувати кільість голосів, за такої умови
            var A_B = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("a"))
                .Where(votes => votes.Item2.Contains("b"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("a", "b", A_B));

            //Обрати із списку ті кортежі, де Б переважає А і просумувати кільість голосів, за такої умови
            var B_A = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("b"))
                .Where(votes => votes.Item2.Contains("a"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("b", "a", B_A));

            var A_C = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("a"))
                .Where(votes => votes.Item2.Contains("c"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("a", "c", A_C));

            var C_A = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("c"))
                .Where(votes => votes.Item2.Contains("a"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("c", "a", C_A));

            var B_C = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("b"))
                .Where(votes => votes.Item2.Contains("c"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("b", "c", B_C));

            var C_B = eachElementComparingCondorset
                .Where(votes => votes.Item1.Contains("c"))
                .Where(votes => votes.Item2.Contains("b"))
                .Select(x => x.Item3)
                .Sum();
            condorsetCounted.Add(("c", "b", C_B));

            return condorsetCounted;
        }
    }
}