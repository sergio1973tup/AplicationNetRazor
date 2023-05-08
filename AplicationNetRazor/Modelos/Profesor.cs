using System.ComponentModel.DataAnnotations;

namespace AplicationNetRazor.Modelos
{
    public class Profesor
    {
        [Key]
        [Display(Name ="Clave")]
        public int idProf { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Especializacion")]
        public int esp { get; set; }
        [Required]
        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime fecha_ing { get; set; }

        [Required]
        [Display(Name ="Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime fecha_nac { get; set; }
        

    }
}
