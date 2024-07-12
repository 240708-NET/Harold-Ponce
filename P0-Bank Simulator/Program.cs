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
            if (accounts[i] != null && accountNumber == accounts[i].getAccountNumber())
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

        //Create an array to store Account objects.
        Account[] accounts = new Account[numberOfAccounts];
        int count = 1;

        //Ask user to input necessary information for each account.
        for (int i = 0; i < numberOfAccounts; i++)
        {
            //Ask user to enter the Name of the Account Holder.
            Console.WriteLine("\nEnter Name of the Account Holder for Account: " + count);
            String name = Console.ReadLine();
            //Ask user to enter the Account Number.
            Console.WriteLine("Enter Account Number for Account: " + count);
            int accountNumber = Int32.Parse(Console.ReadLine());
            //Make sure no given Account Number is duplicate.
            while (accountNumberExists(accounts, accountNumber))
            {
                Console.WriteLine("Account Number already exists.");
                Console.WriteLine("Enter Account Number for Account: " + count);
                accountNumber = Int32.Parse(Console.ReadLine());
            }
            //Ask user to enter the Balance Amount.
            Console.WriteLine("Enter of Balance Amount for Account: " + count);
            double balance = double.Parse(Console.ReadLine());
            count++;

            //Create new Account Objects by calling the constructor.
            accounts[i] = new Account(name, accountNumber, balance);
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
                    if (accNumber == accounts[i].getAccountNumber())
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
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Account Number: " + accounts[index].getAccountNumber());
                    //Display menu and keep track of the selected option.
                    option = menu();

                    switch (option)
                    {
                        //Option 1 will withdraw from Account.
                        case 1:
                            Console.WriteLine("How much cash do you want to withdraw?");
                            double withdraw = double.Parse(Console.ReadLine());
                            if (accounts[index].getBalance() >= withdraw)
                            {
                                accounts[index].setBalance(accounts[index].getBalance() - withdraw);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance");
                            }
                            break;
                        //Option 2 will deposit to Account.
                        case 2:
                            Console.WriteLine("How much cash do you want to deposit?");
                            double deposit = double.Parse(Console.ReadLine());
                            if (deposit < 0)
                            {
                                Console.WriteLine("Invalid amount");
                            }
                            else
                            {
                                accounts[index].setBalance(accounts[index].getBalance() + deposit);
                            }
                            break;
                        //Option 3 will display Balace Inquiry.
                        case 3:
                            Console.WriteLine("\n" + accounts[index].ToString() + "\n");
                            break;
                        //Option 4 will exit the Account.
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
