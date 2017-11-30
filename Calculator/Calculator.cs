/*
 * Name: Rutul Patel
 * Date: 30th November
 * Student Number : 200335158
 * Purpose: Inputs for the basic calculator to count and calculate 
 * Average, Compare numbers in between and find remainder of those numbers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        // Decalring 2 required variables for the operations
        decimal number1;
        decimal number2;



        /// <summary>
        /// This method will processed when Result button clicked 
        /// </summary>
        /// <param name="sender">Result Button</param>
        /// <param name="e">The Event</param>
        private void btnResult_Click(object sender, EventArgs e)
        {

            //if Operation is not selected
            if (cboOperations.SelectedItem == null)
            {
                MessageBox.Show("You have to select at least one Operation", "Missing Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboOperations.Focus();
            }

            //take the number1 input and parse it as decimal
            try
            {
                number1 = decimal.Parse(txtFirstNumber.Text.Trim());

                //take the number2 input and parse it as decimal
                try
                {
                    number2 = decimal.Parse(txtSecondNumber.Text.Trim());

                    // Swith case with Combo box with four different required cases
                    switch (cboOperations.SelectedIndex)
                    {
                        // case 0: is for Average of number 1 and number 2
                        // Printing all the number value with 2 decimal value 


                        case 0: txtResult.Text = "The average of " + number1.ToString("F") + " and " + number2.ToString("F") + "  is " +( (number1 + number2) / 2).ToString("F"); break;

                        //Case 1 : is for Greater operations
                        case 1:
                            if (number1 > number2)
                            {
                                txtResult.Text = "First number " + number1.ToString("F") + " is greater than Second Number  " + number2.ToString("F"); break;
                            }
                            else if (number2 > number1)
                            {
                                txtResult.Text = "Second Number " + number2.ToString("F") + " is greater than First Number " + number1.ToString("F"); break;
                            }
                            else
                            {
                                txtResult.Text = "First number "+number1.ToString("F") + " and " + "Second Number "+number2.ToString("F") + " is equal";
                            }
                            break;
                        // Case 2: is for smaller operations
                        case 2:

                            if (number1 < number2)
                            {
                                txtResult.Text = "First number " + number1.ToString("F") + " is smaller than Second Number  " + number2.ToString("F"); break;
                            }
                            else if (number2 < number1)
                            {
                                txtResult.Text = "Second Number " + number2.ToString("F") + " is smaller than First Number " + number1.ToString("F"); break;
                            }
                            else
                            {
                                txtResult.Text = "First number" + number1.ToString("F") + " and Second number " + number2.ToString("F") + " is equal";
                            }
                            break;

                        // Case 3 is for Remainder 
                        case 3:
                            //if remainder is not possible or if remainder is 0 then throw error
                            if ((number1 % number2) == 0)
                            {
                                MessageBox.Show("Your inputs Remainder is zero(0). Please change any number to count remainder", "Input error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSecondNumber.SelectAll();
                                txtSecondNumber.Focus();
                            }

                            // show the result with remainder
                            else
                            {
                                txtResult.Text = "we have" + number1.ToString("F") + " and " + number2.ToString("F") +  " and Remainder " + (number1 % number2).ToString("F");
                            }
                            break;
                    } //end of switch 

                } // end of second Try

                catch (FormatException inputFe)
                {

                    //if second number textbox is empty print empty message
                    if (txtSecondNumber.Text == String.Empty)
                    {
                        MessageBox.Show("Second Number is missing", "Missing Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSecondNumber.Focus();
                    }

                    // if number second number is not an Integer show error
                    else
                    {
                        MessageBox.Show("Your inputs must be a Real Numbers. Please check your Second Number", "Input error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSecondNumber.SelectAll();
                        txtSecondNumber.Focus();
                    }
                } //end of second catch

            } //end of first try

            catch (FormatException inputFe)
            {
                //if first number text box is empty print empty message
                if (txtFirstNumber.Text == String.Empty)
                {
                    MessageBox.Show("First Number is Missing", "Missing Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstNumber.Focus();
                }
                else
                {
                    MessageBox.Show("Your inputs must be a Real Numbers. Please check your First Number", "Input error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstNumber.SelectAll();
                    txtFirstNumber.Focus();
                }
            } //end of first catch 
        } // end of result button method

        /// <summary>
        /// This method will clear all the text boxes of number 1 and number 2
        /// </summary>
        /// <param name="sender">Clear Button</param>
        /// <param name="e"> Action event</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstNumber.Clear();
            txtSecondNumber.Clear();
            txtResult.Clear();
            cboOperations.SelectedItem.Equals(null);

        }

        /// <summary>
        /// This button will exit the programme
        /// </summary>
        /// <param name="sender">Exit Button</param>
        /// <param name="e">Action Event</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end of class

}

