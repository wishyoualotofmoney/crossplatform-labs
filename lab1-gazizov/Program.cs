using lab1_gazizov.Data;  // ���������� ������������ ����, ��� ��������� ��� �������� ������
using Microsoft.AspNetCore.Authentication.JwtBearer;  // ��� ������ � JWT
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;  // ��� ��������� �������
using Microsoft.OpenApi.Models;  // ���������� ������������ ���� ��� Swagger
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ ����������� �� appsettings.json � ������������ �������� ���� ������ � ���������� ��������� �������
builder.Services.AddDbContext<BarbershopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

// ��������� �������������� � JWT ��������
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "BarbershopAPI",
        ValidAudience = "BarbershopAPI",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJWT1234567890123456")) // ����� ������� ����
    };
});

// ��������� �����������
builder.Services.AddAuthorization();

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

    // ����������� ����������� ��� Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "������� ����� � �������: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// ��������� ����������� � �������������
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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ��������� ������������� ��������������
app.UseAuthorization();  // ��������� ������������� �����������

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
