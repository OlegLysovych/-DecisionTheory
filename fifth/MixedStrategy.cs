using System;
using System.Diagnostics;
using LpSolveDotNet;

namespace fifth
{
    public class MixedStrategy
    {
        private int[,] _matrix;
        public MixedStrategy(int[,] matrix)
        {
            _matrix = matrix;
            LpSolve.Init();
        }

        public int SolveLinearForRow()
        {
            int Ncol = _matrix.GetLength(1);//5 columns
            int Nrow = _matrix.GetLength(0);

            using (LpSolve lp = LpSolve.make_lp(Nrow, Ncol))
            {
                if (lp == null)
                {
                    return 1; // couldn't construct a new model...
                }

                lp.set_col_name(1, "x1");
                lp.set_col_name(2, "x2");
                lp.set_col_name(3, "x3");
                lp.set_col_name(4, "x4");
                lp.set_col_name(5, "x5");

                //create space large enough for one row
                int[] colno = new int[Ncol];
                double[] row = new double[Ncol];

                // makes building the model faster if it is done rows by row
                lp.set_add_rowmode(true);
                // 4 10 16 14 17
                // 5 4 2 16 14
                // 17 3 6 10 15
                // 14 16 18 4 7
                // 6 3 10 18 15
                //construct first row (4x1 + 10x2 + 16x3 + 14x4 + 17x5 <= 1)
                int j = 0;
                colno[j] = 1; // first column
                row[j++] = 4;

                colno[j] = 2; // second column
                row[j++] = 10;

                colno[j] = 3; // 3 column
                row[j++] = 16;

                colno[j] = 4; // 4 column
                row[j++] = 14;

                colno[j] = 5; // 5 column
                row[j++] = 17;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct 2 row (5x1 + 4x2 + 2x3 + 16x4 + 14x5 <= 1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 5;

                colno[j] = 2; // second column
                row[j++] = 4;

                colno[j] = 3; // 3 column
                row[j++] = 2;

                colno[j] = 4; // 4 column
                row[j++] = 16;

                colno[j] = 5; // 5 column
                row[j++] = 14;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct 3 row (17x1 + 3x2 + 6x3 + 10x4 + 15x5 <= 1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 17;

                colno[j] = 2; // 2 column
                row[j++] = 3;

                colno[j] = 3; // 3 column
                row[j++] = 6;

                colno[j] = 4; // 4 column
                row[j++] = 10;

                colno[j] = 5; // 5 column
                row[j++] = 15;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct 4 row (14x1 + 16x2 + 18x3 + 4x4 + 7x5 <= 1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 14;

                colno[j] = 2; // second column
                row[j++] = 16;

                colno[j] = 3; // 2 column
                row[j++] = 18;

                colno[j] = 4; // 3 column
                row[j++] = 4;

                colno[j] = 5; // 4 column
                row[j++] = 7;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct 5 row (6x1 + 3x2 + 10x3 + 18x4 + 15x5 <= 1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 6;

                colno[j] = 2; // 2 column
                row[j++] = 3;

                colno[j] = 3; // 3 column
                row[j++] = 10;

                colno[j] = 4; // 4 column
                row[j++] = 18;

                colno[j] = 5; // 5 column
                row[j++] = 15;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                // add the row to lpsolve
                            // for (int i = 0; i < Nrow; i++)
                            // {
                            //     int f = 0;
                            //     for (int j = 0; j < Ncol; j++)
                            //     {
                            //         colno[j] = j; //n column
                            //         row[f++] = _matrix[i, j];//n value
                            //         if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                            //         {
                            //             return 3;
                            //         }
                            //     }
                            // }
                //rowmode should be turned off again when done building the model
                lp.set_add_rowmode(false);

                //set the objective function (x1 + x2 + x3 + x4 + x5)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 1;

                colno[j] = 2; // second column
                row[j++] = 1;
                colno[j] = 3; // 2 column
                row[j++] = 1;
                colno[j] = 4; // 3 column
                row[j++] = 1;
                colno[j] = 5; // 4 column
                row[j++] = 1;

                if (lp.set_obj_fnex(j, row, colno) == false)
                {
                    return 4;
                }
                //set the objective function (x1 + x2 + x3 + x4 + x5)
                // int k;
                //             for (int i = 0; i < Nrow; i++)
                //             {
                //                 k = 0;

                //                 for (int j = 0; j < Ncol; j++)
                //                 {
                //                 colno[j] = j; // n column
                //                 row[k++] = 1;
                //                 if (lp.set_obj_fnex(j, row, colno) == false)
                //                 {
                //                     return 4;
                //                 }
                //                 }
                //             }
                            

                // set the object direction to maximize
                lp.set_maxim();

                // just out of curioucity, now show the model in lp format on screen
                // this only works if this is a console application. If not, use write_lp and a filename
                lp.write_lp("model.lp");
                // I only want to see important messages on screen while solving
                lp.set_verbose(lpsolve_verbosity.IMPORTANT);

                // Now let lpsolve calculate a solution
                lpsolve_return s = lp.solve();
                if (s != lpsolve_return.OPTIMAL)
                {
                    return 5;
                }


                // a solution is calculated, now lets get some results

                // objective value
                Debug.WriteLine("Objective value: " + lp.get_objective());

                // variable values
                lp.get_variables(row);
                for (j = 0; j < Ncol; j++)
                {
                    Console.WriteLine(lp.get_col_name(j + 1) + ": " + row[j]);
                }
            }
            return 1;
        }

        public int SolveLinearForCol()
        {
            int Ncol = _matrix.GetLength(1);//5 columns
            int Nrow = _matrix.GetLength(0);

            using (LpSolve lp = LpSolve.make_lp(Nrow, Ncol))
            {
                if (lp == null)
                {
                    return 1; // couldn't construct a new model...
                }

                lp.set_col_name(1, "x1");
                lp.set_col_name(2, "x2");
                lp.set_col_name(3, "x3");
                lp.set_col_name(4, "x4");
                lp.set_col_name(5, "x5");

                //create space large enough for one row
                int[] colno = new int[Ncol];
                double[] row = new double[Ncol];

                // makes building the model faster if it is done rows by row
                lp.set_add_rowmode(true);
                // 4 10 16 14 17
                // 5 4 2 16 14
                // 17 3 6 10 15
                // 14 16 18 4 7
                // 6 3 10 18 15
                //construct first row (4x1 + 5x2 +176x3 + 14x4 + 6x5 <= -1)
                int j = 0;
                colno[j] = 1; // first column
                row[j++] = 4;

                colno[j] = 2; // second column
                row[j++] = 5;

                colno[j] = 3; // second column
                row[j++] = 17;

                colno[j] = 4; // second column
                row[j++] = 14;

                colno[j] = 5; // second column
                row[j++] = 6;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }
                //construct 2 row (10x1 + 4x2 +3x3 + 16x4 + 3x5 <= -1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 10;

                colno[j] = 2; // second column
                row[j++] = 4;

                colno[j] = 3; // second column
                row[j++] = 3;

                colno[j] = 4; // second column
                row[j++] = 16;

                colno[j] = 5; // second column
                row[j++] = 3;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }
                //construct 3 row (16x1 + 2x2 +6x3 + 18x4 + 10x5 <= -1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 16;

                colno[j] = 2; // second column
                row[j++] = 2;

                colno[j] = 3; // second column
                row[j++] = 6;

                colno[j] = 4; // second column
                row[j++] = 18;

                colno[j] = 5; // second column
                row[j++] = 10;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }
                //construct 4 row (14x1 + 16x2 +10x3 + 4x4 + 18x5 <= -1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 14;

                colno[j] = 2; // second column
                row[j++] = 16;

                colno[j] = 3; // second column
                row[j++] = 10;

                colno[j] = 4; // second column
                row[j++] = 4;

                colno[j] = 5; // second column
                row[j++] = 18;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }
                //construct 5 row (17x1 + 14x2 +15x3 + 7x4 + 15x5 <= -1)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 17;

                colno[j] = 2; // second column
                row[j++] = 14;

                colno[j] = 3; // second column
                row[j++] = 15;

                colno[j] = 4; // second column
                row[j++] = 7;

                colno[j] = 5; // second column
                row[j++] = 15;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }

                lp.set_add_rowmode(false);
                //set the objective function (1 x + 1 x2 +x3+x4+x5)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 1;

                colno[j] = 2; // second column
                row[j++] = 1;
                colno[j] = 3; // 3 column
                row[j++] = 1;
                colno[j] = 4; // 4 column
                row[j++] = 1;
                colno[j] = 5; // 5 column
                row[j++] = 1;

                if (lp.set_obj_fnex(j, row, colno) == false)
                {
                    return 4;
                }
                // set the object direction to maximize
                lp.set_minim();
                // just out of curioucity, now show the model in lp format on screen
                // this only works if this is a console application. If not, use write_lp and a filename
                lp.write_lp("model2.lp");

                // I only want to see important messages on screen while solving
                lp.set_verbose(lpsolve_verbosity.IMPORTANT);

                // Now let lpsolve calculate a solution
                lpsolve_return s = lp.solve();
                if (s != lpsolve_return.OPTIMAL)
                {
                    return 5;
                }


                // a solution is calculated, now lets get some results

                // objective value
                Debug.WriteLine("Objective value: " + lp.get_objective());

                // variable values
                lp.get_variables(row);
                for (j = 0; j < Ncol; j++)
                {
                    Console.WriteLine(lp.get_col_name(j + 1) + ": " + row[j]);
                }
            }
            return 1;

        }
    }
}