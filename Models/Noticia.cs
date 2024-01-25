using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProjetoAspMvc.Models
{
    [Table("Noticia")]
    public class Noticia
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Titulo")]
        [Display(Name = "Titulo")]
        public string TituloNoticia { get; set; }
    }
}
