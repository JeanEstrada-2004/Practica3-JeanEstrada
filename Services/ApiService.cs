using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Practica3_JeanEstrada.Models;

namespace Practica3_JeanEstrada.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _http.GetFromJsonAsync<List<Post>>("posts");
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _http.GetFromJsonAsync<User>($"users/{userId}");
        }

        public async Task<List<Comment>> GetCommentsAsync(int postId)
        {
            return await _http.GetFromJsonAsync<List<Comment>>($"comments?postId={postId}");
        }
    }
}
