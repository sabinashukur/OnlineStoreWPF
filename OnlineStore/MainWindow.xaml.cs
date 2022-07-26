using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStore
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        EditWindow editWindow;
        public ObservableCollection<Product> ProductsCopy { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Products = new ObservableCollection<Product>
            {
                new Product{ Name="Snickers", Price= 1.20, ImageUrl="Images/snickers.jpg"},
                new Product{ Name="Coca-Cola", Price=2.10,ImageUrl="Images/cola.jpg"},
                new Product{ Name="Mars", Price=1.30, ImageUrl="Images/mars.jpg"},
                new Product{ Name="Adicto", Price=1.70, ImageUrl="Images/adicto.jpg"},
                new Product{ Name="Lipton", Price=1.90, ImageUrl="Images/lipton.jpg"}
            };
            ProductsCopy = Products;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            editWindow = new();
            editWindow.Visibilty = "Visible";
            editWindow.Show();
        }
        private void txbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txbSearch.Text.Length != 0 && txbSearch.Text != "Search")
            {
                string searchText = txbSearch.Text.ToLower();
                List<Product> productsList = new();
                productsList = ProductsCopy.Where(p => p.Name.ToLower().StartsWith(searchText)).ToList();
                ObservableCollection<Product> newList = new(productsList);
                Products = newList;
                lbox_products.ItemsSource = newList;
            }
            else if (txbSearch.Text.Length == 0)
            {
                Products = ProductsCopy;
                lbox_products.ItemsSource = Products;
            }
        }
        private void lbox_products_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            editWindow = new();
            editWindow.Product = (sender as ListBox).SelectedItem as Product;
            editWindow.Visibilty = "Hidden";
            editWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
