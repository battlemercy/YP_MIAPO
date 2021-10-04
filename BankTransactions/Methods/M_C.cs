using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace BankTransactions.Methods
{
    public class M_C
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

        public bool Add(string last, string first, string middle)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            Client client = new Client();
            try
            {
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                client.Last_Name = last;
                client.First_Name = first;
                client.Middle_Name = middle;
                client.Bank_Account = 0;
                db.Client.Add(client);
                db.SaveChanges();
                MessageBox.Show("Клиент добавлен", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_s = db.Client.Where(i => i.ID == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Client.Remove(d_s);
                    db.SaveChanges();
                    MessageBox.Show("Клиент удалён", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Client.Where(u => u.ID == num).FirstOrDefault();
                if (u_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_s.Last_Name = last;
                u_s.First_Name = first;
                u_s.Middle_Name = middle;
                db.SaveChanges();
                MessageBox.Show("Клиент изменён", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
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
