using System.Text.Json;

namespace PresidentElections;

public class FileManager : IFileManager
{
    private IElectorCounter electorCounter;
    string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "elections.json");
    
    public async Task Read()
    {
        if (File.Exists(filePath))
        {
            using (FileStream voteFile = new FileStream("elections.json", FileMode.OpenOrCreate))
            {
                electorCounter.Candidates = await JsonSerializer.DeserializeAsync<Dictionary<string, int>?>(voteFile);
            }
        }
    }  

    public async Task Write()
    {
        using  (FileStream voteFile = new FileStream("elections.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Dictionary<string, int>>(voteFile, electorCounter.Candidates);
        }
    }

    public FileManager(IElectorCounter electorCounter)
    {
        this.electorCounter = electorCounter;
    }

}


