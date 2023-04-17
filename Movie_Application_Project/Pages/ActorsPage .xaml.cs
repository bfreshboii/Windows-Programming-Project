using Microsoft.EntityFrameworkCore;
using PROG2500_AF_IMDB.Project.Data;
using PROG2500_AF_IMDB.Project.Models;
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

namespace Movie_Application_Project.Pages
{
    /// <summary>
    /// Interaction logic for ActorsPage.xaml
    /// </summary>
    public partial class ActorsPage : Page

    {
        private Name name = new Name();
        private Principal principal = new Principal();

        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource actorsViewSource;
        public ActorsPage()
        {
            InitializeComponent();

            actorsViewSource = (CollectionViewSource)FindResource(nameof(actorsViewSource));
            actorsViewSource.Source = _context.Names.Local.ToObservableCollection();


        }
        public void btnSearchClicked(object sender, RoutedEventArgs e)
        {
            //Principal name = _context.Principals.Find();
            //_context.Entry(name)
            //        .Collection(p => p.Principal)
            

        
            var query = (
                from name in _context.Names.Take(200)
                         where name.PrimaryName.Contains(textSearch.Text) && name.PrimaryProfession.Contains("actor") 
                         select name).Distinct();

            actorsViewSource.Source = query.ToList();
            actorsListView.ItemsSource = query.ToList();

        }
    }
}
