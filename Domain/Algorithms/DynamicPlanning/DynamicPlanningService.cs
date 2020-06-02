using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.DynamicPlanning
{
    public class DynamicPlanningService : IDynamicPlanningService
    {
        public DynamicPlanningService()
        { }

        public string[] GetLongestCommonSubsequence(int[,] backup, string[] x, int i, int j)
        {
            throw new NotImplementedException();
        }

        private (int[,] length, string[,] graphic) calculateLongestCommonSubsequence(string[] x, string[] y)
        {
            var row = x.Length;
            var line = y.Length;
            string[,] graphic = new string[row, line];
            int[,] length = new int[row, line];
            for (int i = 0; i < row; i++)
                length[i, 0] = 0;
            for (int j = 0; j < line; j++)
                length[0, j] = 0;
            for (int i = 1; i < line; i++)
            {
                for (int j = 1; j < row; j++)
                {
                    if (x[i] == y[j])
                    {
                        length[i, j] = length[i - 1, j - 1] + 1;
                        graphic[i, j] = "↖";
                    }
                    else if (length[i - 1, j] >= length[i, j - 1])
                    {
                        length[i, j] = length[i - 1, j];
                        graphic[i, j] = "↑";
                    }
                    else
                    {
                        length[i, j] = length[i, j - 1];
                        graphic[i, j] = "←";
                    }
                }
            }
            return (length, graphic);
        }
    }
}
