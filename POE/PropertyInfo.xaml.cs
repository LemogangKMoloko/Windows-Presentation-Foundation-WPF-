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
    /// Interaction logic for PropertyInfo.xaml
    /// </summary>
    public partial class PropertyInfo : Window
    {
        //variables to store all the property finance details
        public static double RentalAmount;
        public static double PurchasePrcise;
        public static double Interest;
        public static double Time;
        public static double Deposit;
        public static double Repayment;
        public PropertyInfo()
        {
            InitializeComponent();
        }
        //event handler method for when the rent submit button is pressed
        //stores the value inside the text box inside a variable
        public void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //submission confirmation
                RentalAmount = Convert.ToDouble(RentTxt.Text);
                MessageBox.Show("RENTAL Info Captured Succesfully, You May Move To The VEHICLE SECTION", "SUBMISSION CONFIRMATION");
            }
            catch (Exception)
            {
                //message box that will show if the user answers the question with alphabets,character or leaves an empty space
                //instead of a 0 
                MessageBox.Show("PLEASE ANSWER QUESTIONS WITH NUMBERS ONLY. REMOVE ANY ALPHABET, SPECIAL CHARACTERS or EMPTY SPACE IN THE ANSWERS THANK YOU",
              "UNABLE TO SUBMIT!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //event handler method for when the buy submit button is pressed
        //stores all the values inside the text boxes inside the variables
        public void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                PurchasePrcise = Convert.ToDouble(PurchasiPriceTxt.Text);
                Interest = Convert.ToDouble(InterestRateTxt.Text);
                Time = Convert.ToDouble(TimeTxt.Text);
                Deposit = Convert.ToDouble(DepositTxt.Text);

                //home  loan calculation
                Repayment = (PurchasePrcise - Deposit) * (1 + Interest / 100 * Time / 12);
                Repayment = Repayment / Time;
            }
            catch (Exception)
            {
                //message box that will show if the user answers the question with alphabets,character or leaves an empty space
                //instead of a 0 
                
                MessageBox.Show("Please Answer Questions With Numbers Only. Remove Any Alphabet, Special Characters or Empty Space In The Answer Thank You",
                 "UNABLE TO SUBMIT!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //if statement to calculate wheter the monthly repayements are more than a third of the users income
            if (Repayment > 0.33 * MainWindow.Income)
            {
                MessageBox.Show("please note: APPROVAL OF HOMELOAN UNLIKELY","NOTICE", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            
            MessageBox.Show("PROPERTY PURCHASE Info Captured Succesfully, You May Move To Vehicle Section", "SUBMISSION CONFIRMATION");
            MessageBox.Show("Your Monthly Home Repayents Are going to be R" + Repayment + " Every Month For " + Time + " Months", "MONTHLY HOME REPAYEMENTS");
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            //opening the vehicle info window if the user clicks on submit button for buying section

            VehicleInfo NextPage = new VehicleInfo();
            NextPage.Show();
        }

        private void Next1Btn_Click(object sender, RoutedEventArgs e)
        {
            //opening the vehicle info window if the user clicks on submit button for rental section
            VehicleInfo NextPage1 = new VehicleInfo();
            NextPage1.Show();
            


        }
    }
}
