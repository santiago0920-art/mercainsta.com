

using mercainsta.com.Models;
using mercainsta.com.servicios;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Irepositoriopdfcontactanos, repositoriopdfcontactanos>();
builder.Services.AddTransient<IrepositoriopdfC, repositoriopdfC>();
builder.Services.AddTransient<IRepositoriopdfP, repositoriopdfP>();
builder.Services.AddTransient<Irepositoriocompras,repositoricompras>();
builder.Services.AddTransient<Irepositoriopdfv,Repositoriopdfv>();
builder.Services.AddTransient<Irepositoriopdf, repositoriopdf>();
builder.Services.AddTransient<Irepositorioprovedor,repositorioprovedor>();
builder.Services.AddTransient<productoselecionados>();
builder.Services.AddTransient<Irepositorioregistro,repositorioregistro>();
builder.Services.AddTransient<IRepositorioHome, RepositorioHome>();
builder.Services.AddTransient<IRepositorioadmin,repositorioadmin>();
builder.Services.AddTransient<Icarritoservicio,carritoservicio>();
// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;



});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
