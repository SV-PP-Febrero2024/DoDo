using System.Dynamic;
using DoDo.Data;
using DoDo.Domain;
using Spectre.Console;

namespace DoDo.Service;
public class TaskService
{
    public readonly TaskData taskData = new();
    public readonly UserService userService = new();
    public Table TasksTable = new();
    private int existingTaskIndex;
    public void SearchForTasks()
    {
        AnsiConsole.MarkupLine("[green]Searching for tasks[/]");
        AnsiConsole.MarkupLine("");
        string searchText = AnsiConsole.Ask<string>("Write a Task title:").ToLower();
        AnsiConsole.WriteLine("");
        User user = userService.GetLoggedInUser();
        List<Domain.Task> findedTasks = taskData.TasksList.FindAll(x => x.Title.Contains(searchText) && x.Owner.Email == user.Email);
        if (findedTasks.Count != 0)
        {
            CreateTasksTable(findedTasks);
            AnsiConsole.Write(TasksTable);
            AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("<-Back to menu"));
        } else {
            AnsiConsole.MarkupLine("[yellow]No tasks found, sorry :([/]");
            Thread.Sleep(2000);
        }
    }
    public void ShowTasks(bool isCompleted)
    {
        User user = userService.GetLoggedInUser();
        List<Domain.Task> listTasks = taskData.TasksList.FindAll(x => x.Completed == isCompleted && x.Owner.Email == user.Email);
        if (listTasks.Count != 0)
        {
            AnsiConsole.MarkupLine("[green]Your current tasks[/]");
            AnsiConsole.MarkupLine("");
            CreateTasksTable(listTasks);
            AnsiConsole.Write(TasksTable);
            AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("<-Back to menu"));
        } else {
            AnsiConsole.MarkupLine("[yellow]You don't have any active task yet, sorry :([/]");
            Thread.Sleep(2000);
        }
    }
    
    public void CreateTask()
    {
        AnsiConsole.MarkupLine("[green]Creating a task[/]");
        AnsiConsole.MarkupLine("");
        if (AnsiConsole.Confirm("Are you sure you want to create a task?"))
        {
            AnsiConsole.MarkupLine("[yellow]What task do you want to create?[/]");
            AnsiConsole.MarkupLine("");
            string title = AnsiConsole.Ask<string>("Task title:").ToLower();
            string description = AnsiConsole.Ask<string>("Description:").ToLower();
            int priority = AnsiConsole.Ask<int>("Priority:");
            User user = userService.GetLoggedInUser();
            Domain.Task task = new(title, description, priority, user);
            if (taskData.TasksList.Count == 0){
                taskData.AddTask(task);
            } else {
                int num = taskData.TasksList.Last().IdNumber;
                num++;
                task = new(title, description, priority, user, num);
                taskData.AddTask(task);
            }
            AnsiConsole.MarkupLine("[yellow]New tasks added to your task list.[/]");
            AnsiConsole.MarkupLine("Thank you!");
        } else {
            AnsiConsole.MarkupLine("Ok.");
        }
        Thread.Sleep(3000);
    }
    public bool CheckExistingTaskData(string? title)
    {
        existingTaskIndex = 0;
        foreach (var book in taskData.TasksList)
        {
            if (book.Title == title)
            {
                return true;
            }
            existingTaskIndex++;
        }
        return false;
    }
    public bool CheckExistingTaskDataById(int taskId)
    {
        existingTaskIndex = 0;
        foreach (var task in taskData.TasksList)
        {
            if (task.IdNumber == taskId)
            {
                return true;
            }
            existingTaskIndex++;
        }
        return false;
    }
    public void CreateTasksTable(List<Domain.Task> tasksList)
    {
        TasksTable = new ();
        TasksTable.AddColumns("ID", "Title", "Description", "Creation Date", "Is Completed", "Priority Level");
        foreach (Domain.Task task in tasksList)
            {
                TasksTable.AddRow(task.IdNumber.ToString(), task.Title, task.Description, task.CreationDate.ToString(), task.Completed.ToString(), task.Priority.ToString());
            }
    }
    public List<Domain.Task> GetTasksList()
    {
        taskData.GetRegisteredTasks();
        return taskData.TasksList;
    }
}