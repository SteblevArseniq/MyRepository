using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange2()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.0;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message,
                    BankAccount.BankAccount.DebitAmountLessThanZeroMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange2()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message,
                    BankAccount.BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange_Last()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount.BankAccount account = new BankAccount.BankAccount("Mr. Bryan Walton",
                beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message,
                    BankAccount.BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
