using Finance.Application.Extensions;
using Finance.Infra.Extensions;
using Finance.Extensions;
using Finance.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["PostgreSql:ConnectionString"];
var dbPassword = builder.Configuration["PostgreSql:DbPassword"];

var NpgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionString)
{
    Password = dbPassword
};

builder.Services.AddDbContext<FinanceContext>(options => options.UseNpgsql(NpgsqlBuilder.ConnectionString));

//var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
//builder.Services.AddDbContext<FinanceContext>(options =>
//    options.UseNpgsql(
//        connectionString
//    )
//);

builder.Services
    .AddMediatorToUseCases()
    .AddUseCases()
    .AddRepositories();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
