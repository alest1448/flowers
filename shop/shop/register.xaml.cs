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
using System.Data.SqlClient;
using System.Data;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }
        public int AddUser(int id,string login, string password)
        {
            var check = -1;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-66PTOHK\SQLEXPRESS;Initial Catalog=floverShop;Integrated Security=True"); //строка подключениz
            conn.Open();
            string cndText = $"INSERT INTO users(idUser, login , password) VALUES('{id}', '{login}', '{password}');";
            SqlCommand cmd = new SqlCommand(cndText, conn);
            check = cmd.ExecuteNonQuery();

            conn.Close();
            return check;
        }
        private void btRegistrer_Click(object sender, RoutedEventArgs e)
        {
       

            if (AddUser(Convert.ToInt32(tbID.Text), tbLogin.Text, pbPassword.Password) > 0)
            {
                MessageBox.Show("Вы успешно зарегистрировались!");
                MainWindow window1 = new MainWindow();
                window1.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("No");

            }

        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window1 = new MainWindow();
            window1.Show();
            this.Close();
        }
    }
}
