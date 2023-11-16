using _1115.ViewModels;
using _1115.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _1115
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow View = new MainWindow();
            MainViewModel ViewModel=new MainViewModel();
            View.DataContext = ViewModel;
            View.Show();
        }
    }
}
