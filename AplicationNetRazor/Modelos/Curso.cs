using System.ComponentModel.DataAnnotations;

namespace AplicationNetRazor.Modelos
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del Curso")]
        public String NombreCurso { get; set; }
        [Display(Name = "Cantidad de Clases")]
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public bool Eliminado { get; set; }
    }
}
