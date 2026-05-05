using Microsoft.EntityFrameworkCore;
using ourReactProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentDBContext>(
    options => options.UseSqlServer(
       builder.Configuration.GetConnectionString("StudentDBContext") )
    );

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true)
                        .AllowAnyMethod()
           );

app.UseCors("AllowAll");
    
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
