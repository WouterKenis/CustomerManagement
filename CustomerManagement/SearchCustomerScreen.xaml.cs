using System.Collections.Generic;
using System.Windows;

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
