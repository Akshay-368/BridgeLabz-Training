using System;
using System.Threading.Tasks;
using Utility;

namespace Core
{
    internal class Menu
    {
        internal async Task StartAsync()
        {
            int choice = -1;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.WriteLine("     BANK TRANSACTION SYSTEM  ");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    

                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Get Balance");
                    Console.WriteLine("5. Delete Account");
                    Console.WriteLine("6. Test Insufficient Balance");
                    Console.WriteLine("7. Test Parallel Withdraw");
                    Console.WriteLine("0. Exit");

                    Console.ResetColor();


                    Console.Write("Enter your choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            await new CreateAccount().CreateAsync();
                            break;

                        case 2:
                            await new Deposit().DepositAsync();
                            break;

                        case 3:
                            await new Withdraw().WithdrawAsync();
                            break;

                        case 4:
                            await new GetBalance().GetBalanceAsync();
                            break;

                        case 5:
                            await new DeleteAccount().DeleteAsync();
                            break;

                        case 6:
                            await new TestInsufficientBalance().RunTestAsync();
                            break;

                        case 7:
                            await new TestParallelWithdraw().RunTestAsync();
                            break;

                        case 0:
                            Console.WriteLine("Exiting system... Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again!");
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                if (choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}
