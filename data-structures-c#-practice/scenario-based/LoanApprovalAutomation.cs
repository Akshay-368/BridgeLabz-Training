using System;

// Interface defining the contract for any loan that can be approved and have EMI calculated
// Relationship: LoanApplication implements IApprovable (implements-a interface)
// Why essential: Ensures all loan types (personal, home, auto etc.) follow same approval 
// and EMI calculation contract, enabling polymorphism and consistent usage
public interface IApprovable
{
    bool ApproveLoan();
    double CalculateMonthlyEMI();
    void DisplayLoanDecision();
}

// Abstract base class for all loan applications
// Centralizes common properties and shared approval/EMI logic
// Relationship: PersonalLoan, HomeLoan, AutoLoan is-a LoanApplication (inheritance)
// Why essential: Follows DRY principle - common applicant data, approval rules,
// EMI formula skeleton are defined once in base class
// Encapsulation: Sensitive fields like creditScore, internal status are private/protected
// SOLID: Single responsibility (manages loan state & basic approval)
// Open/closed: Base closed for modification, open for extension via overrides
// KISS/YAGNI: Only essential common behavior, no unnecessary complexity
public abstract class LoanApplication : IApprovable
{
    // Protected fields accessible to derived classes
    protected string applicantName;
    protected int creditScore;
    protected double monthlyIncome;
    protected double requestedLoanAmount;
    protected int loanTermInMonths;
    protected double interestRateAnnual; // in percent
    protected bool isApproved;
    protected string approvalReason;

    // Constructor with default values for emergencies
    protected LoanApplication(
        string name,
        int creditScoreInput,
        double income,
        double loanAmount,
        int termMonths,
        double interestRate)
    {
        applicantName = string.IsNullOrEmpty(name) ? "Default Applicant" : name;
        creditScore = creditScoreInput > 0 ? creditScoreInput : 650; // default fair score
        monthlyIncome = income > 0 ? income : 50000;
        requestedLoanAmount = loanAmount > 0 ? loanAmount : 500000;
        loanTermInMonths = termMonths > 0 ? termMonths : 60;
        interestRateAnnual = interestRate > 0 ? interestRate : 10.5;

        isApproved = false;
        approvalReason = "Pending evaluation";
    }

    // Common approval logic (can be overridden)
    public virtual bool ApproveLoan()
    {
        // Basic common rules (can be extended in child classes)
        if (creditScore < 600)
        {
            approvalReason = "Credit score too low (<600)";
            return false;
        }

        double emi = CalculateMonthlyEMI();
        double incomeToEmiRatio = emi / monthlyIncome;

        if (incomeToEmiRatio > 0.6)
        {
            approvalReason = "EMI too high compared to income (>60%)";
            return false;
        }

        isApproved = true;
        approvalReason = "Approved based on standard criteria";
        return true;
    }

    // Common EMI formula - can be overridden for special loan types
    public virtual double CalculateMonthlyEMI()
    {
        double monthlyRate = interestRateAnnual / 12 / 100;
        double powerTerm = Math.Pow(1 + monthlyRate, loanTermInMonths);

        if (powerTerm == 1) return requestedLoanAmount / loanTermInMonths;

        double emi = requestedLoanAmount * monthlyRate * powerTerm / (powerTerm - 1);
        return Math.Round(emi, 2);
    }

    public virtual void DisplayLoanDecision()
    {
        Console.WriteLine($"\nLoan Application for {applicantName}");
        Console.WriteLine($"Loan Amount: {requestedLoanAmount:C0}");
        Console.WriteLine($"Term: {loanTermInMonths} months");
        Console.WriteLine($"Interest Rate: {interestRateAnnual}%");
        Console.WriteLine($"Credit Score: {creditScore}");
        Console.WriteLine($"Monthly Income: {monthlyIncome:C0}");
        Console.WriteLine($"Monthly EMI: {CalculateMonthlyEMI():C2}");
        Console.WriteLine($"Status: {(isApproved ? "APPROVED" : "REJECTED")}");
        Console.WriteLine($"Reason: {approvalReason}");
    }
}

// Concrete class for Personal Loan
// Relationship: PersonalLoan is-a LoanApplication
// Why essential: Specializes approval rules for personal loans
public class PersonalLoan : LoanApplication
{
    public PersonalLoan(
        string name,
        int creditScore,
        double income,
        double loanAmount,
        int termMonths,
        double interestRate)
        : base(name, creditScore, income, loanAmount, termMonths, interestRate)
    {
    }

    public override bool ApproveLoan()
    {
        bool baseApproved = base.ApproveLoan();

        // Additional strict rule for personal loans
        if (requestedLoanAmount > monthlyIncome * 12)
        {
            approvalReason = "Loan amount exceeds 12 months income (personal loan rule)";
            isApproved = false;
            return false;
        }

        return baseApproved;
    }
}

// Concrete class for Home Loan
// Relationship: HomeLoan is-a LoanApplication
// Why essential: Home loans typically have lower interest & more lenient rules
public class HomeLoan : LoanApplication
{
    public HomeLoan(
        string name,
        int creditScore,
        double income,
        double loanAmount,
        int termMonths,
        double interestRate)
        : base(name, creditScore, income, loanAmount, termMonths, interestRate)
    {
    }

    public override bool ApproveLoan()
    {
        bool baseApproved = base.ApproveLoan();

        // Home loans allow higher loan-to-income
        if (creditScore >= 550) // lower threshold than personal
        {
            approvalReason = "Approved (Home Loan - relaxed credit requirement)";
            isApproved = true;
        }

        return isApproved;
    }

    public override double CalculateMonthlyEMI()
    {
        // Home loans usually have lower interest - small adjustment example
        double adjustedRate = interestRateAnnual - 1.0; // 1% less for demo
        double monthlyRate = adjustedRate / 12 / 100;
        double power = Math.Pow(1 + monthlyRate, loanTermInMonths);

        if (power == 1) return requestedLoanAmount / loanTermInMonths;

        return Math.Round(
            requestedLoanAmount * monthlyRate * power / (power - 1),
            2);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== LoanBuddy - Loan Approval Engine ===\n");

        bool running = true;

        while (running)
        {
            Console.WriteLine("Select Loan Type:");
            Console.WriteLine("1. Personal Loan");
            Console.WriteLine("2. Home Loan");
            Console.WriteLine("3. Exit");

            Console.Write("Enter choice: ");
            string choiceInput = Console.ReadLine();
            int choice = string.IsNullOrEmpty(choiceInput) ? 1 : int.Parse(choiceInput);

            if (choice == 3)
            {
                running = false;
                continue;
            }

            // Collect applicant data with defaults
            Console.Write("Applicant Name (default: Raj Kumar): ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) name = "Raj Kumar";

            Console.Write("Credit Score (default 720): ");
            string scoreStr = Console.ReadLine();
            int credit = string.IsNullOrEmpty(scoreStr) ? 720 : int.Parse(scoreStr);

            Console.Write("Monthly Income (default 85000): ");
            string incomeStr = Console.ReadLine();
            double income = string.IsNullOrEmpty(incomeStr) ? 85000 : double.Parse(incomeStr);

            Console.Write("Loan Amount Requested (default 500000): ");
            string amountStr = Console.ReadLine();
            double amount = string.IsNullOrEmpty(amountStr) ? 500000 : double.Parse(amountStr);

            Console.Write("Loan Term in Months (default 60): ");
            string termStr = Console.ReadLine();
            int term = string.IsNullOrEmpty(termStr) ? 60 : int.Parse(termStr);

            Console.Write("Annual Interest Rate % (default 11.5): ");
            string rateStr = Console.ReadLine();
            double rate = string.IsNullOrEmpty(rateStr) ? 11.5 : double.Parse(rateStr);

            // Create appropriate loan object
            LoanApplication loan = null;

            if (choice == 1)
            {
                loan = new PersonalLoan(name, credit, income, amount, term, rate);
            }
            else if (choice == 2)
            {
                loan = new HomeLoan(name, credit, income, amount, term, rate);
            }

            if (loan != null)
            {
                Console.WriteLine("\n" + new string('-', 60));
                loan.ApproveLoan();
                loan.DisplayLoanDecision();
                Console.WriteLine(new string('-', 60));
            }
        }

        Console.WriteLine(" Thank you for using LoanBuddy!");
    }
}
