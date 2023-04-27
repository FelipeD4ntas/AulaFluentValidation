using Microsoft.EntityFrameworkCore;
using ProjetoFluentValidation.Domain.Entidades;

namespace ProjetoFluentValidation.Infra.Context;

public class AppContextDB : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public AppContextDB(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContextDB).Assembly);
    }
}
