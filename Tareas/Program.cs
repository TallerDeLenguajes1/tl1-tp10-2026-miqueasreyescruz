// ========================
//        ESPACIOS
// ========================

using Tareas;

// ========================
//          MAIN
// ========================

var Gestor = new GestorTarea();
List<Tarea> paqueteJson = await Gestor.GetTareas("https://jsonplaceholder.typicode.com/todos/");

mostrarTareas("tareas ingresadas",paqueteJson);
mostrarTareas("tareas pendientes",Gestor.Pendientes);
mostrarTareas("tareas realizadas",Gestor.Realizadas);

// ========================
//         FUNCIONES
// ========================

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