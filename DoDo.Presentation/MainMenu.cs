using DoDo.Domain;
using DoDo.Service;
using Spectre.Console;

namespace DoDo.Presentation;

public class MainMenu
{
    public bool Exit = false;
    public readonly UserService userService = new();
    public readonly TaskService taskService = new();
    private string? Option;
    private int NumMenu = 1;
    private readonly SelectionPrompt<string> MainPrompt = new SelectionPrompt<string>()
        .Title("MAIN MENU")
        .PageSize(10)
        .AddChoices("- Log in")
        .AddChoices("- Sign Up")
        .AddChoices("- Task Examples")
        .AddChoices("- Exit");
    private readonly SelectionPrompt<string> LoggedInPrompt = new SelectionPrompt<string>()
        .PageSize(10)
        .AddChoices("- Search for tasks")
        .AddChoices("- Show current tasks")
        .AddChoices("- Show completed tasks")
        .AddChoices("- Create new task")
        .AddChoices("- Complete a task")
        .AddChoices("- Delete a task")
        .AddChoices("- My user info")
        .AddChoices("- Log Out")
        .AddChoices("- Exit");
    public void InitializeData()
    {
        userService.userData.GetRegisteredUsers();
        taskService.taskData.GetRegisteredTasks();
    }
    public void ShowMenu() 
    {
        AnsiConsole.Clear();
        ShowLogo();
        AnsiConsole.MarkupLine("");

        switch (NumMenu)
        {
            case 1:
                Option = AnsiConsole.Prompt(MainPrompt);
                break;
            case 2:
                LoggedInPrompt.Title($"WELLCOME [bold][green]{UserService.LoggedUser.Name}[/][/]");
                Option = AnsiConsole.Prompt(LoggedInPrompt);
                break;
            case 3:
                AnsiConsole.MarkupLine("[green]USER INFO[/]");
                AnsiConsole.MarkupLine("");
                AnsiConsole.MarkupLine($"Name: {UserService.LoggedUser.Name}");
                AnsiConsole.MarkupLine($"Email: {UserService.LoggedUser.Email}");
                AnsiConsole.MarkupLine($"Registration date: {UserService.LoggedUser.RegistrationDate.ToString().Substring(0, UserService.LoggedUser.RegistrationDate.ToString().Length - 7)}");
                AnsiConsole.MarkupLine("");
                Option = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("<-Back to menu"));
                break;
        }
        ProcessOption(Option);
    }

    private void ProcessOption(string? option)
    {
        switch (option)
        {
            case "- Log in":
                if (userService.LogIn())
                {
                    NumMenu = 2;
                }
                Thread.Sleep(2000);
                break;
            case "- Sign Up":
                userService.SignUp();
                break;
            case "- Task Examples":
                AnsiConsole.MarkupLine("[yellow]TASK EXAMPLES[/]");
                Thread.Sleep(2000);
                break;
            case "- My user info":
                NumMenu = 3;
                break;
            case "- Log Out":
                UserService.LoggedUser = new();
                NumMenu = 1;
                break;
            case "- Search for tasks":
                taskService.SearchForTasks();
                break;
            case "- Show current tasks":
                taskService.ShowTasks(false);
                break;
            case "- Show completed tasks":
                taskService.ShowTasks(true);
                break;
            case "- Create new task":
                taskService.CreateTask();
                break;
            case "- Complete a task":
                break;
            case "- Delete a task":
                break;
            case "<-Back to menu":
                NumMenu = 2;
                break;
            case "- Exit":
                AnsiConsole.MarkupLine("[yellow]EXITING THE APP IN 2 SECONDS[/]");
                Thread.Sleep(2000);
                AnsiConsole.Clear();
                Exit = true;
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option. Try again.[/]");
                Thread.Sleep(3000);
                break;
        }
    }

    public void ShowLogo()
    {
        AnsiConsole.Write(
        new FigletText("DoDo")
            .LeftJustified()
            .Color(Color.Purple));
        AnsiConsole.MarkupLine("[purple] ______________________________[/]");
        AnsiConsole.MarkupLine("[purple] ______________________________[/]");
        AnsiConsole.MarkupLine("");
    }
}

