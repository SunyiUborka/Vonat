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
using VonatPublic.Controller;
using VonatCommon.Repository;
using VonatCommon.Models;

namespace VonatPublic.View
{
    /// <summary>
    /// Interaction logic for RailwayPickerWindow.xaml
    /// </summary>
    public partial class RailwayPickerWindow : Window
    {
        private RailwayPickerController railwayPicker = new RailwayPickerController();
        private VonatContext vonat = VonatContext.Instance;
        public RailwayPickerWindow()
        {
            InitializeComponent();
            railwayPicker.SubscibeToLogout(UserAuthenticator_LogoutEvent);
            foreach (var item in railwayPicker.GetCities())
            {
                cbFrom.Items.Add(item.city);
                cbTo.Items.Add(item.city);
            }
        }

        private void UserAuthenticator_LogoutEvent()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            LoginWindow.GetWindow(loginWindow).Show();
            railwayPicker.UnsubscribeFromLogout(UserAuthenticator_LogoutEvent);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            railwayPicker.Logout();
        }

        private void cbTo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            if (cbFrom.SelectedIndex != null)
            {
                var s = vonat.Railways.FirstOrDefault(r => r.from.ToLower() == cbFrom.SelectedItem.ToString().ToLower() && r.to.ToLower() == cbTo.SelectedItem.ToString().ToLower() || r.from.ToLower() == cbTo.SelectedItem.ToString().ToLower() && r.to.ToLower() == cbFrom.SelectedItem.ToString().ToLower());
                ListView.Items.Add(s);
            }
        }

        private void CbFrom_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            if (cbFrom.SelectedIndex != null)
            {
                var s = vonat.Railways.FirstOrDefault(r => r.from.ToLower() == cbFrom.SelectedItem.ToString().ToLower() && r.to.ToLower() == cbTo.SelectedItem.ToString().ToLower() || r.from.ToLower() == cbTo.SelectedItem.ToString().ToLower() && r.to.ToLower() == cbFrom.SelectedItem.ToString().ToLower());
                ListView.Items.Add(s);
            }
        }
    }
}
