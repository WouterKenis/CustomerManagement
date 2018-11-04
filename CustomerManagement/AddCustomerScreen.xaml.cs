using System;
using System.Collections.Generic;
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

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from table";

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer
            }
        }
    }
}
