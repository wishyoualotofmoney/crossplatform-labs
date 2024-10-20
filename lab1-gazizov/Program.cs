using lab1_gazizov.Data;  // ���������� ������������ ����, ��� ��������� ��� �������� ������
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;  // ���������� ������������ ���� ��� Swagger

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ ����������� �� appsettings.json � ������������ �������� ���� ������
builder.Services.AddDbContext<BarbershopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� Swagger ��� ��������� ������������ API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Barbershop API",
        Version = "v1",
        Description = "API ��� ���������� �����������, �������� CRUD �������� ��� ������������, �������� � �������"
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // �������� Swagger � Swagger UI ������ � ������ ����������
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barbershop API V1");
        c.RoutePrefix = string.Empty;  // Swagger UI ����� �������� �� ��������� URL
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
