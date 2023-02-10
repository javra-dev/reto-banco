using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movimiento.Models
{
    [Table("Transacciones", Schema = "dbo")]
    public class Transaccion: IModelos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Tipo")]
        public string? Tipo { get; set; }
        [Column("Valor")]
        public int Valor { get; set; }
        [Column("Fecha")]
        public DateTime Fecha { get; set; }
        [Column("Saldo")]
        public double Saldo { get; set; }
    }
}
