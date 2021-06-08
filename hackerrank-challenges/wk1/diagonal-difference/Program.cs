using System;
using System.Collections.Generic;

namespace diagonal_difference
{
    class Result
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> arr)
        {
            int n = arr.Count;

            int PrimarySum = 0;
            for (int i = 0; i < n; i++)
            {
                PrimarySum += arr[i][i];
            }

            int SecondarySum = 0;
            for (int i = (n - 1); i >= 0; i--)
            {
                SecondarySum += arr[i][(n - 1) - i];
            }

            return Math.Abs(PrimarySum - SecondarySum);
        }

    }

}
