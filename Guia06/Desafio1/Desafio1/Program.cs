using Desafio1.Controllers;
using Biblioteca.BL.Interfaces;
using Biblioteca.BL;
using Biblioteca.Common;
using Biblioteca.DAL.Interfaces;
using Biblioteca.DAL;
using AutoMapper;
using Biblioteca.BL.AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddHttpClient();

builder.Services.AddHttpClient<AutorController>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
