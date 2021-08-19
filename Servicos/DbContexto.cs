using projetoGamaAcademy.Models;
using Microsoft.EntityFrameworkCore;

namespace projetoGamaAcademy.Servicos
{
  public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Candidato> Candidatoss { get; set; }
  }
}