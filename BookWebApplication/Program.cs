using BookRepository.Data;
using BookWebApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Database Context
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("MariaDB"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDB"))
));

// Add Book Service
builder.Services.AddTransient<IBookService, BookService>();

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
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
