using lab1_gazizov.Data;  // Подключаем пространство имен, где находится ваш контекст данных
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;  // Подключаем пространство имен для Swagger

var builder = WebApplication.CreateBuilder(args);

// Добавляем строку подключения из appsettings.json и регистрируем контекст базы данных
builder.Services.AddDbContext<BarbershopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем Swagger для генерации документации API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Barbershop API",
        Version = "v1",
        Description = "API для управления барбершопом, включает CRUD операции для парикмахеров, клиентов и записей"
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Включаем Swagger и Swagger UI только в режиме разработки
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barbershop API V1");
        c.RoutePrefix = string.Empty;  // Swagger UI будет доступен по корневому URL
    });
}
else
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
