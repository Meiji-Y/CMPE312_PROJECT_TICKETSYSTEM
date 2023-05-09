using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Security.Claims;
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

    public partial class CheckoutPage : Window
    {
        public List<string> ttime = new List<string> { "13:40", "15:20", "18:30", "20:15", "22:25" };
        private int CId;
        public byte[] MovieImage;
        
        public CheckoutPage(int CId, int MId, string MovieName, string MovieType, string MovieSummary, string MovieLanguage, int MovieDuration, byte[] MovieImage)
        {
            InitializeComponent();
            SqlConnection sqlConnection;
            string connectionString = ConfigurationManager.ConnectionStrings["CMPE312_PROJECT_TICKETSYSTEM.Properties.Settings.TicketSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            
            string UserPassword = PasswordTextBox.Password;        // Payment Failed hatası geliyor çünkü UserPassword "", buraya bakkk !           
            
            string CreditCard = CreditCardTextBox.Text;
            this.CId = CId;
            this.MovieImage = MovieImage;

            var items = ttime;
            foreach (var item in items)
            {

                ComboBoxData.Items.Add(item);
            }

            MovieNameText.Content = MovieName;
            
            
            string MovieTime = ComboBoxData.Text;

            string query = "SELECT UserPassword FROM Customers WHERE CId=@CId ";
           


            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@CId", CId);
            command.Parameters.AddWithValue("@UserPassword", UserPassword);
            sqlConnection.Open();
            var result = (string)command.ExecuteScalar();
            sqlConnection.Close();


            if (MovieImage != null)
            {
                // Base64 kodunu byte dizisine dönüştürüyoruz
                //byte[] imageBytes = Convert.FromBase64String(MovieImage);

                // byte dizisini BitmapImage nesnesine dönüştürüyoruz
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(MovieImage);
                bitmapImage.EndInit();

                // Image kontrolünün Source özelliğine BitmapImage nesnesini atıyoruz
                ImageBox.Source = bitmapImage;
            }
        }
    

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MoviesPage MoviesPage = new MoviesPage(CId);
            MoviesPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            DateTime selectedDate;
            if (DatePickerData.SelectedDate.HasValue)
            {
                selectedDate = DatePickerData.SelectedDate.Value;
                // selectedDate değişkeni, seçilen tarih değeri ile dolu olacak.
            }
            else
            {
                // Seçilen bir tarih yoksa, kullanıcıya bir hata mesajı gösterilebilir.
                MessageBox.Show("Please select date.");
            }


            //if (result == UserPassword)
            //{
            //    MessageBox.Show("Payment is Completed");
            //    this.Close();

            //}
            //else
            //{
            //    // Login başarısız
            //    MessageBox.Show("Payemnt is Failed !");
            //}

        }

     
    }
}
