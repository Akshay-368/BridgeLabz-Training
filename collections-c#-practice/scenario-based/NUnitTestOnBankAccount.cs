using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    // Test 1: Deposit with valid (positive) amount
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange
        decimal initialBalance = 1000m;
        decimal depositAmount = 500m;
        decimal expectedBalance = initialBalance + depositAmount;

        Program account = new Program(initialBalance);

        // Act
        account.Deposit(depositAmount);

        // Assert - only one assert as per requirement
        Assert.AreEqual(expectedBalance, account.Balance);
    }

    // Test 2: Deposit with negative amount -> should throw exception
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange
        decimal initialBalance = 2000m;
        decimal negativeAmount = -300m;

        Program account = new Program(initialBalance);

        // Act + Assert
        var ex = Assert.Throws<Exception>(() => account.Deposit(negativeAmount));

        // Single assert on the exception message
        Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
    }

    // Test 3: Withdraw valid amount (≤ balance)
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange
        decimal initialBalance = 1500m;
        decimal withdrawAmount = 400m;
        decimal expectedBalance = initialBalance - withdrawAmount;

        Program account = new Program(initialBalance);

        // Act
        account.Withdraw(withdrawAmount);

        // Assert - only one assert
        Assert.AreEqual(expectedBalance, account.Balance);
    }

    // Test 4: Withdraw more than balance -> should throw exception
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange
        decimal initialBalance = 800m;
        decimal withdrawAmount = 1000m; // more than balance

        Program account = new Program(initialBalance);

        // Act + Assert
        var ex = Assert.Throws<Exception>(() => account.Withdraw(withdrawAmount));

        // Single assert on the exception message
        Assert.AreEqual("Insufficient funds.", ex.Message);
    }
}
