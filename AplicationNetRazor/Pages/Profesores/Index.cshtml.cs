using AplicationNetRazor.Datos;
using AplicationNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicationNetRazor.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext _contexto;
        public IndexModel(AplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Profesor> Profesores { get; set; }

        [TempData]

        public string Mensaje { get; set; }


        public async Task OnGet()
        {
            Profesores = await _contexto.Profesor.ToListAsync();
        }
    }
}
