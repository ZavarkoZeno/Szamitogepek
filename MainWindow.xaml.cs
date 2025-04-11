using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Szamitogepek
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

        
        private void Szmito_Lekerdezes()
        {
            string connectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

            using (var connection = new MySqlConnection(ConnectionString))
            {

                try
                {
                    string sql = "SELECT * FROM osystem";

                    connection.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGrid.ItemsSource = dt.DefaultView;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MenuComp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Számítógépek");
            Szmito_Lekerdezes();
        }

        private void Ops_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OP Rendszerek");
            OPR_Lekerdezes();
        }
        private void OPR_Lekerdezes()
        {
            string connectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = $"SELECT * FROM 'comp';";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        sqlListBox.Items.Add(dr["Type"].ToString());
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt: {ex.Message}");
                }
            }
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
