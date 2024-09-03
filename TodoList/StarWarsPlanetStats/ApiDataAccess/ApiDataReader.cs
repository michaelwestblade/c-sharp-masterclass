namespace StarWarsPlanetsStats.ApiDataAccess;

public class ApiDataReader: IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = client.GetAsync(requestUri).Result;
        response.EnsureSuccessStatusCode();
        
        string json = await response.Content.ReadAsStringAsync();

        return json;
    }
}