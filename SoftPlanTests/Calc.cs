using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanTests
{
    public class Calc
    {
        public int Sum(int num1, int num2) => num1 + num2;
        public int Sub(int num1, int num2) => num1 - num2;
        public int Multiply(int num1, int num2) => num1 * num2;
        public int Div(int num1, int num2) => num1 / num2;
        public (int q, int rest) RestoDivisao(int num1, int num2) => (num1 / num2, num1 % num2);
    }
}
