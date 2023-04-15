using Movie_Application_Project.Pages;
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
        public Pages.DirectorsPage directorsPage { get; set; }
        public Pages.MoviesPage moviesPage { get; set; }
        public Pages.HomePage homePage { get; set; } 
        
        public MainWindow()
        {
            InitializeComponent();
            directorsPage = new Pages.DirectorsPage();
            moviesPage = new Pages.MoviesPage();
            homePage = new Pages.HomePage();
            mainFrame.NavigationService.Navigate(homePage);



            //Just for testing Directors Page, while it is not configured (Gabriel)
            /**
             * Hi Gabriel and Mark, Just so we can test individually, I have created dir,
             * movie and actors btns for tesing.
             * */

        }

        private void DirectorBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(directorsPage);

        }
        private void MoviesBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(moviesPage);


        }
        private void ActorsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
