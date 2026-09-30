using Microsoft.EntityFrameworkCore;
using TiendaWeb.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Registrar el DbContext con SQL Server (inyección de dependencias)
builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaContext")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
