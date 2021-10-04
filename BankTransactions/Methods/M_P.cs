using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace BankTransactions.Methods
{
    class M_P
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
            Paymaster paymaster = new Paymaster();
            try
            {
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                paymaster.Last_Name = last;
                paymaster.First_Name = first;
                paymaster.Middle_Name = middle;
                db.Paymaster.Add(paymaster);
                db.SaveChanges();
                MessageBox.Show("Кассир добавлен", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_t = db.Paymaster.Where(i => i.ID == num).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Paymaster.Remove(d_t);
                    db.SaveChanges();
                    MessageBox.Show("Кассир удалён", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var u_t = db.Paymaster.Where(u => u.ID == num).FirstOrDefault();
                if (u_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Учёт", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_t.Last_Name = last;
                u_t.First_Name = first;
                u_t.Middle_Name = middle;
                db.SaveChanges();
                MessageBox.Show("Кассир изменён", "Учёт", MessageBoxButton.OK, MessageBoxImage.Information);
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
