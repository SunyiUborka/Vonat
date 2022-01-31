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
using System.IO;
using VonatAdmin.Models;


namespace VonatAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdminRepository db = new AdminRepository("Server=localhost;Port=9999;Database=Vonat;Uid=root;Pwd=Aa123456@;");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("railways.txt"))
            {
                StreamReader sr = new StreamReader("railways.txt");

                while (!sr.EndOfStream)
                {
                    string[] d = sr.ReadLine().Split(';');
                    var railway = new Railways();
                    railway.from = d[0];
                    railway.to = d[1];
                    railway.distance = int.Parse(d[2]);
                    db.AddRailway(railway);
                }
            }

            if (File.Exists("cities.txt"))
            {
                StreamReader sr = new StreamReader("cities.txt");

                while (!sr.EndOfStream)
                {
                    var city = new Cities();
                    city.city = sr.ReadLine();
                    db.AddCity(city);
                }
            }
        }
    }
}