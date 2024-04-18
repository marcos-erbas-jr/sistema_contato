using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;//linha que adicionei

using ControledeContatos.Data;
//using ControledeContatos.Repositorio;//linha que adicionei


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));//linha que adicionei

//builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();//linha que adicionei

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
