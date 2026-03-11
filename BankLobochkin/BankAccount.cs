using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс демонстрирует работу банковского счёта.
    /// Поддерживает операции пополнения и снятия средств.
    /// </summary>
    /// <remarks>
    /// Используется для демонстрации unit-тестирования в Microsoft Visual Studio.
    /// </remarks>
    public class BankAccount
    {
        /// <summary>
        /// Имя владельца счёта (только для чтения).
        /// </summary>
        private readonly string m_customerName;

        /// <summary>
        /// Текущий баланс счёта.
        /// </summary>
        private double m_balance;

        /// <summary>
        /// Закрытый конструктор по умолчанию. Запрещает создание пустого счёта.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/>
        /// с указанным именем владельца и начальным балансом.
        /// </summary>
        /// <param name="customerName">Имя владельца банковского счёта.</param>
        /// <param name="balance">Начальный баланс счёта.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Возвращает имя владельца счёта.
        /// </summary>
        /// <value>Строка с именем владельца банковского счёта.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Возвращает текущий баланс счёта.
        /// </summary>
        /// <value>Значение типа <see langword="double"/> — текущий баланс счёта.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списывает указанную сумму со счёта (операция дебетования).
        /// </summary>
        /// <param name="amount">Сумма для списания. Должна быть положительной и не превышать текущий баланс.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> превышает текущий баланс
        /// или если <paramref name="amount"/> меньше нуля.
        /// </exception>
        /// <example>
        /// <code>
        /// BankAccount account = new BankAccount("Иван Иванов", 100.0);
        /// account.Debit(30.0); // Баланс станет 70.0
        /// </code>
        /// </example>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }

        /// <summary>
        /// Зачисляет указанную сумму на счёт (операция кредитования).
        /// </summary>
        /// <param name="amount">Сумма для зачисления. Должна быть положительным числом.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> меньше нуля.
        /// </exception>
        /// <example>
        /// <code>
        /// BankAccount account = new BankAccount("Иван Иванов", 100.0);
        /// account.Credit(50.0); // Баланс станет 150.0
        /// </code>
        /// </example>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в программу. Демонстрирует создание счёта,
        /// зачисление и списание средств, вывод текущего баланса.
        /// </summary>
        /// <remarks>
        /// Создаётся счёт на имя "Mr. Roman Abramovich" с начальным балансом 11.99.
        /// Затем выполняется кредитование на 5.77 и дебетование на 11.22.
        /// </remarks>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}