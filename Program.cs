using EF;
using EF.Models;
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

app.MapGet("/api/tareas", async ([FromServices] TareasContext DbContext)=>
    {
        return Results.Ok(DbContext.Tareas.Include(p=>p.Categoria)
        //.Where(p=>p.PrioridadTarea==EF.Models.Prioridad.Alta)
        );
    }
);

app.MapPost("/api/tareas", async ([FromServices] TareasContext DbContext, [FromBody] Tarea tarea)=>
    {
        tarea.TareaId= Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        await DbContext.AddAsync(tarea);
        //await DbContext.Tareas.AddAsync(tarea);

        await DbContext.SaveChangesAsync();
        return Results.Ok();
    }
);

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext DbContext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>
    {
        var tareaActual = DbContext.Tareas.Find(id);
        if(tareaActual!=null){
            tareaActual.CategoriaId= tarea.CategoriaId;
            tareaActual.Titulo= tarea.Titulo;
            tareaActual.PrioridadTarea= tarea.PrioridadTarea;
            tareaActual.Descripcion= tarea.Descripcion;

            await DbContext.SaveChangesAsync();
            return Results.Ok();
        }
       
        return Results.NotFound();

        
    }
);

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext DbContext, [FromBody] [FromRoute] Guid id)=>
    {
        var tareaActual = DbContext.Tareas.Find(id);
        if(tareaActual!=null){
            DbContext.Remove(tareaActual);

            await DbContext.SaveChangesAsync();
            return Results.Ok();
        }
       
        return Results.NotFound();

        
    }
);

app.Run();
