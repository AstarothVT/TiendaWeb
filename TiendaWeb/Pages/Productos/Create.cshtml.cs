using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaWeb.Data;
using TiendaWeb.Models;

namespace TiendaWeb.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly TiendaContext _context;

        public CreateModel(TiendaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; } = default!;

        // Se ejecuta cuando se envía el formulario
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
