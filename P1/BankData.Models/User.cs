namespace BankData.Models;

public class User{
    public string firstName {get; set;}
    public string lastName {get;set;}

    public User(string firstName, string lastName){
        this.firstName = firstName;
        this.lastName = lastName;
    }
}