using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankData.Models;

public class User{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string firstName {get; set;}
    public string lastName {get;set;}

    public User(string firstName, string lastName){
        this.firstName = firstName;
        this.lastName = lastName;
    }
}