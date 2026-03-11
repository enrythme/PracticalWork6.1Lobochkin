using System;
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    /// <summary>
    /// Класс содержит автоматизированные unit-тесты для класса <see cref="BankAccount"/>.
    /// Тестирование проводится методом "белого ящика" с использованием MSTest.
    /// </summary>
    [TestClass]
    public class BankAccountTests
    {
        /// <summary>
        /// Тест 1: корректное списание суммы со счёта.
        /// Ожидается, что баланс уменьшится на указанную сумму.
        /// </summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Test User", beginningBalance);

            account.Debit(debitAmount);

            Assert.AreEqual(expected, account.Balance, 0.001,
                "После списания баланс должен уменьшиться на указанную сумму.");
        }

        /// <summary>
        /// Тест 2: попытка списать сумму, превышающую баланс.
        /// Ожидается исключение <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Mr. Test User", 11.99);

            account.Debit(20.00);
        }

        /// <summary>
        /// Тест 3: попытка списания отрицательной суммы.
        /// Ожидается исключение <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsNegative_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Mr. Test User", 11.99);

            account.Debit(-1.00);
        }

        /// <summary>
        /// Тест 1: корректное зачисление суммы на счёт.
        /// Ожидается, что баланс увеличится на указанную сумму.
        /// </summary>
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Test User", beginningBalance);

            account.Credit(creditAmount);

            Assert.AreEqual(expected, account.Balance, 0.001,
                "После зачисления баланс должен увеличиться на указанную сумму.");
        }

        /// <summary>
        /// Тест 2: зачисление нулевой суммы.
        /// Ожидается, что баланс не изменится.
        /// </summary>
        [TestMethod]
        public void Credit_WithZeroAmount_BalanceUnchanged()
        {
            double beginningBalance = 100.00;
            BankAccount account = new BankAccount("Mr. Test User", beginningBalance);

            account.Credit(0.0);

            Assert.AreEqual(beginningBalance, account.Balance, 0.001,
                "Зачисление нуля не должно изменять баланс.");
        }

        /// <summary>
        /// Тест 3: попытка зачислить отрицательную сумму.
        /// Ожидается исключение <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Mr. Test User", 100.00);

            account.Credit(-1.00);
        }
    }
}

