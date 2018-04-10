using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public class Calculator
    {
        private LinkedList<string> lastCalculations = new LinkedList<string>();

        public string OperatorString{get; set;}
        public double Left { get; set; }
        public double Right { get; set; }
        public string Result { get; set; }

        public void setLeft(string leftString)
        {
            double outvalue = 0.0; ;
            if(double.TryParse(leftString, out outvalue))
            {
                Left = outvalue;
            }
            else
            {
                Result = "Left value must be numeric";
            }
        }

        public void setRight(string rightString)
        {
            double outvalue = 0.0; ;
            if (double.TryParse(rightString, out outvalue))
            {
                Right = outvalue;
            }
            else
            {
                Result = "Right value must be numeric";
            }
        }

        public void SetOperator(string operatorString)
        {
            OperatorString = operatorString;
        }

        public string getResult()
        {
            string ResultOut = Result;
            Result = "";
            return ResultOut;
        }

        public Calculator(string left, string right, string mathOperator)
        {
            var errors = new StringBuilder();
            var leftDouble = 0.00;
            if (Double.TryParse(left, out leftDouble))
            {
                Left = leftDouble;
            }
            else
            {
                errors.Append("Left Value must be numeric");
            }
            var rightDouble = 0.0;
            if (Double.TryParse(right, out rightDouble))
            {
                Right = rightDouble;
            }
            else
            {
                errors.Append("Right Value must be numeric");
            }
            if (mathOperator != "+" &&  mathOperator != "-" && mathOperator != "/" && mathOperator != "*")
            {
                errors.Append("Mathmatical operators must be +, -, *, /");
            }
            else
            {
                OperatorString = mathOperator;
            }

            if (errors.Length > 0)
            {
                Result = errors.ToString();
            }
            else
            {
                Result = string.Empty;
            }

        }

        public string Calculate()
        {
            if (Result.Length > 0)
            {
                QueueLast(Result);
                return Result;
            }
            try
            {
                switch (OperatorString)
                {
                    case "+":
                        QueueLast((Left + Right).ToString());
                        Result = (Left + Right).ToString();
                        break;
                    case "-":
                        QueueLast((Left - Right).ToString());
                        Result = (Left - Right).ToString();
                        break;
                    case "*":
                        QueueLast((Left * Right).ToString());
                        Result = (Left * Right).ToString();
                        break;
                    case "/":
                        QueueLast((Left / Right).ToString());
                        Result = (Left / Right).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public string getPreviousResult(int index)
        {
            return lastCalculations.ToArray()[index];
        }

        public void QueueLast(string lastCalc)
        {
            if(lastCalculations.Count() == 5)
            {
                lastCalculations.RemoveLast();
            }
            lastCalculations.AddFirst(lastCalc);
        }

    }

  
}
