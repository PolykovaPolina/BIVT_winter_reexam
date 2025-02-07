// Variant_9
using System;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task_1:
            // Input: T = 4, D = 6, N = 22
            // Output: time = 83885792
            

            // Task_2:
            // Input: speedLimit = 4, motorLimit = 6, turnsPerSec = 22
            // Output: time = 5,899999999999999


            // Task_3:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 -13, 13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   0,  -2,  13, -11,  18, 
                 -8,   0, -20,   1, -20,   3, 
                 -2, -20,  -6,  19,  13, -13, 
                 -4, -22,  18, -15,  21,  22, 
                -17,   7, -16,  12,  22,   2, 
                -22, -21,  24, -13,   7, -14 */
            var M = new int[,] { { 23, 7, -13, 24, -21, 18 },
                { 2, 0, 12, -16, -20, -17 },
                { 22, 21, -6, 19, -22, -4 },
                { -13, 13, 18, -15, -20, -2 },
                { 3, 7, 1, -20, 22, -8 },
                { -22, -11, 13, -2, 0, -14 } };



            // Task_4:
            // Input:
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*  -20, -10,  -1 */
            
                    

        // Task_5:
        // Input:
        /*   23,   7, -13,  24, -21,  18, 
              2,   0,  12, -16, -20, -17, 
             22,  21,  -6,  19, -22,  -4, 
            -13,  13,  18, -15, -20,  -2, 
              3,   7,   1, -20,  22,  -8, 
            -22, -11,  13,  -2,   0, -14 */

        /*   17,  17,   2, -10,  -1, -20 */
        // Output 1:
        /*   23,   7, -13, -20, -21,  18, 
              2,   0,  12, -16, -20, -17, 
             22,  21,  -6,  19, -22,  -4, 
            -13,  13,  18, -15, -20,  -2, 
              3,   7,   1, -20,  22,  -8, 
             17, -11,  13,  -2,   0, -14 */

        /*  -20, -10,  -1,   2,  17,  17 */
        // Output 2:
        /*   23,   7, -13,  17, -21,  18, 
              2,   0,  12, -16, -20, -17, 
             22,  21,  -6,  19, -22,  -4, 
            -13,  13,  18, -15, -20,  -2, 
              3,   7,   1, -20,  22,  -8, 
            -20, -11,  13,  -2,   0, -14 */

        /*   17,  17,   2,  -1, -10, -20 */

    }
        public double Task_1(double T, double D, double N)
        {

            double time = 0;
            double rechargeTime = 10;

            for (int i = 0; i < N; i++)
            {
                time += T;
                if (i < N - 1)
                {

                    time += rechargeTime;
                    T += rechargeTime * (N - i - 1);
                    rechargeTime += D;
                }
            }
            return time;
        }
        public double Task_2(double speedLimit, double motorLimit, double turnsPerSec)
        {
            double speed = 0; 
            double turns = 0;
            double gear = 1;
            double time = 0;
            while (speed < speedLimit)
            {
                if (turns < motorLimit)
                {
                    turns += turnsPerSec;
                    time += 0.5;
                }
                else
                {
                    {
                        if (gear >= 5)
                        {
                            turns = motorLimit;
                        }
                        else
                        {
                            gear++;
                            turns -= turns * 0.15;
                            time++;
                            motorLimit += 250;
                        }
                    }
                }
                turns = Math.Round(turns);
                speed += turns / 180;
                time += 0.1;
            }
            return time;
        }
        public void Task_3(int[,] M)
        {
            int n = M.GetLength(0);
            int m = M.GetLength(1);
            if (n == 0 || m != n || M == null)
            {
                Console.WriteLine("Ошибка");
            }
            else
            {
                int[,] newM = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        newM[i, j] = M[i, j];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j && i + j != n - 1)
                        {
                            newM[i, j] = M[n - 1 - i, n - 1 - j];
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(newM[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

            }
        }
        public void Task_4(ref int[] A)
        {
            if (A == null || A.Length == 0)
            {
                Console.WriteLine("ошибка");
            }
            int n = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 0)
                {
                    n++;
                }
            }
            if (n == 0)
            {
                Console.WriteLine("ошибка");
            }
            int[] negativeList = new int[n];
            int m = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 0)
                {
                    negativeList[m] = A[i];
                    m++;
                }
            }
            int[] shifted = GetNegativeSubArray(negativeList, 10);

            Console.WriteLine(shifted);
            A = shifted;
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i]);
                Console.WriteLine(" ");
            }

        }
        public static int[] GetNegativeSubArray(int[] arr, int shiftAmount)
        {
            if (arr == null || arr.Length == 0)
            {
                return arr;
            }

            int n = arr.Length;
            shiftAmount = shiftAmount % n;

            if (shiftAmount < 0)
            {
                shiftAmount = n + shiftAmount;
            }

            int[] shiftedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                shiftedArray[(i + shiftAmount) % n] = arr[i];
            }
            return shiftedArray;
        }

        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public void FindUpperPartMaxIndex(int[,] matrix, out int maxRow, out int maxCol)
        {
            maxRow = 0; maxCol = 0;
        }
        public void FindLowerPartMinIndex(int[,] matrix, out int minRow, out int minCol)
        {
            minRow = 0; minCol = 0;
        }
    }
}