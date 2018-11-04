using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CustomerManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Customer wouter = new Customer("Wouter", "Kenis");
            wouter.Address = "Funnystreet 3";
            wouter.Country = "Belgium";
            wouter.Phonenumber = "0444444444";
            wouter.Postcode = "3600";
            wouter.Email = "none@ofyourbusiness.com";

            Customer wouter2 = new Customer("W00ter", "Kenis");
            wouter2.Address = "Funnystreet 3";
            wouter2.Country = "Belgium";
            wouter2.Phonenumber = "0444444444";
            wouter2.Postcode = "3600";
            wouter2.Email = "none@ofyourbusiness.com";

            Customer wouter3 = new Customer("Clone", "Kenis");
            wouter3.Address = "Funnystreet 3";
            wouter3.Country = "Belgium";
            wouter3.Phonenumber = "0444444444";
            wouter3.Postcode = "3600";
            wouter3.Email = "none@ofyourbusiness.com";

            List<Customer> customerList = new List<Customer>();
            customerList.Add(wouter);
            customerList.Add(wouter2);
            customerList.Add(wouter3);

            allCustomersComboBox.ItemsSource = customerList;

            allCustomersComboBox.SelectedIndex = allCustomersComboBox.Items.Count - 1;

            //string sqlCon = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf; Integrated Security = True";
            //using (SqlConnection conn = new SqlConnection(sqlCon))
            //{
            //    conn.Open();

            //    using (SqlCommand cmd = new SqlCommand("INSERT INTO Table (First Name, Last Name, Address, Postcode, Country, Phonenumber, E-mail) VALUES ('Wouter', 'Kenis','Funnystreet 3', '3600', 'Belgium', '0496220524', 'bla@gmail.com')"))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = conn;

            //        //cmd.Parameters.AddWithValue("@Open", textBox13.Text);
            //        //cmd.Parameters.AddWithValue("@High", textBox14.Text);
            //        //cmd.Parameters.AddWithValue("@Low", textBox15.Text);
            //        //cmd.Parameters.AddWithValue("@Close", textBox16.Text);

            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //    //g
            //    //CustomerManagement.Update(database.Stocks); //LINE***added later but still getting "Incorrect syntax near the keyword 'Open'."
            //}

            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

        }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Table (First Name, Last Name, Address, Postcode, Country, Phonenumber, E-mail) VALUES (Wouter, Kenis,Funnystreet 3, 3600, Belgium, 0496220524, da.wouter@gmail.com)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    //cmd.Parameters.AddWithValue("@Open", textBox13.Text);
                    //cmd.Parameters.AddWithValue("@High", textBox14.Text);
                    //cmd.Parameters.AddWithValue("@Low", textBox15.Text);
                    //cmd.Parameters.AddWithValue("@Close", textBox16.Text);

        }

        private void allCustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = (Customer)allCustomersComboBox.SelectedItem;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerScreen addCustomerScreen = new AddCustomerScreen();
            addCustomerScreen.Show();
        }
    }
}
