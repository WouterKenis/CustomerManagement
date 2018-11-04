using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomerManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        List<Customer> customers;
        string connectionString;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

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

            string updateQry = "UPDATE Customers SET " +
                               "FirstName = @Firstname" + ", " +
                               "LastName = @Lastname" + ", " +
                               "Address = @Address" + ", " +
                               "Country = @Country" + ", " +
                               "Phonenumber = @Phonenumber" + ", " +
                               "Email = @Email" + " " +
                               "WHERE Id = @Id";

            SqlConnection connectionUpdate = new SqlConnection(connectionString);

            SqlCommand commandUpdate = new SqlCommand();
            commandUpdate.Connection = connectionUpdate;
            commandUpdate.CommandText = updateQry;

            connectionUpdate.Open();

            commandUpdate.Parameters.AddWithValue("@Id", allCustomersComboBox.SelectedIndex + 1);
            commandUpdate.Parameters.AddWithValue("@FirstName", firstNameBox.Text.Trim());
            commandUpdate.Parameters.AddWithValue("@LastName", lastNameBox.Text.Trim());
            commandUpdate.Parameters.AddWithValue("@Address", addressBox.Text.Trim());
            commandUpdate.Parameters.AddWithValue("@Country", countryBox.Text.Trim());
            commandUpdate.Parameters.AddWithValue("@Phonenumber", phoneNumberBox.Text.Trim());
            commandUpdate.Parameters.AddWithValue("@Email", emailBox.Text.Trim());

            try
            {
                commandUpdate.ExecuteNonQuery();
                MessageBox.Show("Updated.");

            }
            catch (Exception)
            {
                MessageBox.Show("Not Updated.");
            }
            finally
            {
                connectionUpdate.Close();
            }

            MessageBox.Show(customers[allCustomersComboBox.SelectedIndex].ToString());
            allCustomersComboBox.ItemsSource = null;
            allCustomersComboBox.ItemsSource = customers;


        }
        private void allCustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = (Customer)allCustomersComboBox.SelectedItem;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerScreen addCustomerScreen = new AddCustomerScreen(this);
            addCustomerScreen.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connectionDelete = new SqlConnection(connectionString);

            string deleteQry = "delete from Customers " +
                               "WHERE Id = @Id";

            SqlCommand commandDelete = new SqlCommand();
            commandDelete.Connection = connectionDelete;
            commandDelete.CommandText = deleteQry;

            commandDelete.Parameters.AddWithValue("@Id", allCustomersComboBox.SelectedIndex + 1);

            connectionDelete.Open();

            try
            {
                commandDelete.ExecuteNonQuery();
                MessageBox.Show("Deleted record.");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed.");
            }
            finally
            {
                connectionDelete.Close();
            }
            MessageBox.Show(customers[allCustomersComboBox.SelectedIndex] + " " + allCustomersComboBox.SelectedIndex);
            customers.RemoveAt(allCustomersComboBox.SelectedIndex);

            allCustomersComboBox.ItemsSource = null;

            allCustomersComboBox.ItemsSource = customers;
            allCustomersComboBox.SelectedIndex = allCustomersComboBox.SelectedIndex + 1;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomerScreen searchCustomerScreen = new SearchCustomerScreen();
            searchCustomerScreen.Show();
        }
    }
}
