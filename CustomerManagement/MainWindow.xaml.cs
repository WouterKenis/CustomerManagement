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

            string sqlCon = @"Data Source=.\SQLEXPRESS;" +
                @"AttachDbFilename=|DataDirectory|\Customers.mdf;
                Integrated Security=True;
                Connect Timeout=30;
                User Instance=True";
            using (SqlConnection conn = new SqlConnection(sqlCon))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Table (First Name, Last Name, Address, Postcode, Country, Phonenumber, E-mail) VALUES (Wouter, Kenis,Funnystreet 3, 3600, Belgium, 0496220524, da.wouter@gmail.com)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    //cmd.Parameters.AddWithValue("@Open", textBox13.Text);
                    //cmd.Parameters.AddWithValue("@High", textBox14.Text);
                    //cmd.Parameters.AddWithValue("@Low", textBox15.Text);
                    //cmd.Parameters.AddWithValue("@Close", textBox16.Text);

                    cmd.ExecuteNonQuery();
                }
                //g
                //CustomerManagement.Update(database.Stocks); //LINE***added later but still getting "Incorrect syntax near the keyword 'Open'."
            }
        }
    }
}
