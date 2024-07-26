using System.Collections.Generic;
using BankData.Models;
using Microsoft.EntityFrameworkCore;

namespace BankData.Repo;

public class AccountRepository : IAccountRepository
{
    private readonly BankContext _context;

    public AccountRepository(BankContext context)
    {
        _context = context;
    }

    public void addAccount(Account account){
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }

    public Account getAccountByAccountNumber(int accountNumber){
        return _context.Accounts.Include(a => a.user).FirstOrDefault(a => a.accountNumber == accountNumber);
    }

    public bool accountNumberExists(int accountNumber){
        return _context.Accounts.Any(a => a.accountNumber == accountNumber);
    }

    public void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
}