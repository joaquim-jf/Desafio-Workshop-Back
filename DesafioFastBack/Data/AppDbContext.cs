using Microsoft.EntityFrameworkCore;
using DesafioFastBack.Models;

namespace DesafioFastBack.Data
{
    //  herdar de DbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // criam as tabelas no SQL Server
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Ata> Atas { get; set; }
        public DbSet<Workshop> Workshops { get; set; }

        // Regras no SQL como quantidade de caracteres
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}