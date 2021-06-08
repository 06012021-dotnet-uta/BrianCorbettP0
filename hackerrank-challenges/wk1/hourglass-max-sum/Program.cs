using System;
using System.Collections.Generic;
using System.Linq;

namespace hourglass_max_sum
{
    class Result
    {

        /*
         * Complete the 'hourglassSum' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int hourglassSum(List<List<int>> arr)
        {
            double LargestSum = Double.NegativeInfinity;
            int n = 6;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    List<int> values = new List<int>() {
                    arr[i+0][j+0],
                    arr[i+0][j+1],
                    arr[i+0][j+2],
                    arr[i+1][j+1],
                    arr[i+2][j+0],
                    arr[i+2][j+1],
                    arr[i+2][j+2]
                };

                    int HourglassSum = values.Sum();
                    if (HourglassSum > LargestSum) LargestSum = HourglassSum;
                }
            }

            return (int)LargestSum;
        }

    }
}
