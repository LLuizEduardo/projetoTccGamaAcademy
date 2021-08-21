using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projetoGamaAcademy.Models
{
  [Table("candidatos")]
  public class Candidato
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Nome { get;set; }

    [Column("cpf", TypeName = "varchar")]
    [MaxLength(11)]
    [Required]
    public string CPF { get;set; }
    
    [Column("nascimento", TypeName = "varchar")]
    [MaxLength(10)]
    [Required]
    public string Nascimento { get;set; }

    [Column("telefone", TypeName = "varchar")]
    [MaxLength(15)]
    [Required]
    public string Telefone { get;set; }

    [Column("email", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Email { get;set; }

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
    public string Estado { get;set; }

    //[JsonIgnore]
    //public Vaga vaga { get; set; }

    [Column("vaga_id")]
    [Required]
    [ForeignKey("VagaId")]
    public int VagaId { get; set; }
  }
}