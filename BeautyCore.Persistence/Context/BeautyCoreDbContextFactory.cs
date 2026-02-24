using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeautyCore.Persistence.Context
{
    public sealed class BeautyCoreDbContextFactory : IDesignTimeDbContextFactory<BeautyCoreDbContext>
    {
        public BeautyCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BeautyCoreDbContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeautyCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
            );

            return new BeautyCoreDbContext(optionsBuilder.Options);
        }
    }
}
