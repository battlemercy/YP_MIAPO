using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTransactions.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions.Methods.Tests
{
    [TestClass()]
    public class M_AuthTests
    {
        M_Auth m_a = new M_Auth();
        [TestMethod()]
        public void Enter_Success()
        {
            bool actual = true,
                 expected = true;

            string login = "admin",
                   password = "admin";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Enter_Fail()
        {
            bool actual = false,
                 expected = false;

            string login = "admin",
                   password = "b10";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Enter_Null_Fail()
        {
            bool actual = false,
                 expected = false;

            string login = "admin",
                   password = "";
            try
            {
                actual = m_a.Enter(login, password);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}