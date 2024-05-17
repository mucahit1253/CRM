using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EfCore;
using Services.Contracts;
using WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);

//burada loglar� aktar�m� yapt�k
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
//outa Mahper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
//hatalr� ald�k burada 
var logger=app.Services.GetRequiredService<ILoggerService> ();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//buras�da hata ilgili
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
