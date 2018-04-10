using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string left = "5";
            string right = "1";
            string mathOperator = "+";

            var calc = new Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Console.WriteLine("5 + 1 = " + result);

            calc.setLeft("3");
            calc.setRight("9");
            calc.SetOperator("*");

            calc.Calculate();

            Console.WriteLine("3 * 9 = " + calc.getResult());


            Console.WriteLine("Previous Result = " + calc.getPreviousResult(1));

            Console.ReadLine();
        }
    }
}
