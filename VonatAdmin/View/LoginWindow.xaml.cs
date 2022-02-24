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
using VonatCommon.RailwayException;

namespace VonatAdmin.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginController loginController = new LoginController();
        public LoginWindow()
        {
            InitializeComponent();
        }

        public LoginWindow(string usernameText) : this()
        {
            tbUsername.Text = usernameText;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = loginController.HandleLoginAttempt(tbUsername.Text, tbPassword.Password);
                AdminRailways railwayPicker = new AdminRailways();
                railwayPicker.Left = this.Left;
                railwayPicker.Top = this.Top;
                AdminRailways.GetWindow(railwayPicker).Show();
                this.Close();
            }
            catch (RailwayException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen bejelentkezés", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Left = this.Left;
            registerWindow.Top = this.Top;
            RegisterWindow.GetWindow(registerWindow).Show();
            this.Close();
        }
    }
}
