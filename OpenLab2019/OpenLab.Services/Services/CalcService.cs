using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Services
{
    public interface ICalcService
    {
        int AddNumbers(int x, int y);
    }

    public class CalcService : ICalcService
    {
        public int AddNumbers(int x, int y)
        {
            return x + y;
        }

        public int SubtractNumbers(int x, int y)
        {
            return x - y;
        }

        public int MultiplyNumbers(int x, int y)
        {
            return x * y;
        }

        public bool IsEven(int x)
        {
            if ((x % 2) == 0)
                return true;
            else
                return false;
        }

        public bool IsEvenOrOdd(int x)
        {
            if ((x % 2) == 0)
                return true;
            else
                return false;
        }
        public int UnsafeDivide(int x, int y)
        {
            return (x / y);
        }

        public double SafeDivide(int x, int y)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(x) / y;
            }
            catch (DivideByZeroException e)
            {
                return -1;
            }
            return result;
        }
    }

}
