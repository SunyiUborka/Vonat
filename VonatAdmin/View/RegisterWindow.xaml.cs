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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterController registerController = new RegisterController();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                registerController.HandleRegister(tbUsername.Text, tbPassword1.Password, tbPassword2.Password, tbEmail.Text, tbUsername.Text);
                LoginWindow loginWindow = new LoginWindow(tbUsername.Text);
                loginWindow.Left = this.Left;
                loginWindow.Top = this.Top;
                LoginWindow.GetWindow(loginWindow).Show();
                this.Close();
            }
            catch (RailwayException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen regisztráció", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            LoginWindow.GetWindow(loginWindow).Show();
            this.Close();
        }
    }
}
