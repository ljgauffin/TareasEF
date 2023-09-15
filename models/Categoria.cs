namespace EF.Models;

public class Categoria
{
    private Guid categoriaId;
    public Guid CategoriaId
    {
        get { return categoriaId; }
        set { categoriaId = value; }
    }

    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private string descripcion;
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public virtual ICollection<Tarea> Tareas { get; set; }
    
    
    
}