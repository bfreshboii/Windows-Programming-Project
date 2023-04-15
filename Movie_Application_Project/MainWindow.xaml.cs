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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Movie_Application_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    ///Hi
    public partial class MainWindow : Window
    {
        private Page directorsPage;
        //public Pages.DirectorsPage directorsPage { get; set; }
        public Pages.MoviesPage moviesPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            directorsPage = new Pages.DirectorsPage();
            moviesPage = new Pages.MoviesPage();


            //Just for testing Directors Page, while it is not configured (Gabriel)
            mainFrame.NavigationService.Navigate(moviesPage);
        }
    }
}
