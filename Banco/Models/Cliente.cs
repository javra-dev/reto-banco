using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Models
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente : Persona, IModelos
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("Id")]
        //public int Id { get; set; }
        [Column("Password")]
        public string? Password { get; set; }
        [Column("Estado")]
        public bool Estado { get; set; }
        public ICollection<Cuenta>? Cuentas { get; set; }


    }
}
