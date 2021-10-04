using BankTransactions.Methods;
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

namespace BankTransactions
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        gr691_msiEntities db;
        public MainWindow()
        {
            db = new gr691_msiEntities();
            InitializeComponent();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            M_Auth m_auth = new M_Auth();
            if (m_auth.Enter(Auth_Login.Text, Auth_Password.Password) == true)
            {
                MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                Hide();
                new Bank_Transactions().ShowDialog();
                Application.Current.Shutdown();
            }
        }
    }
}
