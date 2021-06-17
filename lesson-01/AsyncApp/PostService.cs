using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncApp
{
    public static class PostService
    {
        private const string _getPostRequestUri = "https://jsonplaceholder.typicode.com/posts/";
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<Post> GetPost(int id)
        {
            try
            {
                var response = await _client.GetAsync($"{_getPostRequestUri}{id}");
                var result = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var post = JsonSerializer.Deserialize<Post>(result, options);
                return post;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<List<Post>> GetPosts(params int[] ids)
        {
            var tasks = ids.Select(id => GetPost(id)).ToArray();

            await Task.WhenAll(tasks);

            var posts = tasks
                .Select(t => t.Result)
                .Where(p => p != null)
                .Where(p => p.Id > 0)
                .ToList();

            return posts;
        }
    }
}
