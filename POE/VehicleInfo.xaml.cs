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
    /// Interaction logic for VehicleInfo.xaml
    /// </summary>
    public partial class VehicleInfo : Window
    {
        //variables to store values from text boxes
        public double CarPurchasePrcise;
        public double CarInterest;
        public double Insurance;
        public double Cardeposit;
        public string CarModel;
        public static double Repayment;
        public static double deductions;

       
        public VehicleInfo()
        {
            InitializeComponent();
        }

        //event handler method for when the car submit button is pressed
        //stores all the values inside text boxes to variables
        private void CarAnswersBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //variable to store ALL the expenses
                double TotalExpenses;

                Insurance = Convert.ToDouble(CarInsuranceTxt.Text);
                Cardeposit = Convert.ToDouble(CarDepositTxt.Text);
                CarPurchasePrcise = Convert.ToDouble(CarPpriceTxt.Text);
                CarInterest = Convert.ToDouble(CarInterestRateTxt.Text);
                CarModel = CarModelNMakeTxt.Text;
                //car monthly repayement calculation
                Repayment = (CarPurchasePrcise - Cardeposit) * (1 + CarInterest / 100 * 5 / 12);
                Repayment = Repayment / 5;

                //getting all the expenses from the other Windows and adding them all up into one variable
                TotalExpenses = MainWindow.TotalExpenses + PropertyInfo.RentalAmount + Repayment;

              //subission confirmation
                MessageBox.Show("VEHICLE Info Captured Succesfully, You May Move To The SAVINGS CALCULATOR", "SUBMISSION CONFIRMATION");
                MessageBox.Show("vehicle monthly repayements for the vehicle (" + CarModel + ") are R" + Repayment/12 + " every Month for 60 Months(5 Years)", "VEHICLE MONTHLY REPAYEMENTS");


            }
            catch (Exception)
            {
                //message box that will show if the user answers the question with alphabets,character or leaves an empty space
                //instead of a 0 
                MessageBox.Show("Please Answer Questions With Numbers Only. Remove Any Alphabet, Special Characters or Empty Space In The Answers Thanks You",
              "UNABLE TO SUBMIT!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DisplayBtn_Click(object sender, RoutedEventArgs e)
        {
            //getting all the expenses from the other Windows and adding them all up into one variable
            double TotalExpenses = MainWindow.TotalExpenses +PropertyInfo.RentalAmount + Repayment;
            deductions = MainWindow.Income - TotalExpenses;

            MessageBox.Show("The Money Thats Left After All Deductions Is R" + deductions  + " Please Move To SAVINGS CALCULATOR, So You Know How Much You Need To Save For A Specific Goal", "TOTAL EXPENSES", MessageBoxButton.OK,MessageBoxImage.Information);
           
            //warning for when the expenses exceed 75% of the total Income
            if (TotalExpenses > 0.75 * MainWindow.Income)
            {
                    MessageBox.Show("YOUR TOTAL EXPENSES EXCEED 75% OF INCOME, This Is Considered As A Characteristic Of Unhealthy Money Management", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void SavingsButton_Click(object sender, RoutedEventArgs e)
        {
            SavingsPage SP = new SavingsPage();
            SP.Show();
            
        }
    }
}
