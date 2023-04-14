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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, RoutedEventArgs e)
        {
        
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-66PTOHK\SQLEXPRESS;Initial Catalog=floverShop;Integrated Security=True"); //строка подключения
                    conn.Open(); //открытие подключения
                    SqlCommand cmd = new SqlCommand("Select * from users where login='" + tbLogin.Text + "'  and password='" + pbPassword.Password + "'", conn); //команда для вывода всех элемены
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0) //поиск в бд
            {
                menu window1 = new menu();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно введен логин или пароль!");
                tbLogin.Text = "";
                pbPassword.Password = "";


                conn.Close();
            }
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
          
            register window1 = new register();
            window1.Show();
            this.Close();
        }
    }
}
