using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POE
{
    /// <summary>
    /// Interaction logic for SavingsPage.xaml
    /// </summary>
    public partial class SavingsPage : Window
    {
        //variables to store values from the textboxes
        public double SavingAmount;
        public string reason;
        public int Time;
        public double Interest;


        public SavingsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //getting all the expenses from the other Windows and adding them all up into one variable
            double TotalExpenses = MainWindow.TotalExpenses + PropertyInfo.RentalAmount + VehicleInfo.Repayment;
            MessageBox.Show("All Your Expenes Combined Are  R" + TotalExpenses,"TOTAL EXPENSES", MessageBoxButton.OK, MessageBoxImage.Information);

            //warning for when the expenses exceed 75% of the total Income
            if (TotalExpenses > 0.75 * MainWindow.Income)
            {
                //message box that will show if the user answers the question with alphabets,character or leaves an empty space
                //instead of a 0 
                MessageBox.Show("YOUR TOTAL EXPENSES EXCEED 75% OF INCOME, This Is Considered As A Characteristic Of Unhealthy Money Management", 
                    "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //Assigning user answers from textboxes to variables
                SavingAmount = Convert.ToDouble(SaveAmounttxt.Text);
                reason = Reasontxt.Text;
                Interest = Convert.ToDouble(InterestRateTxt.Text);
                //saving goal calculation
                double Goal = SavingAmount / Time / 12;
                double Percentage = Interest / 100;
                double Final = Goal + Percentage;


                MessageBox.Show("To Reach Your Saving Goal (" + reason + ") You Should Save R" + Final + " Each Month For " + 12 * Time + " Months", "SAVING INFO", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                //message box that will show if the user answers the question with alphabets,character or leaves an empty space
                //instead of a 0 
                MessageBox.Show("Please Answer Questions With Numbers Only. Remove Any Alphabet, Special Characters or Empty Space In The Answers Thanks You",
               "UNABLE TO SUBMIT!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }




        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        //assigning the number of years to what the slider value is
         Time = Convert.ToInt32(slidervaluetxt.Text = Slider.Value.ToString());

            
        }
    }
}
