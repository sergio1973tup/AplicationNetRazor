using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicationNetRazor.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext _contexto;
        public IndexModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Alumno> Alumnos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Alumnos = await _contexto.Alumno.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            if (ModelState.IsValid)
            {
                var AlumnoBorrar = await _contexto.Alumno.FindAsync(id);

                if (AlumnoBorrar == null)
                {
                    return NotFound();
                }

                _contexto.Alumno.Remove(AlumnoBorrar);
                await _contexto.SaveChangesAsync();
                Mensaje = "Curso eliminado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}
