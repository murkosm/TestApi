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
using TestApi.Classes;

namespace TestApi.Windows
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }
        private void regist_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {

                login = login_box.Text,
                fio = fio_box.Text,
                password = password_box.Text

            };
            string response = Methods.register(user);
            if (response == "\"Пользователь успешно зарегистрирован\"")

                try
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            else
                MessageBox.Show(response);
          
        }

        private void log_in_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
