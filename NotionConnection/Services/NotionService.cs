using System.Text;
using System.Text.Json;
using NotionConnection.Objects;
using Microsoft.Extensions.Configuration;

namespace NotionConnection
{
    public class NotionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _notionApiKey;

        public NotionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _notionApiKey = "secret_MZgmdIavPf000EcxRVD1avM57EpONGAycv2ZOgfA1c2";
        }

        public async Task AddCommentAsync(NotionCommentRequest request)
        {
            var url = "https://api.notion.com/v1/comments";
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_notionApiKey}");
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
    }
}