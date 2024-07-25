namespace BankData.Models;

class Account
{
    //Variables to represent Account Information.
    public User user{get;set;}
    public int accountNumber{get;set;}
    public double checkings{get; set;}
    public double savings{get;set;}

    //Constructor Method.
    public Account(User user, int accountNumber, double checkings, double savings)
    {
        this.user = user;
        this.accountNumber = accountNumber;
        this.checkings = checkings;
        this.savings = savings;
    }


    //This method will display Account Information.
    public override string ToString()
    {
        return "Name: " + user.firstName + "\nAccount Number: " + accountNumber + "\nCheckings: $" + checkings;
    }
}
