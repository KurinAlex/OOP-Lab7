using Microsoft.EntityFrameworkCore;

namespace OOP_Lab7.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Tax> Taxes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AbroadTransfersTax>();
        builder.Entity<GiftsTax>();
        builder.Entity<GoodsTax>();
        builder.Entity<JobTax>();
        builder.Entity<MilitaryTax>();

        base.OnModelCreating(builder);
    }
}
