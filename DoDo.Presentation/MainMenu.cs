using DoDo.Domain;
using DoDo.Service;
using Spectre.Console;

namespace DoDo.Presentation;

public class MainMenu
{
    public bool Exit = false;
    private string? Option;
    private int NumMenu = 1;
    private readonly SelectionPrompt<string> MainPrompt = new SelectionPrompt<string>()
        .Title("MAIN MENU")
        .PageSize(10)
        .AddChoices("- Log in")
        .AddChoices("- Sign Up")
        .AddChoices("- Task Examples")
        .AddChoices("- Exit");
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
                break;
            case 3:
                // AnsiConsole.MarkupLine("[green]ACCOUNT MENU[/]");
                // AnsiConsole.MarkupLine("");
                // AnsiConsole.MarkupLine($"Name: {UserService.LoggedUser.Name}");
                // AnsiConsole.MarkupLine($"Email: {UserService.LoggedUser.Email}");
                // AnsiConsole.MarkupLine($"Registration date: {UserService.LoggedUser.RegistrationDate.ToString().Substring(0, UserService.LoggedUser.RegistrationDate.ToString().Length - 7)}");
                // AnsiConsole.MarkupLine($"Penalty fee: {UserService.LoggedUser.PenaltyFee} $");
                // AnsiConsole.MarkupLine("");
                // Option = AnsiConsole.Prompt(AccountPrompt);
                break;
        }
        ProcessOption(Option);
    }

    private void ProcessOption(string? option)
    {
        switch (option)
        {
            case "- Log in":
                // if (userService.LogIn())
                // {
                //     NumMenu = 2;
                // }
                // Thread.Sleep(2000);
                break;
            case "- Sign Up":
                // borrowingService.userService.SignUp();
                break;
            case "- Task Examples":
                AnsiConsole.MarkupLine("[yellow]TASK EXAMPLES[/]");
                Thread.Sleep(2000);
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
        new FigletText("BookyBook")
            .LeftJustified()
            .Color(Color.Red));
        AnsiConsole.MarkupLine("[red] _____________________________________________________________________[/]");
        AnsiConsole.MarkupLine("[red] _____________________________________________________________________[/]");
        AnsiConsole.MarkupLine("");
    }
}

