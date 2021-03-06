using Microsoft.EntityFrameworkCore;
using Pizzaria.Controllers;
using Pizzaria.Data;
using Pizzaria.Services;
using Pizzaria.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<PizzasController>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<BebidaService>();
builder.Services.AddScoped<AvaliacaoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RodrigoConnection")));
//builder.Configuration.GetConnectionString("RodrigoConnection");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
