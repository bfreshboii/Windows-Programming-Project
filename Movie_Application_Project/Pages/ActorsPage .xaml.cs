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
            Name name = _context.Names.Find(100);
            _context.Entry(name)
                    .Collection(p => p.Principals)
                    .Query()
                    .Where(p => p.JobCategory.Contains(textSearch.Text))
                    .Load();


            var query =
                from p in _context.Principals
                select p;

            actorsViewSource.Source = query.ToList();

        }
    }
}
