using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Data;
using TiendaWeb.Models;

namespace TiendaWeb.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly TiendaContext _context;

        // El DbContext llega por inyección de dependencias (registrado en Program.cs)
        public IndexModel(TiendaContext context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get; set; } = new List<Producto>();

        // Reto adicional: buscador por nombre
        [BindProperty(SupportsGet = true)]
        public string? Buscar { get; set; }

        // Se ejecuta cuando el usuario abre /Productos
        public async Task OnGetAsync()
        {
            var consulta = _context.Productos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Buscar))
            {
                consulta = consulta.Where(p => p.Nombre.Contains(Buscar));
            }

            Producto = await consulta.ToListAsync();
        }
    }
}
