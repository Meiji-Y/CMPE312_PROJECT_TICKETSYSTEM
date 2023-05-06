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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;


namespace CMPE312_PROJECT_TICKETSYSTEM
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //SqlConnection sqlConnection;
            InitializeComponent();
            //string connectionString = ConfigurationManager.ConnectionStrings["CMPE312_PROJECT_TICKETSYSTEM.Properties.Settings.TicketSystemDBConnectionString"].ConnectionString;
            //sqlConnection = new SqlConnection(connectionString);
            //// Veritabanı bağlantısını aç
            //sqlConnection.Open();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = "Server=DESKTOP-16LF7MC;Database=TicketSystemDB;";
            // Kullanıcının girdiği
            // ve şifre
            SqlConnection sqlConnection;
            string connectionString = ConfigurationManager.ConnectionStrings["CMPE312_PROJECT_TICKETSYSTEM.Properties.Settings.TicketSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            // Veritabanı bağlantısını aç
            

            string UserName = UnameTextbox.Text;
            string UserPassword = PasswordTextbox.Password;

            // SQL sorgusu: verilen e-postaya sahip müşterinin şifresini sorgula
            string query = "SELECT UserPassword FROM Customers WHERE UserName=@UserName";

            // SqlCommand nesnesini oluştur
            SqlCommand command = new SqlCommand(query, sqlConnection);

            // Parametreleri ayarla
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@UserPassword", UserPassword);

            // Bağlantıyı aç
            sqlConnection.Open();

            // Sorguyu çalıştır ve sonucu al
            var result =(string)command.ExecuteScalar();

            // Bağlantıyı kapat
            sqlConnection.Close();

            
            if (result == UserPassword )
            {
                // Login başarılı
                
                MoviesPage MoviesPage = new MoviesPage();
                MoviesPage.Show();
                MessageBox.Show("Login is Successful");
                this.Close();
                
            }
            else
            {
                // Login başarısız
                MessageBox.Show("Login is Failed !");
            }

        }


    }
}