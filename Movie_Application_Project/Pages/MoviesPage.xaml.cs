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
    /// Interaction logic for MoviesPage.xaml
    /// </summary>
    /// 
   
    public partial class MoviesPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource moviesViewSource;
        public MoviesPage()
        {
            InitializeComponent();
            moviesViewSource = (CollectionViewSource)FindResource(nameof(moviesViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Titles.Take(10000).Load();
            moviesViewSource.Source = _context.Titles.Local.ToObservableCollection();
        }

        private void btnSearchMovies_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from mov in _context.Titles.Take(1000)
                join rat in _context.Ratings on mov.TitleId equals rat.TitleId
                where mov.PrimaryTitle.Contains(textSearchSong.Text)
                select new
                {
                    title =  "Title: " + mov.OriginalTitle,
                    rating = "Rating: " + rat.AverageRating,
                    votes = "Votes: " + rat.NumVotes,
                    adult = "Is Adult Film?: " + mov.IsAdult,
                    run = "Runtime: " + mov.RuntimeMinutes,
                    genre = mov.Genres.ToList<Genre>(),
                    names = mov.Names.ToList<Name>()
                };
            moviesListView.ItemsSource = query.ToList();
        }
    }
}
