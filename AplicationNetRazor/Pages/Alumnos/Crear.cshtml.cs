using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Alumnos
{
    public class CrearModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public CrearModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Alumno Alumno { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contexto.Add(Alumno);
            await _contexto.SaveChangesAsync();
            Mensaje = "Alumno creado exitosamente";
            return RedirectToPage("Index");
        }
    }
}
