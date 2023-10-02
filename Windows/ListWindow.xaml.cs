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
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        User user;
        public ListWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
