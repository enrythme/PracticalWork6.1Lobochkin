# Практическая работа №6.1

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MSTest](https://img.shields.io/badge/MSTest-FF6B35?style=for-the-badge&logo=microsoft&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)

Практическая работа №6 по дисциплине **"Поддержка и тестирование программного обеспечения"**

**Автор:** Лобочкин М.В.  
**Преподаватель:** Аксенова Т.Г.

---

## Описание проекта

Консольное приложение на **C# (.NET 6)** с реализацией класса банковского счёта `BankAccount` и автоматизированными unit-тестами на базе **MSTest**. Тестирование проводится методом **"белого ящика"** с использованием средств Microsoft Visual Studio.

### Основные возможности

- Реализация банковского счёта с операциями дебетования и кредитования
- XML-документирование программного кода
- Автоматизированные unit-тесты для методов `Debit` и `Credit`
- Проверка корректных значений и граничных случаев
- Проверка выброса исключений при некорректных входных данных

---

## Технологический стек

| Технология | Версия | Назначение |
|---|---|---|
| **C#** | 10 | Основной язык программирования |
| **.NET** | 6.0 | Платформа разработки |
| **MSTest** | 3.0.2 | Фреймворк unit-тестирования |
| **Microsoft.NET.Test.Sdk** | 17.5.0 | SDK для запуска тестов |
| **Visual Studio** | 2022 | IDE |

---

## Установка и запуск

### Требования

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/)
- ОС: Windows 10 / 11

### Клонирование репозитория

```bash
git clone https://github.com/ВашАккаунт/BankSolution.git
cd BankSolution
```

### Сборка и запуск

#### Через командную строку

```bash
dotnet restore
dotnet build
dotnet run --project Bank/Bank.csproj
```

#### Запуск тестов через командную строку

```bash
dotnet test BankTests/BankTests.csproj
```

#### Через Visual Studio 2022

1. Откройте файл `BankSolution.sln`
2. Нажмите **Ctrl+Shift+B** для сборки
3. Нажмите **F5** для запуска консольного приложения
4. Для запуска тестов: **Тест → Запустить все тесты**

---

## Структура проекта

```
BankSolution/
│
├── Bank/
│   ├── BankAccount.cs          # Класс банковского счёта с XML-документацией
│   └── Bank.csproj             # Файл проекта консольного приложения
│
├── BankTests/
│   ├── BankAccountTests.cs     # Unit-тесты для методов Debit и Credit
│   └── BankTests.csproj        # Файл тестового проекта (MSTest)
│
└── BankSolution.sln
```

---

## Описание класса BankAccount

Класс `BankAccount` находится в пространстве имён `BankAccountNS` и реализует базовую логику банковского счёта.

### Свойства

| Свойство | Тип | Описание |
|---|---|---|
| `CustomerName` | `string` | Имя владельца счёта (только чтение) |
| `Balance` | `double` | Текущий баланс счёта (только чтение) |

### Методы

| Метод | Описание |
|---|---|
| `Debit(double amount)` | Списывает сумму со счёта. Выбрасывает `ArgumentOutOfRangeException` если сумма отрицательная или превышает баланс |
| `Credit(double amount)` | Зачисляет сумму на счёт. Выбрасывает `ArgumentOutOfRangeException` если сумма отрицательная |

---

## Тесты

Все тесты находятся в одном файле `BankAccountTests.cs` в классе `BankAccountTests`.

### Тесты метода Debit

| Тест | Описание | Ожидаемый результат |
|---|---|---|
| `Debit_WithValidAmount_UpdatesBalance` | Списание корректной суммы | Баланс уменьшается на указанную сумму |
| `Debit_WhenAmountIsMoreThanBalance_ThrowsArgumentOutOfRangeException` | Сумма превышает баланс | Исключение `ArgumentOutOfRangeException` |
| `Debit_WhenAmountIsNegative_ThrowsArgumentOutOfRangeException` | Отрицательная сумма | Исключение `ArgumentOutOfRangeException` |

### Тесты метода Credit

| Тест | Описание | Ожидаемый результат |
|---|---|---|
| `Credit_WithValidAmount_UpdatesBalance` | Зачисление корректной суммы | Баланс увеличивается на указанную сумму |
| `Credit_WithZeroAmount_BalanceUnchanged` | Зачисление нулевой суммы | Баланс не изменяется |
| `Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException` | Отрицательная сумма | Исключение `ArgumentOutOfRangeException` |

---

## Возможные проблемы

- При запуске тестов убедитесь, что проект `BankTests` ссылается на проект `Bank` через `ProjectReference`
- Для корректной работы тестов необходимо наличие пакетов `MSTest.TestFramework` и `MSTest.TestAdapter`

---

## Авторы

| Имя | Роль |
|---|---|
| **Лобочкин М.В.** | Разработчик |

---

## Контакты

По вопросам работы проекта обращайтесь к автору или преподавателю.

**Преподаватель:** Аксенова Т.Г. — [@TGAksenova](https://github.com/TGAksenova)

---

<div align="center">
  <sub>Практическая работа №6 — Создание автоматизированных Unit-тестов. Часть 1</sub>
</div>
