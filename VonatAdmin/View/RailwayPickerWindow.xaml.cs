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
using VonatAdmin.Controller;
using VonatCommon.Repository;

namespace VonatAdmin.View
{
    /// <summary>
    /// Interaction logic for RailwayPickerWindow.xaml
    /// </summary>
    public partial class RailwayPickerWindow : Window
    {
        private RailwayPickerController railwayPicker = new RailwayPickerController();
        public RailwayPickerWindow()
        {
            InitializeComponent();
            railwayPicker.SubscibeToLogout(UserAuthenticator_LogoutEvent);
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
            MessageBox.Show(railwayPicker.GetCities());
            //railwayPicker.Logout();
        }
    }
}
