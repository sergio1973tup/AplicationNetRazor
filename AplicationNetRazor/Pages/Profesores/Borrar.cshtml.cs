using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Profesores
{
    public class BorrarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public BorrarModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Profesor Profesor { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Profesor = await _contexto.Profesor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProfesorBorrar = await _contexto.Profesor.FindAsync(Profesor.idProf);

                if (ProfesorBorrar == null)
                {
                    return NotFound();
                }

                _contexto.Profesor.Remove(ProfesorBorrar);
                _contexto.SaveChanges();
                Mensaje = "Profesor borrado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }

    }
}
