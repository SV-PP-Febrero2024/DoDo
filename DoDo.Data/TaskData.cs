using DoDo.Domain;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace DoDo.Data;
public class TaskData
{
    public List<Domain.Task>? TasksList = new();
    private readonly string TaskJsonPath;
    public TaskData()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            TaskJsonPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "DoDo.Data", "Data.Tasks.json");
        } else {
            TaskJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "DoDo.Data", "Data.Tasks.json");
        }
        GetRegisteredTasks();
    }
    public void AddTask(Domain.Task task)
    {
        TasksList.Add(task);
        SaveTaskData();
    }
    public void GetRegisteredTasks()
    {
        try
        {
        string JsonTasks = File.ReadAllText(TaskJsonPath);
        TasksList =  JsonSerializer.Deserialize<List<Domain.Task>>(JsonTasks);
        } catch (System.Exception)
        {
            Console.WriteLine("ERROR TRYING ACCESS DATA");
        }
    }
    public void SaveTaskData()
    {
        string JsonTasks = JsonSerializer.Serialize(TasksList, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(TaskJsonPath, JsonTasks);
    }
}