using Microsoft.EntityFrameworkCore.Diagnostics;
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
using TestApi.Classes;
using TestApi.DB;

namespace TestApi.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window

    {
        private static readonly ApplicationContext _db = new ApplicationContext();
        public ListWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var tokenDB = Methods.Get();
            var token = tokenDB.token;
            var listCity = Methods.GetCities(token);
            var listWeather = Methods.GetWeathers(token);
            var list = new List<CityWeather>();

            for (int i = 0; i < listCity.Count; i++)
            {
                list.Add(new CityWeather
                {
                    City = listCity[i].Name
                });
            }

            for (int i = 0; i < listWeather.Count; i++)
            {
                list[i].Temperature = listWeather[i].temperature;
            }
            lv_listview.ItemsSource = list;

        }

      
        

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
