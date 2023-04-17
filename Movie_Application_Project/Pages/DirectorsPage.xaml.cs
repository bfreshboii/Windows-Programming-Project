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
    /// Interação lógica para DirectorsPage.xam
    /// </summary>
    public partial class DirectorsPage : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource directorsViewSource;

        public DirectorsPage()
        {
            InitializeComponent();
            directorsViewSource = (CollectionViewSource)FindResource(nameof(directorsViewSource));
            _context.Names.Take(100).Load();
            _context.Principals.Take(100).Load();
            directorsViewSource.Source = _context.Names.Local.ToObservableCollection();

        }

        private void DirectrosSearcButton_Click(object sender, RoutedEventArgs e)
        {


            var query = (from nam in _context.Names.Take(100)
                         join pri in _context.Principals on nam.NameId equals pri.NameId
                         where nam.PrimaryName.Contains(txtSearch.Text) && pri.JobCategory.Contains("director")
                         orderby nam ascending
                         select nam).Distinct();

            directorsViewSource.Source = query.ToList();
            directorsListView.ItemsSource = query.ToList();
        }
    }
}
