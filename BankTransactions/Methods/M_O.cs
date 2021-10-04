using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace BankTransactions.Methods
{
    class M_O
    {
        public bool Word_Check(string text)
        {
            Regex regex = new Regex("[^А-ЯЁа-яё]+");
            bool check = regex.IsMatch(text);
            if (check == true)
            {
                return false;
            }
            else return true;
        }

        public bool Add(string date, string clientid, string paymasterid, string processingstage, string type, string amount)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            Operation operation = new Operation();
            try
            {
                if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(clientid) || string.IsNullOrWhiteSpace(paymasterid) || string.IsNullOrWhiteSpace(processingstage) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(amount))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                operation.DateOperation = date;
                operation.Client_ID = Int32.Parse(clientid);
                operation.Paymaster_ID = Int32.Parse(paymasterid);
                operation.Processing_Stage = processingstage;
                operation.Type = type;
                operation.Amount = Int32.Parse(amount);
                db.Operation.Add(operation);
                db.SaveChanges();
                MessageBox.Show("Операция добавлена", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var d_t = db.Operation.Where(i => i.ID == num).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Operation.Remove(d_t);
                    db.SaveChanges();
                    MessageBox.Show("Операция удалена", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string date, string clientid, string paymasterid, string processingstage, string type, string amount)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_t = db.Operation.Where(u => u.ID == num).FirstOrDefault();
                if (u_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(clientid) || string.IsNullOrWhiteSpace(paymasterid) || string.IsNullOrWhiteSpace(processingstage) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(amount))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_t.DateOperation = date;
                u_t.Client_ID = Int32.Parse(clientid);
                u_t.Paymaster_ID = Int32.Parse(paymasterid);
                u_t.Processing_Stage = processingstage;
                u_t.Type = type;
                u_t.Amount = Int32.Parse(amount);
                db.SaveChanges();
                MessageBox.Show("Операция изменена", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

    }
}
