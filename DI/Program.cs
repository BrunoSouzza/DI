using DI;
using DI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration DI
builder.Services.AddScoped<IOperation, Operation>();

// Configuration Ciclo
builder.Services.AddScoped<ICicloScoped, Ciclo>();
builder.Services.AddTransient<ICicloTransient, Ciclo>();
builder.Services.AddSingleton<ICicloSingleton, Ciclo>();

// Configuration Multi
builder.Services.AddScoped<IPeople, PeopleOne>();
builder.Services.AddTransient<IPeople, PeopleTwo>();
builder.Services.AddSingleton<IPeople, PeopleThree>();


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
