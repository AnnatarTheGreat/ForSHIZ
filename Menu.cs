namespace PresidentElections;
public class Menu : IMenu
{
    private IElectorCounter electorCounter;
    public Menu(IElectorCounter electorCounter)
    {
        this.electorCounter = electorCounter;
    }
    public bool IsVisible {get; set;}

    public bool ShowMenu()
    {
        IPoll poll = new Poll(electorCounter);
        Console.Clear();
        Console.WriteLine("Choose an option");
        Console.WriteLine ("1) Take part in the elections");
        Console.WriteLine("2) Check results");
        Console.WriteLine("3) Leave");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                poll.Vote();
                return true;
            case "2":
                ShowResults();
                return true;
            case "3":
                return false;
            default:
                Console.WriteLine("Choose one of 3 options");
                return true;
        }
    }

    public void Run()
    {
        IsVisible = true;
        while (IsVisible)
        {
            IsVisible = ShowMenu();
        }
    }

    public void ShowResults()
    {
        Console.Clear();
        Console.WriteLine("Current results of voting are");
        foreach (var candidate in electorCounter.Candidates)
        {
            int votesCount = candidate.Value;
            string candidateName = candidate.Key;
            Console.WriteLine(candidateName + " " + votesCount);
        }
        Console.WriteLine("\n \n Press enter to return to main");
        Console.ReadLine();
    }
}


