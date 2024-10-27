using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi
{
    public partial class MainPage : ContentPage
    {
        private string currentEntry = "";
        private double firstNumber = 0;
        private string? currentOperation = "";

        public MainPage()
        {
            InitializeComponent();
        }

        // Method to handle digit button clicks
        private void OnDigitClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                currentEntry += button.Text;
                Display.Text = currentEntry;
            }
        }

        // Method to handle operation button clicks
        private void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && double.TryParse(currentEntry.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out firstNumber))
            {
                currentOperation = button.Text;
                currentEntry = string.Empty;
            }
        }

        // Method to handle the equals button click
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentEntry.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double secondNumber))
            {
                double result = 0;
                switch (currentOperation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            Display.Text = "Error";
                            currentEntry = string.Empty;
                            return;
                        }
                        break;
                }
                Display.Text = result.ToString();
                currentEntry = string.Empty;
            }
        }

        // Method to handle the clear button click
        private void OnClearClicked(object sender, EventArgs e)
        {
            currentEntry = string.Empty;
            firstNumber = 0;
            currentOperation = string.Empty;
            Display.Text = "0";
        }
    }
}
