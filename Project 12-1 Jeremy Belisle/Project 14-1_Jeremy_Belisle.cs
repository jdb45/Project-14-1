using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_14_1_Jeremy_Belisle
{
    public partial class Project_14_1 : Form
    {
        public Project_14_1()
        {
            InitializeComponent();
        }
        //creating variables to be used for the form
        decimal resultValue = 0;
        decimal buttonA = 0;
        decimal buttonB = 0;
        String operatorSymbol = "";
        bool operationCheck = false;
        decimal memoryStore = 0;

        //a method to enter the number buttons 
        private void EnterValue_Click(object sender, EventArgs e)
        {
            //try catch block to catch overflow exception
            try
            {
                //assigning the button class to get the value of the button pressed
                Button button = (Button)sender;
                //this will make sure value A is assigned by making sure operationCheck is false
                if (!operationCheck)

                {
                    if (button.Text == ".")//accounting for if the user wants a decmial to start
                    {
                        if (!txtResult.Text.Contains("."))
                            txtResult.Text = txtResult.Text + button.Text;
                    }
                    else
                    {
                        buttonA = Convert.ToDecimal(txtResult.Text + button.Text);
                        txtResult.Text = txtResult.Text + button.Text;
                    }

                }
                //if an operator has been selected, it will then assign a vlaue to number B
                else
                {
                    if (button.Text == ".")
                    {
                        if (!txtResult.Text.Contains("."))//accounting for if the user wants a decmial to start
                        {
                            txtResult.Text = txtResult.Text + button.Text;
                        }
                    }
                    else
                    {
                        buttonB = Convert.ToDecimal(txtResult.Text + button.Text);
                        txtResult.Text = txtResult.Text + button.Text;
                    }

                }
            }//catching the overFlowException, and showing a message box
            catch (OverflowException)
            {
                MessageBox.Show("Number must be less than 30 numbers",
                  "Error".ToString());
            }
        }
        //a method to keep track of the current operator
        private void operator_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            //if the operator is blank, it will than check to see if number A is 0
            if (operatorSymbol.Equals(""))
            {
                //is number A is 0 it will not assign a operator to the variable 

                if (txtResult.Text == "")
                {
                    operatorSymbol = "";
                }

                else if (buttonA == 0)
                {
                    buttonA = memoryStore;
                    operationCheck = true;
                    txtResult.Clear();
                    operatorSymbol = button.Text;
                }

                //if number A has a value, it will assign an operator vlaue to the variable
                else
                {
                    
                    operationCheck = true;
                    txtResult.Clear();
                    operatorSymbol = button.Text;
                }
            }//if the operator variable has a value, it will start assigning a value to number B
            else
            {
                txtResult.Clear();
                operatorSymbol = button.Text;
            }

        }

        //a method to calculate the values
        private void calculate_Click(object sender, EventArgs e)
        {
            //try catch block to catch divide by 0
            try
            {
                //calls the Calculator class to calculate the request
                resultValue = (Calculator.calculate(buttonA, buttonB, operatorSymbol));
                //displays the result
                txtResult.Text = Convert.ToString(resultValue);
                //assigns a hold value to button A so the user can add on to the value if needed
                buttonA = resultValue;
            }//catching the divide by 0
            catch (DivideByZeroException)
            {
                MessageBox.Show("Can't Divide by Zero",
                  "Error".ToString());
            }
        }

        //a clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            operatorSymbol = "";
            buttonA = 0;
            buttonB = 0;
            resultValue = 0;
            operationCheck = false;
        }
        //a back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            //try catch to catch if the user trys to delete a number when there is no numbers in the text box
            try
            {
                if (!operationCheck)
                {
                    //assigning a variable to store the last postion of the number minus 1
                    int lastCharacterPosition = txtResult.TextLength - 1;
                    //displaying the number
                    txtResult.Text = txtResult.Text.Remove(lastCharacterPosition, 1);
                    //assigning the value to button A
                    if (txtResult.Text != "")
                        buttonA = Convert.ToDecimal(txtResult.Text);
                }
                else
                {
                    int lastCharacterPosition = txtResult.TextLength - 1;
                    txtResult.Text = txtResult.Text.Remove(lastCharacterPosition, 1);
                    if (txtResult.Text != "")
                        buttonB = Convert.ToDecimal(txtResult.Text);

                }
            }//catching the exception
            catch (Exception)
            {
               // MessageBox.Show("No Numbers to Delete",
                 // "Error".ToString());
            }

        }

        //a call to Calculator class to get the caluations for rediprocal
        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            //try catch to catch if theres not a number in the display
            try
            {
                Calculator.btnReciprocal(txtResult);
            }
            catch (SystemException)
            {
                MessageBox.Show("Please Enter a Number First",
                  "Error".ToString());
            }

        }

        //calling for sqrt method in calcalator class
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            //try catch to catch if theres not a number in the display
            try
            {
                Calculator.btnSqrt(txtResult);
            }
            catch (SystemException)
            {
                MessageBox.Show("Please Enter a Number First",
                  "Error".ToString());
            }

        }

        //calling for plus minus method in calcalator class
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {

            try
            {
                //checking for which number to change the value of
                if (!operationCheck)
                {
                    Calculator.btnPlusMinus(txtResult);
                    buttonA = Convert.ToDecimal(txtResult.Text);
                }
                else
                {
                    Calculator.btnPlusMinus(txtResult);
                    buttonB = Convert.ToDecimal(txtResult.Text);
                }
            }

            catch (SystemException)
            {
                MessageBox.Show("Please Enter a Number First",
                  "Error".ToString());
            }

        }

        //getting input from the keyboard
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //each switch statement is set to equal what has been pressed on the keyboard
            switch (e.KeyChar.ToString())
            {
                case "0":
                    btn0.PerformClick();
                    break;
                case "1":
                    btn1.PerformClick();
                    break;
                case "2":
                    btn2.PerformClick();
                    break;
                case "3":
                    btn3.PerformClick();
                    break;
                case "4":
                    btn4.PerformClick();
                    break;
                case "5":
                    btn5.PerformClick();
                    break;
                case "6":
                    btn6.PerformClick();
                    break;
                case "7":
                    btn7.PerformClick();
                    break;
                case "8":
                    btn8.PerformClick();
                    break;
                case "9":
                    btn9.PerformClick();
                    break;
                case "+":
                    btnPlus.PerformClick();
                    break;
                case "-":
                    btnMinus.PerformClick();
                    break;
                case "*":
                    btnMultiply.PerformClick();
                    break;
                case "/":
                    btnDivide.PerformClick();
                    break;
                case "=":
                    btnCalculate.PerformClick();
                    break;
                case ".":
                    btnDecimal.PerformClick();
                    break;
                default:
                    break;

            }

            //checking if the back button has been pressed, if so it will call the back method 
            if (e.KeyChar == (char)Keys.Back)
                btnBack.PerformClick();
        }
        //calling the memory store from the MemoryCalculator class
        private void btnMS_Click(object sender, EventArgs e)
        {
            try
            {
                memoryStore = MemoryCalculator.MemoryStore(txtResult);
                //changing the txtbox to have M
                txtMBox.Text = "M";
            }
            catch (SystemException)
            {
                MessageBox.Show("Please Enter a Number First",
                  "Error".ToString());
            }
        }

        //calling the 
        private void btnMR_Click(object sender, EventArgs e)
        {
            memoryStore = MemoryCalculator.MemoryRecall(memoryStore);
            txtResult.Text = Convert.ToString(memoryStore);
            decimal hold = 0;
            //making sure the used can use this vlaue as button B
            if(buttonB == 0)
            {
                buttonB = memoryStore;
            }
            //letting the suer add this to their calculation
            else if (buttonB != 0 & buttonA != 0)
            {
                hold = memoryStore + buttonA;
                txtResult.Text = Convert.ToString(hold);
            }
        }
        //MC clears the value
        private void btnMC_Click(object sender, EventArgs e)
        {
            memoryStore = MemoryCalculator.MemoryClear(memoryStore);
            txtMBox.Text = "";
        }

        //M+ adds to the current value
        private void btnMPlus_Click(object sender, EventArgs e)
        {
            try
            {
                memoryStore = MemoryCalculator.MemoryAdd(txtResult, memoryStore);
            }
            catch (SystemException)
            {
                MessageBox.Show("Please Save a Number First",
                  "Error".ToString());
            }
        }
    }
}

