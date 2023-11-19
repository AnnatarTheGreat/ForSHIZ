namespace PresidentElections;
public class Poll : IPoll
{
    private IElectorCounter electorCounter;
    public Poll(IElectorCounter electorCounter)
    {
        this.electorCounter = electorCounter;
    }

    public string? vote;
    public void Vote()
    {
        Console.Clear();
        Console.WriteLine("Choose one of 3 candidates or propose yours: Putin | Biden | Zelenskiy");
        while (true)
        {
            vote = Console.ReadLine().ToLower();
            if (electorCounter.Candidates.ContainsKey(vote))
            {
                electorCounter.Candidates[vote]++;
            }
            else if (vote == "esc".ToLower())
            {
                break;
            }
            else
            {
                electorCounter.Candidates.Add(vote, 1);
            }
        }
    }
}


