using System.Text;
using System.Text.Json;
using DeviceManagement.API.Models;

namespace DeviceManagement.API.Services;

public class GeminiAiService : IAiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _model;

    public GeminiAiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Gemini:ApiKey"]!;
        _model = configuration["Gemini:Model"] ?? "gemini-2.5-flash";
    }

    public async Task<string> GenerateDeviceDescriptionAsync(Device device)
    {
        var prompt = $"""
            Write a short product description (2-3 sentences, max 400 characters) for this device
            used in a corporate device management system. Focus on its key features and typical
            use cases. Be concise and professional.

            Device details:
            - Name: {device.Name}
            - Manufacturer: {device.Manufacturer}
            - Type: {device.Type}
            - Operating System: {device.OperatingSystem} {device.OsVersion}
            - Processor: {device.Processor}
            - RAM: {device.RamAmount}

            Return only the description text, no quotes or extra formatting.
            """;

        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
        };

        var url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("x-goog-api-key", _apiKey);
        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Gemini API error ({response.StatusCode}): {responseBody}");
        }

        using var doc = JsonDocument.Parse(responseBody);
        var text = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        return text?.Trim() ?? "No description generated.";
    }
}
