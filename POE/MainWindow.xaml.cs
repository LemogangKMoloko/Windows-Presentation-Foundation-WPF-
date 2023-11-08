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

namespace POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variables to store income details
        public static double Income;
        public static double Tax;
        //variables to store all the expenses
        public static double WaterNlights;
        public static double groceries;
        public static double Travel;
        public static double OtherThings;
        public static double Cellphone;
        //a variable to store the total cost of all the expenses
        public static double TotalExpenses;
        public MainWindow()
        {
            InitializeComponent();

        }
       
        //event handler method for when the Save and submit button is pressed
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //storing all the values in the textBoxes in their appropriate Variables
                Income = Convert.ToDouble(monthlyIncTxtbox.Text);
                Tax = Convert.ToDouble(TaxTextbox.Text);
                WaterNlights = Convert.ToDouble(WaterNLightsTextbox.Text);
                groceries = Convert.ToDouble(GroceriesTextbox.Text);
                Travel = Convert.ToDouble(TravelTextbox.Text);
                OtherThings = Convert.ToDouble(OtherThingstxt.Text);
                Cellphone = Convert.ToDouble(CellphoneTxt.Text);
                //adding up all the Expenses to one variable
                TotalExpenses = WaterNlights + groceries + Travel + OtherThings + Cellphone + Tax;
                MessageBox.Show("Answers are saved succesfully, You may move to the Property section","SUBMISSION CONFIRMATION");

            }catch(Exception)
            {
            MessageBox.Show("Please Answer Questions With Numbers Only. Remove Any Alphabet, Special Characters or Empty Space In The Answer Thank You", 
                "UNABLE TO SUBMIT!!", MessageBoxButton.OK,MessageBoxImage.Error);


            }
        }
        //event handler method for the NEXT button is preesed
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this code opens up the next window
            PropertyInfo NewPage = new PropertyInfo();
            NewPage.Show();

            
        }

       
    }
}
