using System.Collections.Generic;
using BankData.Models;

namespace BankData.Repo;

public class UserRepository : IUserRepository
{
    private readonly BankContext _context;

    public UserRepository(BankContext context){
        _context = context;
    }

    public void addUser(User user){
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User getUserByName(string firstName, string lastName){
            return _context.Users.FirstOrDefault(u => u.firstName == firstName && u.lastName == lastName);
    }


}