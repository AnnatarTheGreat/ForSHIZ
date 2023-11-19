namespace PresidentElections;

public class ElectorCounter : IElectorCounter
{
    private Dictionary<string, int> candidates = new Dictionary<string, int>();
    public Dictionary<string, int> Candidates  
    {
        get
        {
            return candidates;
        }
        set 
        {
          candidates = value;
        }
    }
}


