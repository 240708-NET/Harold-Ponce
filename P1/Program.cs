using System;
using BankData.Models;
using BankData.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bank;

class Program
{
    //This method displays the menu options and returns an integer based on the option selected.
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                .AddDbContext<BankContext>(options =>
                options.UseSqlServer("Server=localhost,1433;Database=BankDatabase;User Id=sa;Password=Hpc344307;TrustServerCertificate=True"))  // Replace with your actual connection string
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .BuildServiceProvider();

        var accountRepository = serviceProvider.GetService<IAccountRepository>();
        var userRepository = serviceProvider.GetService<IUserRepository>();


        Console.WriteLine("How many accounts do you want to create?");
            int numberOfAccounts = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAccounts; i++)
            {
                Console.Write("\nEnter First Name: ");
                String firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                String lastName = Console.ReadLine();

                Console.Write("Enter Account Number: ");
                int accountNumber = Int32.Parse(Console.ReadLine());

                while (accountRepository.accountNumberExists(accountNumber))
                {
                    Console.WriteLine("Account Number already exists.");
                    Console.WriteLine("Enter another Account Number: ");
                    accountNumber = Int32.Parse(Console.ReadLine());
                }

                Console.Write("Enter Checkings Balance: ");
                double checkings = double.Parse(Console.ReadLine());

                Console.Write("Enter Savings Balance: ");
                double savings = double.Parse(Console.ReadLine());

                var user = new User(firstName, lastName);
                userRepository.addUser(user);

                var account = new Account(user, accountNumber, checkings, savings);
                accountRepository.addAccount(account);
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please enter Account Number:");
                int accNumber = Int32.Parse(Console.ReadLine());

                var fetchedAccount = accountRepository.getAccountByAccountNumber(accNumber);
                if (fetchedAccount == null)
                {
                    Console.WriteLine("Account does not exist.\n");
                    continue;
                }

                bool accountMenu = true;
                while (accountMenu)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Account Number: " + fetchedAccount.accountNumber);
                    Console.WriteLine("Checkings: $" + fetchedAccount.checkings.ToString("F2"));
                    Console.WriteLine("Savings: $" + fetchedAccount.savings.ToString("F2"));
                    Console.WriteLine();

                    int option = Menu();

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("--Withdrawal Transaction--");
                            Console.WriteLine("1) From Checkings");
                            Console.WriteLine("2) From Savings");

                            int isCheckings = -1;
                            while (isCheckings != 1 && isCheckings != 2)
                            {
                                Console.Write("\nPlease Select An Option:");
                                isCheckings = Int32.Parse(Console.ReadLine());
                                if (isCheckings != 1 && isCheckings != 2)
                                {
                                    Console.WriteLine("Invalid Option.");
                                }
                            }

                            Console.WriteLine("How much cash do you want to withdraw?");
                            double amount = double.Parse(Console.ReadLine());

                            if (isCheckings == 1)
                            {
                                if (fetchedAccount.checkings >= amount)
                                {
                                    fetchedAccount.checkings -= amount;
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }
                            else if (isCheckings == 2)
                            {
                                if (fetchedAccount.savings >= amount)
                                {
                                    fetchedAccount.savings -= amount;
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }

                            accountRepository.UpdateAccount(fetchedAccount);
                            break;

                        case 2:
                            Console.WriteLine("--Deposit Transaction--");
                            Console.WriteLine("1) To Checkings");
                            Console.WriteLine("2) To Savings");

                            isCheckings = -1;
                            while (isCheckings != 1 && isCheckings != 2)
                            {
                                Console.Write("\nPlease Select An Option:");
                                isCheckings = Int32.Parse(Console.ReadLine());
                                if (isCheckings != 1 && isCheckings != 2)
                                {
                                    Console.WriteLine("Invalid Option.");
                                }
                            }

                            Console.WriteLine("How much cash do you want to deposit?");
                            amount = double.Parse(Console.ReadLine());

                            if (amount < 0)
                            {
                                Console.WriteLine("Invalid amount");
                            }
                            else
                            {
                                if (isCheckings == 1)
                                {
                                    fetchedAccount.checkings += amount;
                                }
                                else if (isCheckings == 2)
                                {
                                    fetchedAccount.savings += amount;
                                }

                                accountRepository.UpdateAccount(fetchedAccount);
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine(fetchedAccount);
                            Console.ReadKey();
                            break;

                        case 4:
                            accountMenu = false;
                            break;

                        case 5:
                            running = false;
                            accountMenu = false;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public static int Menu()
{
    int option = 0;

    Console.WriteLine("1) Withdrawal");
    Console.WriteLine("2) Deposit");
    Console.WriteLine("3) Balance Inquiry");
    Console.WriteLine("4) Exit Account");
    Console.WriteLine("5) Exit Program");

    while (option < 1 || option > 5)
    {
        Console.WriteLine("\nPlease select an option (1-5):");
        if (int.TryParse(Console.ReadLine(), out option) && (option >= 1 && option <= 5))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
            option = 0; // Reset option to continue the loop
        }
    }

    return option; // This will not be reached but ensures all code paths return a value
}    
}


