using System.Collections.Generic;
using BankData.Models;

namespace BankData.Repo;

public class AccountRepository : IAccountRepository
{
    private readonly List<Account> accounts = new List<Account>();

    public void addAccount(Account account){
        accounts.Add(account);
    }

    public Account getAccountByAccountNumber(int accountNumber){
        return accounts.Find(a => a.accountNumber == accountNumber);
    }

    public bool accountNumberExists(int accountNumber){
        return accounts.Exists(a => a.accountNumber == accountNumber);
    }
}