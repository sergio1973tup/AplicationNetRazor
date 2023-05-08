using System.ComponentModel.DataAnnotations;

namespace AplicationNetRazor.Modelos
{
    public class Alumno
    {
        [Key]
        [Display(Name = "Clave")]
        public int idAlumno { get; set; }
        [Required,StringLength(100)]
        [Display(Name ="Nombre del Alumno")]
        public string Nombre { get; set; }

        [Required,StringLength(50)]
        [Display(Name = "Aplellido del Alumno")]
        public string Apellido { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Fecha_nac { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        [Display(Name = "Fecha de ingreso")]
        public DateTime Fecha_ing { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: HH-mm-ss}")]
        [Display(Name = "Hora de Ingreso")]
        public DateTime Hora_ing { get; set; }

        [Required]
        [Display(Name ="Cantidad de Cursos")]
        public int Cantidad_cursos { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de egreso")]
        public DateTime Fecha_egr { get; set; }

        [Required]
        public bool Eliminado { get; set; }

    }
}
