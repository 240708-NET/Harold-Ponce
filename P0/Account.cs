class Account
{
    //Variables to represent Account Information.
    String name = "";
    int accountNumber = 0;
    double balance = 0;

    //Constructor Method.
    public Account(String name, int accountNumber, double balance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    //This method will get the Account Number.
    public int getAccountNumber()
    {
        return accountNumber;
    }

    //This method will get the Balance Amount.
    public double getBalance()
    {
        return balance;
    }

    //This method will set the Balance Amount.
    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    //This method will display Account Information.
    public override string ToString()
    {
        return "Name: " + name + "\nAccount Number: " + accountNumber + "\nBalance: $" + balance;
    }
}
