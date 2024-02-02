namespace DoDo.Domain;
public class User
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public int IdNumber { get; set; }
    private static int IdNumberSeed = 100;

    public User(){} 
    public User(string name, string email, string password){
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.RegistrationDate = DateTime.Today;
        this.IdNumber = IdNumberSeed;
    }
    public User(string name, string email, string password, int idNumber){
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.RegistrationDate = DateTime.Today;
        this.IdNumber = idNumber;
    }
}