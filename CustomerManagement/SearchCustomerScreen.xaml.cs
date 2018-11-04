using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Text;

namespace CustomerManagement
{

    public partial class SearchCustomerScreen : Window
    {
        private string connectionString;
        public SearchCustomerScreen()
        {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf;Integrated Security=True";
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> customerSearchResults = new List<Customer>();

            SqlConnection connectionLookUp = new SqlConnection(connectionString);

            string lookUpQry = "select * from Customers WHERE LastName = @LastName";

            SqlCommand commandLookUp = new SqlCommand();
            commandLookUp.Connection = connectionLookUp;
            commandLookUp.CommandText = lookUpQry.ToString();

            commandLookUp.Parameters.AddWithValue("@LastName", lastNameBox.Text.Trim());

            connectionLookUp.Open();

            SqlDataReader reader = commandLookUp.ExecuteReader();

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

                customerSearchResults.Add(customer);
            }

            connectionLookUp.Close();

            searchResults.ItemsSource = customerSearchResults;
            searchResults.SelectedIndex = 0;

        }

        private void searchResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataContext = (Customer)searchResults.SelectedItem;
        }
    }
}
