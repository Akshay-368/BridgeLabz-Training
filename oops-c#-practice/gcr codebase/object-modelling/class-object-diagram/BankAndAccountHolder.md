# Problem 2: Bank and Account Holders (Association) Diagram

```mermaid
classDiagram
    class Bank{
        +String bankName
        +String branchCode
        +List~Account~ accounts
        +openAccount(customer: Customer, initialBalance: double) Account
        +findAccount(accountNumber: String) Account
    }
    class Customer{
        +String customerId
        +String name
        +String phone
        +List~Account~ accounts
        +viewBalance(accountNumber: String) double
        +deposit(accountNumber: String, amount: double)
        +withdraw(accountNumber: String, amount: double)
    }
    class Account{
        +String accountNumber
        +double balance
        +String accountType
        +Customer owner
        +Bank bank
    }

    Bank "1" -- "*" Account : manages
    Customer "1" -- "*" Account : owns
    Account "1" -- "1" Bank : belongs to
    Account "1" -- "1" Customer : owned by
