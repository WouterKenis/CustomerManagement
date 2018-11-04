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
using System.Windows.Shapes;

namespace CustomerManagement
{

    public partial class SearchCustomerScreen : Window
    {
        public SearchCustomerScreen()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> customerSearchResults = new List<Customer>();

            searchResults.ItemsSource = customerSearchResults;
        }
    }
}
