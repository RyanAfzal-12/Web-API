using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dbcon db = new Dbcon();
        public async Task<ActionResult> Index()
        {
            string api = "https://jsonplaceholder.typicode.com/posts";
            List<Post> posts = new List<Post>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        JArray jsonArray = JArray.Parse(jsonData);
                        posts = jsonArray.Select(item => new Post
                        {
                            Id = (int)item["id"],
                            Title = (string)item["title"],
                            Body = (string)item["body"],
                            UserId = (int)item["userId"]

                        }).ToList();

                        foreach (var post in posts)
                        {
                            if (!db.Posts.Any(p => p.Id == post.Id))
                            {
                                db.Posts.Add(post);
                            }
                        }

                        await db.SaveChangesAsync();
                    }
                }

                catch (Exception ex)
                {
                    ViewBag.Error = $"Error : {ex.Message}";

                }
            }
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}