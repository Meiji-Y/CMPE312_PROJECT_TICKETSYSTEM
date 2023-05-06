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
    /// <summary>
    /// MovieDetailPage.xaml etkileşim mantığı
    /// </summary>
    public partial class MovieDetailPage : Window
    {
        public MovieDetailPage(int MId, string MovieName, string MovieType, string MovieSummary, string MovieLanguage, int MovieDuration, string MovieImage)
        {
            InitializeComponent();

            MovieNameText.Content = MovieName;
            MovieTypeText.Content = MovieType;
            MovieSummaryText.Text = MovieSummary;
            MovieLanguageText.Content = MovieLanguage;
            MovieDurationText.Content = MovieDuration;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoviesPage MoviesPage = new MoviesPage();
            MoviesPage.Show();
            this.Close();
        }
    }
}
