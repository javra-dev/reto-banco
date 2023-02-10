using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Models
{
    [Table("Persona", Schema = "dbo")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Genero")]
        public string Genero { get; set; }
        [Column("Identificacion")]
        public string Identificacion { get; set; }
        [Column("Telefono")]
        public string Telefono { get; set; }
        [Column("Direccion")]
        public string Direccion { get; set; }
        [Column("Edad")]
        public int Edad { get; set; }
    }
}
