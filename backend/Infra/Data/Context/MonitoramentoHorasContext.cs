using backend.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace backend.Infra.Data.Context
{
    public class MonitoramentoHorasContext : DbContext
    {
        public MonitoramentoHorasContext(DbContextOptions<MonitoramentoHorasContext> options) : base(options) { }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rastreamento> Rastreamentos { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<IntegranteEquipe> IntegranteEquipes { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setor>().HasKey(key => key.Id);
            modelBuilder.Entity<Pessoa>().HasKey(key => key.Id);
            modelBuilder.Entity<Usuario>().HasKey(key => key.Id);
            modelBuilder.Entity<Rastreamento>().HasKey(key => key.Id);
            modelBuilder.Entity<Equipe>().HasKey(key => key.Id);
            modelBuilder.Entity<IntegranteEquipe>().HasKey(key => key.Id);
            modelBuilder.Entity<Configuracao>().HasKey(key => key.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
