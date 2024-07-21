using System.Reflection;
using Senlin.Mo;
using SenlinWu.Pets;
var assembly = typeof(PetModule).Assembly;
var t = assembly.FullName;
var builder = WebApplication.CreateBuilder(args);
var connectionString = "host=127.0.0.1,port=3306;userId=root;password=senlin;database=senlin_wu_pet";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMo(new PetModule(connectionString));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMo("api");

app.Run();