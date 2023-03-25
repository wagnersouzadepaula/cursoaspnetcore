// tudo inicia a partir do builder
using Microsoft.AspNetCore.Mvc.Razor;
using DevIO.UI.Site.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando suporte a mudança de convenção da rota das areas.
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // limpando a convenção
    options.AreaViewLocationFormats.Clear();
    // define uma nova convençao para uso de areas com o nome de Modulos
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Configurando o DBContext
//builder.Services.AddDbContext<MeuDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDBContext")));
builder.Services.AddDbContext<MeuDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MeuDBContext")));

// Adicionando o MVC ao Container
builder.Services.AddControllersWithViews();

// Adicionando a injeção de dependencia o IPedidoRepository
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();


// realiza o build das configurações que resultará na APP
var app = builder.Build();

// Ativa a pagina de erros caso seja ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Usar os arquivos estáticos da wwwroot.
app.UseStaticFiles();

app.UseRouting();


// Rota de área genérica (não necessário no caso da demo)
app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Roda de área pedidos
app.MapControllerRoute("AreaVendas", "Vendas", "Vendas{controller=Pedidos}/{action=Index}/{id?}");

app.MapControllerRoute("AreaProdutos", "Produtos" , "Produtos{controller=Cadastro}/{action=Index}/{id?}");



// Adicionando a rota padrão: 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
