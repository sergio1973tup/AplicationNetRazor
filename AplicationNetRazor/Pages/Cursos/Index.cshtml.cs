using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicationNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext _contexto;
        public IndexModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Cursos.ToListAsync();
        }
        public async Task<IActionResult> OnPostBorrar(int id)
        {
            if (ModelState.IsValid)
            {
                var CursoBorrar = await _contexto.Cursos.FindAsync(id);
                
                if(CursoBorrar == null)
                {
                    return NotFound();  
                }

                _contexto.Cursos.Remove(CursoBorrar);
                await _contexto.SaveChangesAsync();
                Mensaje = "Curso eliminado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}
