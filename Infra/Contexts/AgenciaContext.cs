using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts
{
    public class AgenciaContext : DbContext
    {
        public DbSet<Agencias.Agencia> Agencias { get; set; }

        public AgenciaContext(DbContextOptions<AgenciaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencias.Agencia>()
                .ToTable("agencias");
        }
    }

    public class MateriaisContext : DbContext
    {
        public IQueryable<Materiais.Agencia> Agencias { get; set; }
        public DbSet<Materiais.Material> Materiais { get; set; }

        public MateriaisContext(DbContextOptions<MateriaisContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materiais.Agencia>(options =>
            {
                options.ToView("agencias");
            });
                
        }
    }

    public class FaturamentoContext : DbContext
    {
        public DbSet<Faturamentos.Agencia> Agencias { get; set; }
        public DbSet<Faturamentos.Faturamento> Faturamento { get; set; }

        public FaturamentoContext(DbContextOptions<FaturamentoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faturamentos.Agencia>(options =>
            {
                options.ToView("agencias");
            });
        }
    }
}
