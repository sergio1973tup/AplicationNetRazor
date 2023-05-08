using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Cursos
{
    public class BorrarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public BorrarModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Modelos.Curso Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _contexto.Cursos.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoBorra = await _contexto.Cursos.FindAsync(Curso.Id);

                if (CursoBorra == null)
                {
                    return NotFound();
                }

                CursoBorra.Eliminado = true;

                _contexto.SaveChanges();
                Mensaje = "Curso actualizado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}
