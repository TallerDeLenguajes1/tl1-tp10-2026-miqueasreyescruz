// ========================
//        ESPACIOS
// ========================

using System.Text.Json;
using Tareas;

// ========================
//          MAIN
// ========================

var Gestor = new GestorTarea();
List<Tarea> paqueteJson = await Gestor.GetTareas("https://jsonplaceholder.typicode.com/todos/");

mostrarTareas("tareas ingresadas",paqueteJson);
mostrarTareas("tareas pendientes",Gestor.Pendientes);
mostrarTareas("tareas realizadas",Gestor.Realizadas);

string ruta = Directory.GetCurrentDirectory();
serializarJson(ruta,paqueteJson);

// ========================
//         FUNCIONES
// ========================

// Recibe un titulo, una lista, y muestra en pantalla ambas cosas.
void mostrarTareas(string titulo, IReadOnlyList<Tarea> lista)
{
    Console.WriteLine(new string('=', titulo.Length + 4));
    Console.WriteLine($"  {titulo.ToUpper()}  ");
    Console.WriteLine(new string('=', titulo.Length + 4));
    Console.WriteLine($"[{"ID",3}] [{"uID",3}] [{"ESTADO",-10}] | {"TITULO"}");

    foreach (Tarea tarea in lista)
    {
        Console.WriteLine($"[{tarea.id,3}] [{tarea.userId,3}] [{(tarea.completed ? "Completada" : "Pendiente"),-10}] | {tarea.title}");
    }
}

// Recibe una ruta, una lista, y crea el aarchivo tareas.json
void serializarJson(string path, List<Tarea> lista)
{
    string rutaFinal = Path.Combine(path,"tareas.json");
    using StreamWriter escritor = new StreamWriter(rutaFinal);

    string json = JsonSerializer.Serialize(lista);
    escritor.WriteLine($"{json}");   
}