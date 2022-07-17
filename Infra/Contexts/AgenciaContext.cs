using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts;

public class AgenciaContext : DbContext
{
    public DbSet<Agencias.Agencia> Agencias { get; set; }
    public DbSet<Agencias.Segmento> Segmentos { get; set; }

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
    public IQueryable<Materiais.Segmento> Segmentos { get; set; }
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

        modelBuilder.Entity<Materiais.Segmento>(options =>
        {
            options.ToView("Segmentos");
        });

        modelBuilder.Entity<Materiais.Material>()
            .HasOne(x => x.Segmento)
            .WithMany(x => x.Materiais)
            .HasForeignKey(x => x.SegmentoId);
    }
}

public class FaturamentoContext : DbContext
{
    public IQueryable<Faturamentos.Agencia> Agencias { get; set; }
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
