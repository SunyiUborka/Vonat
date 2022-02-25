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
using VonatCommon.Models;
using VonatCommon.Repository;
using VonatCommon.RailwayException;

namespace VonatAdmin.View
{
    /// <summary>
    /// Interaction logic for NewCityPicker.xaml
    /// </summary>
    public partial class NewCityPicker : Window
    {
        private VonatContext vonat = VonatContext.Instance;
        public NewCityPicker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = vonat.Cities.FirstOrDefault(r => r.city.ToLower() == AddCityInput.Text.ToLower());

            if (s == null)
            {
                vonat.CreateCity(new Cities()
                {
                    city = AddCityInput.Text
                });
            }
            else
            {
                MessageBox.Show("Ilyen város már létezik!", "Exists", MessageBoxButton.OK);
            }
        }
    }
}
