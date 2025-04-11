using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Szamitogepek
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (beleptet(Felhasznalo.Text, jelszo.Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
        }

        private bool beleptet(string username, string password)
        {
            
                
            try
            {
                string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT 'Id' FROM 'usertable' WHERE 'UserName' = @username AND 'Password'= @password";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    bool van = dr.Read();
                    connection.Close();
                    return van;
                }
            }
            catch
            {
                return false;
            }
        }


    }

    
}
