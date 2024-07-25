using BankData.Models;

namespace Bank;

class Program
{
    //This method displays the menu options and returns an integer based on the option selected.
    public static int menu()
    {
        int option = 0;

        Console.WriteLine("1) Withdrawal");
        Console.WriteLine("2) Deposit");
        Console.WriteLine("3) Balance Inquiry");
        Console.WriteLine("4) Exit Account");
        Console.WriteLine("5) Exit Program");

        //The user must enter a valid option (1-5).
        while (option < 1 || option > 5)
        {
            Console.WriteLine("\nPlease select an option(1-5):");
            option = Int32.Parse(Console.ReadLine());
        }

        return option;
    }

    //This method will determine if a given Account Number already exists.
    public static bool accountNumberExists(Account[] accounts, int accountNumber)
    {
        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] != null && accountNumber == accounts[i].accountNumber)
            {
                return true;
            }
        }
        return false;
    }

    //Main method.
    static void Main(String[] args)
    {
        //Ask user how many bank accounts he wants to use in the program.
        Console.WriteLine("How many accounts do you want to create?");
        int numberOfAccounts = Int32.Parse(Console.ReadLine());
        int index = 0;
        int option = 0;
        int condition = 0;
        int isCheckings = -1;
        double amount = 0;

        //Create an array to store Account objects.
        Account[] accounts = new Account[numberOfAccounts];
        int count = 1;

        //Ask user to input necessary information for each account.
        for (int i = 0; i < numberOfAccounts; i++)
        {
            //Ask user to enter the Name of the Account Holder.
            Console.Write("\nEnter Your First Name: ");
            String firstName = Console.ReadLine();

            //Ask user to enter the Name of the Account Holder.
            Console.Write("\nEnter Your Last Name: ");
            String lastName = Console.ReadLine();

            //Ask user to enter the Account Number.
            Console.Write("\nEnter Account Number: ");
            int accountNumber = Int32.Parse(Console.ReadLine());
            //Make sure no given Account Number is duplicate.

            while (accountNumberExists(accounts, accountNumber))
            {
                Console.WriteLine("Account Number already exists.");
                Console.WriteLine("Enter Account Number for Account: " + count);
                accountNumber = Int32.Parse(Console.ReadLine());
            }
            //Ask user to enter the Balance Amount.
            Console.Write("\nEnter of Checkings Amount for Account: ");
            double checkings = double.Parse(Console.ReadLine());

            //Ask user to enter the Balance Amount.
            Console.Write("\nEnter of Savings Amount for Account: ");
            double savings = double.Parse(Console.ReadLine());

            User newUser = new User(firstName, lastName);

            //Create new Account Objects by calling the constructor.
            accounts[i] = new Account(newUser, accountNumber, checkings, savings);
        }

        bool accountExists = false;
        bool running = true;

        while (running)
        {
            Console.WriteLine("----------------------------");
            //Repeatedly ask the user to enter an Account Number until a valid Account Number is found.
            while (!accountExists)
            {
                Console.WriteLine("Please enter Account Number:");
                int accNumber = Int32.Parse(Console.ReadLine());

                //Iterate through Accounts array to find Account with matching accoung number.
                for (int i = 0; i < accounts.Length; i++)
                {
                    if (accNumber == accounts[i].accountNumber)
                    {
                        //Keep track of index of the Account that was found.
                        index = i;

                        accountExists = true;
                        condition = 1;
                    }
                }

                // Prompt user if account is not found.
                if (accountExists == false)
                {
                    Console.WriteLine("Account does not exist.\n");
                }
            }

            while (accountExists)
            {
                while (condition == 1)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Account Number: " + accounts[index].accountNumber);
                    Console.WriteLine("Please Select Account Type");
                    //Display menu and keep track of the selected option.
                    Console.WriteLine("Checkings: " + accounts[index].checkings);
                    Console.WriteLine("Savings: " + accounts[index].savings);
                    option = menu();

                    switch (option)
                    {
                        //Option 1 will withdraw from Account.
                        case 1:
                            isCheckings = -1;
                            Console.WriteLine("--Withdrawal Transaction--");
                            Console.WriteLine("1) From Checkings");
                            Console.WriteLine("2) From Savings");
                            while (isCheckings != 1 && isCheckings != 2)
                            {
                                Console.Write("\nPlease Select An Option:");
                                isCheckings = Int32.Parse(Console.ReadLine());
                                if (isCheckings != 1 && isCheckings != 2)
                                {
                                    Console.WriteLine("Invalid Option.");
                                }
                            }

                            if (isCheckings == 1)
                            {
                                Console.WriteLine("How much cash do you want to withdraw?");
                                amount = double.Parse(Console.ReadLine());
                                if (accounts[index].checkings >= amount)
                                {
                                    accounts[index].checkings = (
                                        accounts[index].checkings - amount
                                    );
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }
                            if (isCheckings == 2)
                            {
                                Console.WriteLine("How much cash do you want to withdraw?");
                                amount = double.Parse(Console.ReadLine());
                                if (accounts[index].savings >= amount)
                                {
                                    accounts[index].savings = (accounts[index].savings - amount);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }
                            break;

                        case 2:

                            isCheckings = -1;
                            Console.WriteLine("--Deposit Transaction--");
                            Console.WriteLine("1) To Checkings");
                            Console.WriteLine("2) To Savings");
                            while (isCheckings != 1 && isCheckings != 2)
                            {
                                Console.Write("\nPlease Select An Option:");
                                isCheckings = Int32.Parse(Console.ReadLine());
                                if (isCheckings != 1 && isCheckings != 2)
                                {
                                    Console.WriteLine("Invalid Option.");
                                }
                            }

                            if (isCheckings == 1)
                            {
                                Console.WriteLine("How much cash do you want to deposit?");
                                amount = double.Parse(Console.ReadLine());

                                if (amount < 0)
                                {
                                    Console.WriteLine("Invalid amount");
                                }
                                else
                                {
                                    accounts[index].checkings = accounts[index].checkings + amount;
                                }
                            }
                            if (isCheckings == 2)
                            {
                                Console.WriteLine("How much cash do you want to deposit?");
                                amount = double.Parse(Console.ReadLine());

                                if (amount < 0)
                                {
                                    Console.WriteLine("Invalid amount");
                                }
                                else
                                {
                                    accounts[index].savings = accounts[index].savings + amount;
                                }
                            }
                            break;
                        
                        case 3:


                        case 4:
                            condition = 0;
                            break;
                        //Option 5 will exit the Program.
                        case 5:
                            condition = 0;
                            running = false;
                            break;
                        default:
                            break;
                    }
                }
                accountExists = false;
            }
        }
    }
}
