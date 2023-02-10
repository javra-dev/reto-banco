using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Models
{
    [Table("Movimiento", Schema = "dbo")]
    public class Movimiento: IModelos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        public string? Tipo { get; set; }

        [Column("TipoCuenta")]
        public string TipoCuenta { get; set; }

        [Column("Valor")]
        public double Valor { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("Saldo")]
        public double Saldo { get; set; }

        public int CuentaID { get; set; }

        public Cuenta Cuenta { get; set; }

    }
}
