using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace PresidentElections;
public class Program 
{ 
    public static async Task Main()
    {
        IElectorCounter electorCounter = new ElectorCounter();
        Menu menu = new Menu(electorCounter);
        FileManager fileManager = new FileManager(electorCounter);
        await fileManager.Read();
        menu.Run();
        await fileManager.Write();
    }    
}