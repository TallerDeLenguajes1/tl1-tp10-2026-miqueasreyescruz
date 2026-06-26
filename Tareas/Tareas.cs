namespace Tareas;

public class Tarea
{
    private int _userid;
    private int _id;
    private string _title;
    private bool _completed;
    public int userId { get => _userid; set => _userid = value; }
    public int id { get => _id; set => _id = value; }
    public string title { get => _title; set => _title = value; }
    public bool completed { get => _completed; set => _completed = value; }
    public Tarea(int userId, int id, string title, bool completed)
    {
        this.userId = userId;
        this.id = id;
        this.title = title;
        this.completed = completed;
    }
}