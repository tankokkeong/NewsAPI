using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using NewsAPI;


namespace NewsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SearchResults(string query, int page = 1)
        {
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            var client = new HttpClient();

            var url = "";

            if(query == null || query == "")
            {
                url = "https://newsapi.org/v2/everything?q=Apple&from=" + currentDate + "&page=" + page + "&language=en&pageSize=20&apiKey=Your_API_KEY";
            }
            else
            {
               url = "https://newsapi.org/v2/everything?q=" + query + "&from=" + currentDate + "&page=" + page + "&language=en&pageSize=20&apiKey=Your_API_KEY";
            }

            var response = await client.GetAsync(url);

            return  Json(response.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);

        }


    }
}