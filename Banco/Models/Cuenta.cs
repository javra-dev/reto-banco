using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Models
{
    [Table("Cuenta", Schema = "dbo")]
    public class Cuenta : IModelos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("Tipo")]
        public string? Tipo { get; set; }

        [Column("Valor")]
        public int Valor { get; set; }

        [Column("Saldo")]
        public double Saldo { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        [Column("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<Movimiento>? Movimientos { get; set; }
    }
}
