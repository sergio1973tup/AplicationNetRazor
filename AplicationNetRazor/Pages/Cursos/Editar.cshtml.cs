using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public EditarModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Curso Curso { get; set; }

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
                var CursoDesdeDB = await _contexto.Cursos.FindAsync(Curso.Id);

                CursoDesdeDB.NombreCurso = Curso.NombreCurso;
                CursoDesdeDB.CantidadClases = Curso.CantidadClases;
                CursoDesdeDB.Precio = Curso.Precio;

                _contexto.SaveChanges();
                Mensaje = "Curso actualizado exitosamente";
                return RedirectToPage("Index"); 
            }
            return RedirectToPage("");
        }
    }
}
