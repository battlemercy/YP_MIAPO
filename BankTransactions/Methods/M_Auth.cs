using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankTransactions.Methods
{
    public class M_Auth
    {
        public bool Enter(string login, string password)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            if (login == "" || password == "")
            {
                MessageBox.Show("Вы не заполнили все поля", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var auth_check = db.Administrator.FirstOrDefault(ch => ch.Login == login && ch.Password == password);
            if (auth_check == null)
            {
                MessageBox.Show("Логин или пароль введены не верно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
