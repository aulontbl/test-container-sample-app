using Microsoft.EntityFrameworkCore;

namespace TestContainerSampleApp;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Coder> Coders { get; set; }
    public DbSet<AdisCoder> AdisCoders { get; set; }
}