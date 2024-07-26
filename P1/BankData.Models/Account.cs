using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankData.Models;


public class Account
{

    //Variables to represent Account Information.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }
    public User user{get;set;}
    public int accountNumber{get;set;}
    public double checkings{get; set;}
    public double savings{get;set;}

     public Account() { }

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
        return "Account Holder: " + user.firstName + " " + user.lastName +  "\nAccount Number: " + accountNumber + "\nCheckings Balance: $" + checkings + "\nSavings Balance: $" + savings;
    }
}
