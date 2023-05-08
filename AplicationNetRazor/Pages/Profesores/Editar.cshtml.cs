using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicationNetRazor.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        private readonly AplicationDbContext _contexto;

        public EditarModel(AplicationDbContext contexto)
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
                var ProfesorDesdeDB = await _contexto.Profesor.FindAsync(Profesor.idProf);

                ProfesorDesdeDB.Nombre = Profesor.Nombre;
                ProfesorDesdeDB.Apellido = Profesor.Apellido;
                ProfesorDesdeDB.esp = Profesor.esp;
                ProfesorDesdeDB.fecha_ing = Profesor.fecha_ing;
                ProfesorDesdeDB.fecha_nac = Profesor.fecha_nac;

                _contexto.SaveChanges();
                Mensaje = "Profesor editado exitosamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage("");
        }
    }
}

