using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.DynamicPlanning
{
    public interface IDynamicPlanningService
    {
        string[] GetLongestCommonSubsequence(int[,] backup, string[] x, int i, int j);
    }
}
