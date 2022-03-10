using System.Linq;
using System.Windows;
using VonatAdmin.Controller;
using VonatCommon.Models;
using VonatCommon.Repository;

namespace VonatAdmin.View
{
    public partial class NewRailway : Window
    {
        VonatContext vonat = VonatContext.Instance;
        public NewRailway()
        {
            InitializeComponent();
            foreach (var city in vonat.GetCities())
            {
                cbFrom.Items.Add(city.city);
                cbTo.Items.Add(city.city);
            }
        }

        private void AddRailway_OnClick(object sender, RoutedEventArgs e)
        {
            var railway = new Railways()
            {
                from = cbFrom.SelectedItem.ToString(),
                to = cbTo.SelectedItem.ToString(),
                distance = int.Parse(TbDis.Text)
            };
            var s = vonat.Railways.FirstOrDefault(r => r.from.ToLower() == railway.from.ToLower() && r.to.ToLower() == railway.to.ToLower() || r.from.ToLower() == railway.to.ToLower() && r.to.ToLower() == railway.from.ToLower());
            if (s == null)
            {
                vonat.CreateRailway(railway);
            }
            else
            {
                MessageBox.Show("Ilyen útvonal már létezik!", "Exists", MessageBoxButton.OK);
            }
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}