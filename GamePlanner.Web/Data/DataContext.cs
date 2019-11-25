using GamePlanner.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using GamePlanner.Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Technology> Technology { get; set; }
    public DbSet<Public> Public { get; set; }
    public DbSet<Gender> Gender { get; set; }
    public DbSet<Idea> Idea { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Concept> Concept { get; set; }
    public DbSet<Developer> Developer { get; set; }
    public DbSet<GamePlay> GamePlay { get; set; }
    public DbSet<Meeting> Meeting { get; set; }
    public DbSet<Platform> Platform { get; set; }
    public DbSet<Producer> Producer { get; set; }
    public DbSet<Tool> Tool { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model
            .G­etEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);

        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restr­ict;
        }

        base.OnModelCreating(modelBuilder);
    }
}
