using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_14_1_Jeremy_Belisle
{
    public class Calculator
    {
        //method to proforme the calculations 
        public static decimal calculate(decimal a, decimal b, String symbol)
        {
            //switch statement to check the correct symbol
            decimal txtResult = 0;
            switch (symbol)
            {
                case "+":
                    txtResult = a + b;
                    break;
                case "-":
                    txtResult = a - b;
                    break;
                case "*":
                    txtResult = a * b;
                    break;
                case "/":
                    txtResult = a / b;
                    break;
                default:
                    break;
            }

            return txtResult;
        }

        //method to change the number to a minus or plus
        public static System.Windows.Forms.TextBox btnPlusMinus(System.Windows.Forms.TextBox txtResult)
        {
            decimal plusMinus = 0;
            decimal valueDouble = 0;
            plusMinus = decimal.Parse(txtResult.Text);
            //minusing the number by 3 to be able to switch the value
            valueDouble = plusMinus - plusMinus - plusMinus;
            txtResult.Text = valueDouble.ToString("g");

            return txtResult;
        }
        //method to get the reciprocal of a number
        public static System.Windows.Forms.TextBox btnReciprocal(System.Windows.Forms.TextBox txtResult)
        {
            decimal reciprocal = 0;
            reciprocal = decimal.Parse(txtResult.Text);
            //dividing 1 by the number to ge the reciprocal
            reciprocal = 1 / reciprocal;
            txtResult.Text = reciprocal.ToString("g");

            return txtResult;

        }
        //sqrt root method
        public static System.Windows.Forms.TextBox btnSqrt(System.Windows.Forms.TextBox txtResult)
        {
            double sqrt = 0;
            sqrt = double.Parse(txtResult.Text);
            //calling the math class to access the sqrt root method
            sqrt = Math.Sqrt(sqrt);
            txtResult.Text = sqrt.ToString("g");

            return txtResult;
        }
    }
}
