using System.Net.Quic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace resolveurSudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[,] gridSudoku = {
            {-1, -1, 8, 3, 9, -1, 7, -1, 5},
            {7, 5, -1, -1, -1, -1, -1, 9, 6},
            {4, -1, -1, 1, -1,-1, -1, -1, -1},
            {-1, -1, 1, 6, -1, 2, 9, 8, 4},
            {6, -1, 9, -1, 3, 1, 2, -1, 7},
            {-1, -1, 7, 5, 4, -1, -1, -1, -1},
            {-1, 6, 2, -1, -1, 5, -1, 7, 8},
            {-1, 8, -1, -1, -1, 3, -1, 2, -1},
            {-1, -1, 4, 9, 2, -1, -1, -1, 1}
            };*/

            int[,] gridSudoku =
            {
                {7,3,8,5,1,-1,9,6,2},
                {-1,4,9,3,-1,7,-1,-1,5},
                {-1,5,1,-1,2,-1,-1,-1,-1},
                {3,-1,2,7,-1,-1,-1,-1,-1},
                {-1,-1,6,4,-1,2,7,5,3},
                {4,-1,-1,6,-1,-1,2,1,-1},
                {-1,-1,-1,2,-1,-1,-1,3,-1},
                {-1,-1,-1,-1,3,-1,6,4,-1},
                {-1,-1,3,9,-1,5,-1,2,-1}
            };

            int numberToGuess = 0;

            foreach (int numberNegative in gridSudoku)
            {
                if (numberNegative == -1)
                {
                    numberToGuess++;
                }
            }
            while (numberToGuess != 0)
            {
                for (int i = 0; i < gridSudoku.GetLength(0); i++)
                {
                    for (int j = 0; j < gridSudoku.GetLength(1); j++)
                    {
                        List<int> possibleNumbers = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
                        List<int> updatedList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        if (gridSudoku[i,j] == -1)
                        {
                            //on compare à la ligne
                            for (int k = 0; k < 9; k++)
                            {
                                if (gridSudoku[i,k] != -1)
                                {
                                    foreach (int number in possibleNumbers)
                                    {
                                        if (gridSudoku[i,k] == number)
                                        {
                                            updatedList.Remove(number);
                                        }
                                    }
                                }
                            }
                            //on compare à la colonne
                            for (int k = 0; k < 9; k++)
                            {
                                if (gridSudoku[k, j] != -1)
                                {
                                    foreach (int number in possibleNumbers)
                                    {
                                        if (gridSudoku[k, j] == number)
                                        {
                                            updatedList.Remove(number);
                                        }
                                    }
                                }
                            }

                            //on compare à la zone concernée
                            DeleteListNumber(gridSudoku, possibleNumbers, updatedList, i, j);
                            
                            if (updatedList.Count == 1)
                            {
                                gridSudoku[i,j] = updatedList[0];
                                numberToGuess--;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                for (int i = 0; i < gridSudoku.GetLength(0); i++)
                {
                    for (int j = 0; j < gridSudoku.GetLength(1); j++)
                    {
                        Console.Write(gridSudoku[i, j] + " - ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }
        public static void DeleteListNumber(int[,] gridSudoku, List<int> possibleNumbers, List<int> updatedList, int lineLoop, int columnLoop)
        {
            for (int k = (lineLoop / 3) * 3; k < ((lineLoop / 3) * 3) + 3; k++)
            {
                for (int l = (columnLoop / 3) * 3; l < ((columnLoop / 3) * 3) + 3; l++)
                {
                    foreach (int number in possibleNumbers)
                    {
                        if (gridSudoku[k, l] == number)
                        {
                            updatedList.Remove(number);
                        }
                    }
                }
            }
        }
    }
}
