﻿using CustomerManagement;
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
        List<Customer> customers;
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
            customers = new List<Customer>();

            int firstName = reader.GetOrdinal("FirstName");
            int lastName = reader.GetOrdinal("LastName");
            int address = reader.GetOrdinal("Address");
            int postcode = reader.GetOrdinal("Postcode");
            int country = reader.GetOrdinal("Country");
            int phoneNumber = reader.GetOrdinal("Phonenumber");
            int email = reader.GetOrdinal("Email");

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

            connection.Close();

            allCustomersComboBox.ItemsSource = customers;
            allCustomersComboBox.SelectedIndex = allCustomersComboBox.Items.Count - 1;

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
            AddCustomerScreen addCustomerScreen = new AddCustomerScreen(this, customers);
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
