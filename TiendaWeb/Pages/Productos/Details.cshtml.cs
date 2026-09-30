using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Data;
using TiendaWeb.Models;

namespace TiendaWeb.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly TiendaContext _context;

        public DetailsModel(TiendaContext context)
        {
            _context = context;
        }

        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            Producto = producto;
            return Page();
        }
    }
}
