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
        }

        private void AddRailway_OnClick(object sender, RoutedEventArgs e)
        {
            var railway = new Railways()
            {
                from = TbFrom.Text,
                to = TbTo.Text,
                distance = int.Parse(TbDis.Text)
            };
            var s = vonat.Railways.FirstOrDefault(r => r.from.ToLower() == railway.from.ToLower() && r.to.ToLower() == railway.to.ToLower() || r.from.ToLower() == railway.to.ToLower() && r.to.ToLower() == railway.from.ToLower());
            if (s == null)
            {
                vonat.Railways.Add(railway);
            }
            else
            {
                MessageBox.Show("Ilyen útvonal már létezik!", "Exists", MessageBoxButton.OK);
            }
        }
    }
}