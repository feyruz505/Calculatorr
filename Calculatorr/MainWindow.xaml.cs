using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatorr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double firstNumber;
        private double secondNumber;
        private string selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isDefaultText = true;
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (isDefaultText)
            {
                txtDisplay.Text = "";
                isDefaultText = false;
            }


            string number = (sender as Button).Content.ToString();
            txtDisplay.Text += number;


        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains(","))
            {
                txtDisplay.Text += ",";
            }
        }


        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {

            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Content.ToString();
            string textBoxText = txtDisplay.Text;
            lblLabel.Content = $"{textBoxText} {buttonText}";

            firstNumber = double.Parse(txtDisplay.Text);
            selectedOperator = (sender as Button).Content.ToString();
            txtDisplay.Text = string.Empty;




        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;
            switch (selectedOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    result = firstNumber / secondNumber;
                    break;
            }
            txtDisplay.Text = result.ToString();
        }


        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            lblLabel.Content = txtDisplay.Text;
        }



        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            if (txtDisplay.Text.Length == 0) ;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
            firstNumber = 0;
            secondNumber = 0;
            lblLabel.Content = "";

        }


        private void myTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void btnPlusMinus_Click(Object sender, EventArgs e)
        {

            if (double.Parse(txtDisplay.Text) > 0)
                txtDisplay.Text = txtDisplay.Text.Insert(0, "-");
            else
                txtDisplay.Text = (0 - double.Parse(txtDisplay.Text)).ToString();
        }


    }



}
