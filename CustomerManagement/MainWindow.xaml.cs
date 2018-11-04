using CustomerManagement;
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

            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Customers";

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();

            int firstName = reader.GetOrdinal("First Name");
            int lastName = reader.GetOrdinal("Last Name");
            int address = reader.GetOrdinal("Address");
            int postcode = reader.GetOrdinal("Postcode");
            int country = reader.GetOrdinal("Country");
            int phoneNumber = reader.GetOrdinal("Phonenumber");
            int email = reader.GetOrdinal("E-mail");

            while (reader.Read())
            {
                Customer customer = new Customer(reader.GetString(firstName), reader.GetString(lastName));

                customer.Address = reader.GetString(address);
                customer.Postcode = reader.GetString(postcode);
                customer.Country = reader.GetString(country);
                customer.Phonenumber = reader.GetString(phoneNumber);
                customer.Email = reader.GetString(email);

                customers.Add(customer);
            }

            allCustomersComboBox.ItemsSource = customers;
            allCustomersComboBox.SelectedIndex = allCustomersComboBox.Items.Count - 1;

            //Customer wouter = new Customer("Wouter", "Kenis");
            //wouter.Address = "Funnystreet 3";
            //wouter.Country = "Belgium";
            //wouter.Phonenumber = "0444444444";
            //wouter.Postcode = "3600";
            //wouter.Email = "none@ofyourbusiness.com";

            //Customer wouter2 = new Customer("W00ter", "Kenis");
            //wouter2.Address = "Funnystreet 3";
            //wouter2.Country = "Belgium";
            //wouter2.Phonenumber = "0444444444";
            //wouter2.Postcode = "3600";
            //wouter2.Email = "none@ofyourbusiness.com";

            //Customer wouter3 = new Customer("Clone", "Kenis");
            //wouter3.Address = "Funnystreet 3";
            //wouter3.Country = "Belgium";
            //wouter3.Phonenumber = "0444444444";
            //wouter3.Postcode = "3600";
            //wouter3.Email = "none@ofyourbusiness.com";

            //List<Customer> customerList = new List<Customer>();
            //customerList.Add(wouter);
            //customerList.Add(wouter2);
            //customerList.Add(wouter3);

            //allCustomersComboBox.ItemsSource = customerList;

            //allCustomersComboBox.SelectedIndex = allCustomersComboBox.Items.Count - 1;

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //update db, list, combobox
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

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //delete from db, list, combobox (last two are easy enough) :p
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomerScreen searchCustomerScreen = new SearchCustomerScreen();
            searchCustomerScreen.Show();
        }
    }
}
