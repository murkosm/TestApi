using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TestApi.Classes;
using TestApi.DB;
using TestApi.Windows;

namespace TestApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ApplicationContext _db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
            _db.Database.Migrate();
        }
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var response = Methods.GetToken(login_box.Text, password_box.Text);
            if (response != "\"Такого пользователя не найдено\"" || response != "\"Ошибка при авторизации\"")
            {
                ListWindow listWindow = new ListWindow();
                listWindow.Show();
            }
            else MessageBox.Show("Неправильно введенные данные");



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.Regist regist = new Windows.Regist();
            regist.Show();
            Close();
        }
    }
}
