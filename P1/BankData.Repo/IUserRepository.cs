using BankData.Models;

namespace BankData.Repo;

public interface IUserRepository
{
    void addUser(User user);
    User getUserByName(string firstName, string lastName);   
}
