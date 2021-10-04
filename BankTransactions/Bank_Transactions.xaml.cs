using System;
using BankTransactions.Methods;
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

namespace BankTransactions
{
    /// <summary>
    /// Логика взаимодействия для Bank_Transactions.xaml
    /// </summary>
    public partial class Bank_Transactions : Window
    {
        M_C m_c = new M_C();
        M_P m_p = new M_P();
        M_O m_o = new M_O();
        gr691_msiEntities db;
        public Bank_Transactions()
        {
            InitializeComponent();
            db = new gr691_msiEntities();
        }

        private void Word_Check(object sender, TextCompositionEventArgs e)
        {
            if (m_c.Word_Check(e.Text) == false || m_p.Word_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }

        private void Client_Insert(object sender, RoutedEventArgs e)
        {
            if (m_c.Add(Client_last.Text, Client_first.Text, Client_middle.Text) == true)
            {
                Client_last.Clear();
                Client_first.Clear();
                Client_middle.Clear();
            }
            Table_Client.ItemsSource = db.Client.ToList();
        }

        private void Client_Delete(object sender, RoutedEventArgs e)
        {
            Client client = Table_Client.SelectedItem as Client;
            if (Table_Client.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_s = db.Client.Where(i => i.ID == client.ID).FirstOrDefault();
            m_c.Delete(client != null ? client.ID.ToString() : "0");
            Table_Client.ItemsSource = db.Client.ToList();
        }
        private void Client_Update(object sender, RoutedEventArgs e)
        {
            Client client = Table_Client.SelectedItem as Client;
            if (Table_Client.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Client.Where(i => i.ID == client.ID).FirstOrDefault();
            if (m_c.Update(client != null ? client.ID.ToString() : "0", Client_last.Text, Client_first.Text, Client_middle.Text) == true)
            {
                Client_last.Clear();
                Client_first.Clear();
                Client_middle.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Client.ItemsSource = db.Client.ToList();
            }
        }

        private void Paymaster_Insert(object sender, RoutedEventArgs e)
        {
            if (m_p.Add(Paymaster_last.Text, Paymaster_first.Text, Paymaster_middle.Text) == true)
            {
                Paymaster_last.Clear();
                Paymaster_first.Clear();
                Paymaster_middle.Clear();
            }
            Table_Paymaster.ItemsSource = db.Paymaster.ToList();
        }
        private void Paymaster_Delete(object sender, RoutedEventArgs e)
        {
            Paymaster paymaster = Table_Paymaster.SelectedItem as Paymaster;
            if (Table_Paymaster.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_t = db.Paymaster.Where(i => i.ID == paymaster.ID).FirstOrDefault();
            m_p.Delete(paymaster != null ? paymaster.ID.ToString() : "0");
            Table_Paymaster.ItemsSource = db.Paymaster.ToList();
        }
        private void Paymaster_Update(object sender, RoutedEventArgs e)
        {
            Paymaster paymaster = Table_Paymaster.SelectedItem as Paymaster;
            if (Table_Paymaster.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Paymaster.Where(i => i.ID == paymaster.ID).FirstOrDefault();
            if (m_p.Update(paymaster != null ? paymaster.ID.ToString() : "0", Paymaster_last.Text, Paymaster_first.Text, Paymaster_middle.Text) == true)
            {
                Paymaster_last.Clear();
                Paymaster_first.Clear();
                Paymaster_middle.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Paymaster.ItemsSource = db.Paymaster.ToList();
            }
        }

        private void Operation_Insert(object sender, RoutedEventArgs e)
        {
            if (m_o.Add(bank_date.Text, bank_client_id.Text, bank_paymaster_id.Text, bank_processing_stage.Text, bank_type.Text, bank_amount.Text) == true)
            {
                bank_date.Clear();
                bank_client_id.Clear();
                bank_paymaster_id.Clear();
                bank_processing_stage.Clear();
                bank_type.Clear();
                bank_amount.Clear();
            }
            Table_Bank.ItemsSource = db.Operation.ToList();
        }

        private void Operation_Update(object sender, RoutedEventArgs e)
        {
            Operation operation = Table_Bank.SelectedItem as Operation;
            if (Table_Bank.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Operation.Where(i => i.ID == operation.ID).FirstOrDefault();
            if (m_o.Update(operation != null ? operation.ID.ToString() : "0", bank_date.Text, bank_client_id.Text, bank_paymaster_id.Text, bank_processing_stage.Text, bank_type.Text, bank_amount.Text) == true)
            {
                bank_date.Clear();
                bank_client_id.Clear();
                bank_paymaster_id.Clear();
                bank_processing_stage.Clear();
                bank_type.Clear();
                bank_amount.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Bank.ItemsSource = db.Operation.ToList();
            }
        }

        private void Operation_Delete(object sender, RoutedEventArgs e)
        {
            Operation operation = Table_Bank.SelectedItem as Operation;
            if (Table_Bank.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_t = db.Operation.Where(i => i.ID == operation.ID).FirstOrDefault();
            m_o.Delete(operation != null ? operation.ID.ToString() : "0");
            Table_Bank.ItemsSource = db.Operation.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_msiEntities();
            Table_Bank.ItemsSource = db.Operation.ToList();
            Table_Client.ItemsSource = db.Client.ToList();
            Table_Paymaster.ItemsSource = db.Paymaster.ToList();
        }
    }
}
