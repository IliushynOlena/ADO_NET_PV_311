﻿using _02_CRUD_Interface;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        SportShopDb sportShop = null;
        public MainWindow()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SportShopDbConnection"]
                .ConnectionString;
            sportShop = new SportShopDb(connectionString);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = sportShop.GetALL();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}