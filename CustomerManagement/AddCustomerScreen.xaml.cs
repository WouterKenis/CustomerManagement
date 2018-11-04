using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CustomerManagement
{

    public partial class AddCustomerScreen : Window
    {
        private string connectionString;
        MainWindow main;
        List<Customer> customers;

        public AddCustomerScreen(MainWindow main, List<Customer> customers)
        {
            InitializeComponent();

            this.main = main;
            this.customers = customers;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf;Integrated Security=True";
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Customers (Id, FirstName, LastName, Address, Postcode, Country, Phonenumber, Email)" +
                           "Values (@Id, @Firstname, @Lastname, @Address, @Postcode, @Country, @Phonenumber, @Email)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = getRowCount() + 1;
            command.Parameters.Add("@Firstname", SqlDbType.VarChar, 50).Value = firstNameBox.Text;
            command.Parameters.Add("@Lastname", SqlDbType.VarChar, 50).Value = lastNameBox.Text;
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = addressBox.Text;
            command.Parameters.Add("@Postcode", SqlDbType.VarChar, 50).Value = postcodeBox.Text;
            command.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = countryBox.Text;
            command.Parameters.Add("@Phonenumber", SqlDbType.VarChar, 50).Value = phoneNumberBox.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = emailBox.Text;

            connection.Open();

            try
            {
                
                command.ExecuteNonQuery();
                MessageBox.Show("Customer added.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            //SqlConnection connectionUpdate = new SqlConnection(connectionString);

            //SqlCommand commandUpdate = new SqlCommand();
            //commandUpdate.Connection = connectionUpdate;
            //commandUpdate.CommandText = "select * from Customers";

            //connectionUpdate.Open();

            //SqlDataReader reader = commandUpdate.ExecuteReader();
            //customers = new List<Customer>();

            //int firstName = reader.GetOrdinal("FirstName");
            //int lastName = reader.GetOrdinal("LastName");
            //int address = reader.GetOrdinal("Address");
            //int postcode = reader.GetOrdinal("Postcode");
            //int country = reader.GetOrdinal("Country");
            //int phoneNumber = reader.GetOrdinal("Phonenumber");
            //int email = reader.GetOrdinal("Email");

            //while (reader.Read())
            //{
            //    Customer customer = new Customer(reader.GetString(firstName), reader.GetString(lastName));

            //    customer.Address = reader.GetString(address);
            //    customer.Postcode = reader.GetString(postcode);
            //    customer.Country = reader.GetString(country);
            //    customer.Phonenumber = reader.GetString(phoneNumber);
            //    customer.Email = reader.GetString(email);

            //    customers.Add(customer);
            //}

            //connection.Close();

            Customer addedCustomer = new Customer(firstNameBox.Text, lastNameBox.Text);
            addedCustomer.Address = addressBox.Text;
            addedCustomer.Country = countryBox.Text;
            addedCustomer.Email = emailBox.Text;
            addedCustomer.Phonenumber = phoneNumberBox.Text;
            addedCustomer.Postcode = postcodeBox.Text;

            customers.Add(addedCustomer);

            main.allCustomersComboBox.ItemsSource = customers;
            main.allCustomersComboBox.SelectedIndex = main.allCustomersComboBox.Items.Count - 1;

            main.customers = customers;
            Close();

        }

        private int getRowCount()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select count(*) from Customers";

            SqlConnection connectionRowCount = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }
    }
}
