using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//antes que se corra la aplicaci´pn se debe correr la configuración de context
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB")); //se corre la db en memoria
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//endpoint que verifica la creacion de la db
app.MapGet("/dbconexion", async([FromServices] TareasContext DbContext) =>
    {
        DbContext.Database.EnsureCreated();
        return Results.Ok($"Base de datos en memoria: {DbContext.Database.IsInMemory()}");
    }
);

app.Run();
