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

namespace WPF_13_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentText;
        private double lastNumber;
        private Operation lastOperation;

        public MainWindow()
        {
            InitializeComponent();
            currentText = "0";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            string currentBtn = ((Button)sender).Content.ToString();

            if (currentText == "0")
                currentText = currentBtn;
            else
                currentText += currentBtn;

            Render();
        }

        private void Render()
        {
            DisplayTB.Text = currentText;
        }

        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            string decimalDot = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (!currentText.Contains(decimalDot))
            {
                currentText += decimalDot;
            }

            Render();
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            currentText = "0";
            Render();
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentText == "0")
                return;

            currentText = Convert.ToString(double.Parse(currentText) * -1);
            Render();
        }

        private void PrecentBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal = double.Parse(currentText);
            double nextVal = SimpleMath.Percent(currentVal);
            currentText = Convert.ToString(nextVal);

            Render();
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = double.Parse(currentText);
            currentText = "0";

            if (sender == PlusBtn)
                lastOperation = Operation.Addition;
            else if (sender == MinusBtn)
                lastOperation = Operation.Subtraction;
            else if (sender == MultiplyBtn )
                lastOperation = Operation.Multiplication;
            else if (sender == DivisionBtn)
                lastOperation = Operation.Division;

            Render();
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber = double.Parse(currentText);

            double result = 0;

            switch (lastOperation)
            {
                case Operation.Addition:
                    result = SimpleMath.Add(lastNumber, currentNumber);
                    break;
                case Operation.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, currentNumber); break;
                case Operation.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, currentNumber);
                    break;
                case Operation.Division:
                    result = SimpleMath.Divide(lastNumber, currentNumber);
                    break;
            }

            currentText = Convert.ToString(result);
            Render();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Add:
                    OperationBtn_Click(PlusBtn, null);
                    break;
                case Key.Subtract:
                    OperationBtn_Click(MinusBtn, null);
                    break;
                case Key.Multiply:
                    OperationBtn_Click(MultiplyBtn, null);
                    break;
                case Key.Divide:
                    OperationBtn_Click(DivisionBtn, null);
                    break;

                case Key.NumPad0:
                    NumberBtn_Click(ZeroBtn, null);
                    break;

                //atd.
            }
        }
    }
}
