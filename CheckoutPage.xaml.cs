using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        public string UserPassword;
        public string result;
        public CheckoutPage(int CId, int MId, string MovieName, string MovieType, string MovieSummary, string MovieLanguage, int MovieDuration, string MovieImage)
        {
            InitializeComponent();
            SqlConnection sqlConnection;
            string connectionString = ConfigurationManager.ConnectionStrings["CMPE312_PROJECT_TICKETSYSTEM.Properties.Settings.TicketSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            UserPassword = (string)PasswordTextBox.Password;        // Payment Failed hatası geliyor çünkü UserPassword "", buraya bakkk !
            string CreditCard = CreditCardTextBox.Text;
            this.CId = CId;

            var items = ttime;
            foreach (var item in items)
            {

                ComboBoxData.Items.Add(item);
            }

            MovieNameText.Content = MovieName;
            
            
            string MovieTime = ComboBoxData.Text;

            string query = "SELECT UserPassword FROM Customers WHERE CId = @CId ";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@CId", CId);
            sqlConnection.Open();
             result = (string)command.ExecuteScalar();


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


            if (result == UserPassword)
            {
                MessageBox.Show("Payment is Completed");
                this.Close();

            }
            else
            {
                // Login başarısız
                MessageBox.Show("Payemnt is Failed !");
            }

        }

     
        //private void ComboBoxData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // var currentText = (sender as ComboBox).SelectedItem as string;

        //    if (this.ComboBoxData.SelectedValue.ToString().Equals("13.40"))
        //    {
        //        string datam = (string)"75";
        //        Price.Text = datam;
        //    }
        //    else if(this.ComboBoxData.SelectedValue.ToString().Equals("15.20"))
        //    {
        //        Price.Text = "70 ";
        //    }
        //    else if (ComboBoxData.SelectedValue.ToString() == "18.30")
        //    {
        //        Price.Text = "80 ";
        //    }
        //    else if (ComboBoxData.Text == "20.15")
        //    {
        //        Price.Text = "85 ";
        //    }
        //    else if (ComboBoxData.Text == "22.25")
        //    {
        //        Price.Text = "90 ";
        //    }
        //    else 
        //    {
        //        Price.Text = "";
        //    }
        //}

        //private void Price_TextChanged(object sender, TextChangedEventArgs e)
        //{


        //    if (ComboBoxData.SelectedIndex.ToString() == "13.40")
        //    {
        //        string datam = (string)"75";
        //        Price.Text = datam;
        //    }
        //    else if (ComboBoxData.SelectedIndex.ToString() == "15.20")
        //    {
        //        Price.Text = "70 ";
        //    }
        //    else if (ComboBoxData.SelectedIndex.ToString() == "18.30")
        //    {
        //        Price.Text = "80 ";
        //    }
        //    else if (ComboBoxData.SelectedIndex.ToString() == "20.15")
        //    {
        //        Price.Text = "85 ";
        //    }
        //    else if (ComboBoxData.SelectedIndex.ToString() == "22.25")
        //    {
        //        Price.Text = "90 ";
        //    }
        //    else
        //    {
        //        Price.Text = "";
        //    }

        //}
    }
}
