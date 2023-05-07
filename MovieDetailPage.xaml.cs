using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CMPE312_PROJECT_TICKETSYSTEM
{

    public partial class MovieDetailPage : Window
    {
        private int CId;
        private int MId;
        private string MovieName;
        private string MovieType;
        private string MovieSummary;
        private string MovieLanguage;
        private int MovieDuration;
        private string MovieImage;

        public MovieDetailPage(int CId, int MId, string MovieName, string MovieType, string MovieSummary, string MovieLanguage, int MovieDuration, string MovieImage)
        {
            InitializeComponent();
            this.CId= CId;
            this.MId = MId;
            this.MovieName = MovieName;
            this.MovieType = MovieType;
            this.MovieSummary = MovieSummary;
            this.MovieLanguage = MovieLanguage;
            this.MovieDuration = MovieDuration;
            this.MovieImage = MovieImage;

            MovieNameText.Content = MovieName;
            MovieTypeText.Content = MovieType;
            MovieSummaryText.Text = MovieSummary;
            MovieLanguageText.Content = MovieLanguage;
            MovieDurationText.Content = MovieDuration;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoviesPage MoviesPage = new MoviesPage(CId);
            MoviesPage.Show();
            this.Close();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            CheckoutPage CheckoutPage = new CheckoutPage(CId, MId, MovieName, MovieType, MovieSummary, MovieLanguage, MovieDuration, MovieImage);
            CheckoutPage.Show();
            this.Close();
        }
    }
}