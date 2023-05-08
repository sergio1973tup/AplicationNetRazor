using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Alumnos
{
    public class EditarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public EditarModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Modelos.Alumno Alumno { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Alumno = await _contexto.Alumno.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AlumnoDesdeDB = await _contexto.Alumno.FindAsync(Alumno.idAlumno);

                AlumnoDesdeDB.Nombre = Alumno.Nombre;
                AlumnoDesdeDB.Apellido = Alumno.Apellido;
                AlumnoDesdeDB.Fecha_nac = Alumno.Fecha_nac;
                AlumnoDesdeDB.Fecha_ing = Alumno.Fecha_ing;
                AlumnoDesdeDB.Hora_ing = Alumno.Hora_ing;
                AlumnoDesdeDB.Cantidad_cursos = Alumno.Cantidad_cursos;
                AlumnoDesdeDB.Fecha_egr = Alumno.Fecha_egr;

                _contexto.SaveChanges();
                Mensaje = "Alumno editado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}

