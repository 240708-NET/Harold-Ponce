using BankData.Models;

namespace BankData.Repo;

public interface IAccountRepository
{
    void addAccount(Account account);
    Account getAccountByAccountNumber(int accountNumber);
    bool accountNumberExists(int accountNumber);
}
