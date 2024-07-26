using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankData.Repo
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankContext>
    {
        public BankContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BankDatabase;User Id=sa;Password=Hpc344307;TrustServerCertificate=True");

            return new BankContext(optionsBuilder.Options);
        }
    }
}