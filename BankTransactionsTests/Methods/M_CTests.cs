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
    public class M_CTests
    {
        M_C m_c = new M_C();
        [TestMethod()]

        public void Word_Write_Success()
        {
            bool actual = true,
                 expected = true;

            string Last_Name = "Оладушек";
            try
            {
                actual = m_c.Word_Check(Last_Name);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Number_Write_Fail()
        {
            bool actual = false,
                 expected = false;

            string Last_Name = "50000";
            try
            {
                actual = m_c.Word_Check(Last_Name);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Spec_Symbols_Write_Fail()
        {
            bool actual = false,
                 expected = false;

            string Last_Name = "!@#$&/*%";
            try
            {
                actual = m_c.Word_Check(Last_Name);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void English_Write_Fail()
        {
            bool actual = false,
                 expected = false;

            string Last_Name = "Popov";
            try
            {
                actual = m_c.Word_Check(Last_Name);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}