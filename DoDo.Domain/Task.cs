namespace DoDo.Domain;
public class Task
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? CreationDate { get; set; }
    public bool Completed { get; set; } = false;
    public int prioridad { get; set; } = 0;
    public int IdNumber { get; set; }
    private static int IdNumberSeed = 1111;

    public Task(){} 
    public Task(string title, string description){
        this.Title = title;
        this.Description = description;
        this.CreationDate = DateTime.Today;
        this.IdNumber = IdNumberSeed;
    }
    public Task(string title, string description, int idNumber){
        this.Title = title;
        this.Description = description;
        this.CreationDate = DateTime.Today;
        this.IdNumber = idNumber;
    }
}
