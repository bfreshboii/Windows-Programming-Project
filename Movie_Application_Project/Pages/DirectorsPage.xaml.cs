using Microsoft.EntityFrameworkCore;
using PROG2500_AF_IMDB.Project.Data;
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
            _context.Names.Load();
            //-context.Directors.Load(); //Not Working. 

            directorsViewSource.Source = _context.Names.Local.ToObservableCollection();
            
        }

        private void DirectrosSearcButton_Click(object sender, RoutedEventArgs e)
        {

            var query =
                from name in _context.Names
                where name.PrimaryName.Contains(txtSearch.Text)
                select new
                {
                    name.PrimaryName,
                    name.PrimaryProfession,
                    
                };

            directorsListView.ItemsSource = query.ToList();

        }
    }
}
