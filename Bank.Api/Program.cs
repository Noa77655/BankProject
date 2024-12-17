using Bank.Core.Repositories;
using Bank.Core.Services;
using Bank.Data.Repositories;
using Bank.Service;
using project;
using Stripe;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IbankerService, BankerService>();
builder.Services.AddScoped<IbankerRepository, BankerRepository>();

builder.Services.AddDbContext<DataContext>();

//builder.Services.AddDbContext<DataContext>();


builder.Services.AddScoped<IcustomerService, customerService>();
builder.Services.AddScoped<IcustomerRepository, CustomerRepository>();


builder.Services.AddScoped<IturnService, TurnService>();
builder.Services.AddScoped<IturnRepository, TurnRepository>();



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
