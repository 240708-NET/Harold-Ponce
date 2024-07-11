class Program{

    public static int menu(){   
        int option = 0;
        
        Console.WriteLine("1) Withdrawal");
        Console.WriteLine("2) Deposit");
        Console.WriteLine("3) Balance Inquiry");
        Console.WriteLine("4) Exit Account");

        while(option < 1 || option > 4){
            Console.WriteLine("\nPlease select an option(1-4):");
            option = Int32.Parse(Console.ReadLine());
        }
                       
       return option;                
    }

    static void Main(String[] args){
        Console.WriteLine("How many accounts do you want to create?");
        int numberOfAccounts = Int32.Parse(Console.ReadLine());
        int index  = 0;
        int option = 0;
        int condition = 0;

        Account[] accounts = new Account[numberOfAccounts];
        int count = 1;

        
        for(int i = 0;i<numberOfAccounts;i++){
            Console.WriteLine("\nEnter Full Name for Account: " + count);
            String name = Console.ReadLine();


            Console.WriteLine("Enter Account Number for Account: " + count);
            int accountNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter of Balance Amount for Account: " + count);
            double balance = double.Parse(Console.ReadLine()); 
            count++;

            accounts[i] = new Account(name,accountNumber,balance);
        }

        bool accountExists = false;
        Console.WriteLine("----------------------------");
        while(!accountExists){
        Console.WriteLine("Please enter Account Number:");
        int accNumber = Int32.Parse(Console.ReadLine()); 
        for(int i = 0; i<accounts.Length;i++){
            if(accNumber == accounts[i].getAccountNumber()){
                index = i;
                accountExists = true;
                condition = 1;
            }
        }

        if(accountExists == false){
            Console.WriteLine("Account does not exist.\n");
        }
    }

    while(accountExists){
        while(condition == 1){
            Console.WriteLine("----------------------------");
        Console.WriteLine("Account Number: " + accounts[index].getAccountNumber());
        option = menu();

        switch(option){
            case 1:
                Console.WriteLine("How much cash do you want to withdraw?");
                double withdraw = double.Parse(Console.ReadLine());
                if(accounts[index].getBalance() >= withdraw){
                    accounts[index].setBalance(accounts[index].getBalance() - withdraw);
                }
                else{
                    Console.WriteLine("Insufficient Balance");
                }
                break;
            case 2:   
                Console.WriteLine("How much cash do you want to deposit?");
                double deposit = double.Parse(Console.ReadLine());
                if(deposit < 0){
                    Console.WriteLine("Invalid amount");
                }
                else{
                    accounts[index].setBalance(accounts[index].getBalance() + deposit);
                }     
                break;
            case 3:
                Console.WriteLine("\n" + accounts[index].ToString() + "\n");
                break;
            case 4:
                condition = 0;
                break;
            default:
                break;

        }
        }
        
        accountExists = false;
    }

    }
    
}
