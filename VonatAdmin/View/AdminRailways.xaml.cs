using System;
using System.Collections.Generic;
using System.IO;
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
using VonatCommon.Models.UserHandling;
using VonatAdmin.Controller;
using VonatCommon.Auth;

namespace VonatAdmin.View
{
    /// <summary>
    /// Interaction logic for AdminRailways.xaml
    /// </summary>
    public partial class AdminRailways : Window
    {
        private VonatContext vonat = VonatContext.Instance;
        private RailwayController railwayController = new RailwayController();
        public AdminRailways()
        {
            InitializeComponent();
            railwayController.SubscibeToLogout(UserAuthenticator_LogoutEvent);
        }

        private void NewCity_OnClick(object sender, RoutedEventArgs e)
        {
            NewCityPicker newCityPicker = new NewCityPicker();
            newCityPicker.ShowDialog();
        }

        private void NewRailway_OnClick(object sender, RoutedEventArgs e)
        {
            NewRailway newRailway = new NewRailway();
            newRailway.Top = this.Top;
            newRailway.Left = this.Left;
            newRailway.ShowDialog();
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            if (File.Exists("cities.txt"))
            {
                StreamReader sr = new StreamReader("cities.txt");
                while (!sr.EndOfStream)
                {
                    string h = sr.ReadLine();
                    var s = vonat.Cities.FirstOrDefault(r => r.city.ToLower() == h.ToLower());
                    if (s == null)
                    {
                        vonat.Cities.Add(new Cities(){city = h});
                    }
                    vonat.SaveChanges();
                }
            }
            
            if (File.Exists("railways.txt"))
            {
                StreamReader sr = new StreamReader("railways.txt");
                while (!sr.EndOfStream)
                {
                    string[] h = sr.ReadLine().Split(';');
                    var s = vonat.Railways.FirstOrDefault(r => r.from.ToLower() == h[0].ToLower() && r.to.ToLower() == h[1].ToLower() || r.from.ToLower() == h[1].ToLower() && r.to.ToLower() == h[0].ToLower());
                    if (s == null)
                    {
                        vonat.Railways.Add(new Railways()
                        {
                            from = h[0],
                            to = h[1],
                            distance = int.Parse(h[2])
                        });
                        vonat.SaveChanges();
                    }
                }
            }
        }

        private void UserAuthenticator_LogoutEvent()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            LoginWindow.GetWindow(loginWindow).Show();
            railwayController.UnsubscribeFromLogout(UserAuthenticator_LogoutEvent);
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
