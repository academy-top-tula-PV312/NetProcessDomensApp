using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLibrary
{
    public static class MyFuncs
    {
        public static double Power(double x, int n)
        {
            double result = 1;
            for(int i = 0;  i < n; i++) 
                result *= x;
            return result;
        }
    }
}
