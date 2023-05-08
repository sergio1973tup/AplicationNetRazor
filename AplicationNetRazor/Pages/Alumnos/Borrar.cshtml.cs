using AplicationNetRazor.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Alumnos
{
    public class BorrarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public BorrarModel(AplicationDbContext contexto)
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
                var AlumnoBorrar = await _contexto.Alumno.FindAsync(Alumno.idAlumno);

                if (AlumnoBorrar == null)
                {
                    return NotFound();
                }

                AlumnoBorrar.Eliminado = true;

                await _contexto.SaveChangesAsync();
                Mensaje = "Alumno Borrado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}
