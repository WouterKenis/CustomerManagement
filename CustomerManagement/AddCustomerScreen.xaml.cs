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
using System.Windows.Shapes;

namespace CustomerManagement
{

    public partial class AddCustomerScreen : Window
    {

        public AddCustomerScreen()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\Gebruiker\source\repos\CustomerManagement\CustomerManagement\Customers.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(ConnectionString);

            String query = "INSERT INTO dbo.Customers (First Name, Last Name, Address, Postcode, Country, Phonenumber, E-mail)" +
                           "Values (@Firstname, @Lastname, @Address, @Postcode, @Country, @Phonenumber, @Email)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@Firstname", SqlDbType.VarChar, 50).Value = firstNameBox.Text;
            command.Parameters.Add("@Lastname", SqlDbType.VarChar, 50).Value = lastNameBox.Text;
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = addressBox.Text;
            command.Parameters.Add("@Postcode", SqlDbType.VarChar, 50).Value = postcodeBox.Text;
            command.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = countryBox.Text;
            command.Parameters.Add("@Phonenumber", SqlDbType.VarChar, 50).Value = phoneNumberBox.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = emailBox.Text;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //main.allCustomersComboBox.ItemsSource
        }
    }
}
