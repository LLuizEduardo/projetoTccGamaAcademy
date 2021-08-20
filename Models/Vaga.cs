using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projetoGamaAcademy.Models
{
  [Table("vagas")]
  public class Vaga
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome_vaga", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string NomeVaga { get;set; }
    
    [Column("descricao", TypeName = "varchar")]
    [MaxLength(1000)]
    [Required]
    public string Descricao { get;set; }

    [Column("empresa", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Empresa { get;set; }
 
    [Column("segmento", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Segmento { get;set; }

    [Column("telefone", TypeName = "varchar")]
    [MaxLength(15)]
    [Required]
    public string Telefone { get;set; }

    [Column("site", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Site { get;set; }

    [Column("logradouro", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Logradouro { get;set; }

    [Column("numero", TypeName = "varchar")]
    [MaxLength(20)]
    [Required]
    public string Numero { get;set; }

    [Column("bairro", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Bairro { get;set; }
    
    [Column("cidade", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Cidade { get;set; }

    [Column("estado", TypeName = "varchar")]
    [MaxLength(30)]
    [Required]

    public ICollection<Candidato> Candidatos { get; set; }
  }
}