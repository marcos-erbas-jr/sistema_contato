using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer;//linha que adicionei
using ControledeContatos.Data;
using ControledeContatos.Repositorio;
using SistemaDeCadastro.Helper;//linha que adicionei


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));//linha que adicionei

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //linha que adicionei

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();//linha que adicionei
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();//linha que adicionei

builder.Services.AddScoped<ISessao, Sessao>();//linha que adicionei
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
}); //linha que adicionei

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); //linha que adicionei

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
