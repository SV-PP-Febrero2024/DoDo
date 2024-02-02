namespace DoDo.Domain;
public class Task
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? CreationDate { get; set; }
    public bool Completed { get; set; } = false;
    public int Priority { get; set; } = 0;
    public User? Owner { get; set; }
    public int IdNumber { get; set; }
    private static int IdNumberSeed = 1111;

    public Task(){} 
    public Task(string title, string description, int priority, User user){
        this.Title = title;
        this.Description = description;
        this.CreationDate = DateTime.Today;
        this.Priority = priority;
        this.Owner = user;
        this.IdNumber = IdNumberSeed;
    }
    public Task(string title, string description, int priority, User user, int idNumber){
        this.Title = title;
        this.Description = description;
        this.CreationDate = DateTime.Today;
        this.Priority = priority;
        this.Owner = user;
        this.IdNumber = idNumber;
    }
}
