using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class FoxService
{
    HttpClient httpClient;
    public FoxService()
    {
        this.httpClient = new HttpClient();
    }

    List<Fox> foxList;
    public async Task<List<Fox>> GetFoxes()
    {
        if (foxList?.Count > 0)
            return foxList;

        using var stream = await FileSystem.OpenAppPackageFileAsync("foxes.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        foxList = JsonSerializer.Deserialize<List<Fox>>(contents);

        return foxList;
    }
}
