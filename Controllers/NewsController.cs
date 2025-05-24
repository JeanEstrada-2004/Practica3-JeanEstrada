using Microsoft.AspNetCore.Mvc;
using Practica3_JeanEstrada.Services;
using System.Threading.Tasks;

namespace Practica3_JeanEstrada.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApiService _apiService;

        public NewsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _apiService.GetPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _apiService.GetPostsAsync();
            var singlePost = post.FirstOrDefault(p => p.Id == id);
            if (singlePost == null) return NotFound();

            var author = await _apiService.GetUserAsync(singlePost.UserId);
            var comments = await _apiService.GetCommentsAsync(id);

            ViewBag.Author = author;
            ViewBag.Comments = comments;

            return View(singlePost);
        }
    }
}
