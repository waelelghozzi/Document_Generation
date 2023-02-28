using Microsoft.AspNetCore.StaticFiles;

using Generation_Documents.DBContext;
using Generation_Documents.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using Serilog;
using System.Text;
using Generation_Documents.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
//adding the authentication
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentification:Issuer"],
        ValidAudience = builder.Configuration["Authentification:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Authentification:SecretForKey"]))
    };
}
);

//builder.Services.AddAuthorization(options => options.AddPolicy("MustBeFromCED", policy =>
//{
//    policy.RequireAuthenticatedUser();
//    policy.RequireClaim("username", "wael");
//}));
//builder.Services.AddSingleton<DataStore>();

builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:PersonInfoDBConnectionSrting"]));


builder.Services.AddScoped<IDataRepository, DataRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
