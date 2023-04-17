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
            // _context.Names.Load();
            //var query = _context.Names.Where(name => name.PrimaryName.Contains(txtSearch.Text)).ToList();
            //directorsListView.ItemsSource = query;

            //Name name = _context.Names.FirstOrDefault();
            //Genre genre = _context.Genres.Find(1);

            //_context.Entry(name)
            //_context.Entry(genre)


            //.Collection(p => p.Principals)
            //.Query()
            //.Where(t => t.JobCategory.Contains("director"))
            //.Select (p => p.Name)
            //.Load();





            var query = (from nam in _context.Names.Take(100)
                         join pri in _context.Principals on nam.NameId equals pri.NameId
                         where nam.PrimaryName.Contains(txtSearch.Text) && pri.JobCategory.Contains("director")
                         select nam).Distinct();



            //var query =
            //       from title in _context.Titles
            //        where title.PrimaryTitle.Contains(textsearch.Text) && (title.Names.Any(g => g.PrimaryName.Contains(selectedgenre ?? string.Empty)) || title.Names1.Any(g => g.PrimaryName.Contains(selectedgenre ?? string.Empty)))
            //        orderby title.PrimaryTitle
            //        select title;
            //


            // listTitlesSearchResults.Items.Clear();
            // foreach (var title in query.Take(500))
            //  {
            //     listTitlesSearchResults.Items.Add(title);
            //  }


            //var primaryProfessions = _context.Names.Select(n => n.PrimaryProfession).Distinct().ToList();
            directorsViewSource.Source = query.ToList();
            directorsListView.ItemsSource = query.ToList();
        }
    }
}
