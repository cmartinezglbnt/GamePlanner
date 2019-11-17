using GamePlanner.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Technology> Technology { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}
