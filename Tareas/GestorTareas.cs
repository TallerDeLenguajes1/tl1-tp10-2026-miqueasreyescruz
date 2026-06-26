namespace Tareas;

using System.Text.Json;

public class GestorTarea
{
    // Declaro 2 instancia de listas de tareas para usarlas en un futuo
    List<Tarea> _tareaspendientes = new List<Tarea> ();
    List<Tarea> _tareasrealizadas = new List<Tarea> ();

    // Creo la instancia unica del cliente HttpClient
    private static readonly HttpClient client = new HttpClient();
    // Declaro el metodo asincrono, el cual recibe una url (valida) y luego guarda las tareas
    public async Task<List<Tarea>> GetTareas(string url)
    {
        // Realizo la peticion HTTP GET
        HttpResponseMessage response = await client.GetAsync(url);
        // Valido el estado de la respuesta
        response.EnsureSuccessStatusCode();
        // Leo el cuerpo de la respuesta como texto
        string body = await response.Content.ReadAsStringAsync();
        // Deserializacion
        List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(body);
        // Recorro las tareas y las clasifico segun si estan realizadas
        foreach (var tarea in tareas)
        {
            if (tarea.completed == true)
            {
                _tareasrealizadas.Add(tarea);
            }
            else
            {
                _tareaspendientes.Add(tarea);
            }
        }
        return tareas;
    }

    public IReadOnlyList<Tarea> Pendientes
    {
        get => _tareaspendientes.AsReadOnly();
    }
    public IReadOnlyList<Tarea> Realizadas
    {
        get => _tareasrealizadas.AsReadOnly();
    }
}