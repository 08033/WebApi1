using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsUpdateController : Controller
    {
        private readonly ILogger<NewsUpdateController> _logger;
        private readonly IStringLocalizer<NewsUpdateController> _stringLocalizer; 

        public NewsUpdateController(ILogger<NewsUpdateController> logger, IStringLocalizer<NewsUpdateController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet("GetT",Name = "GetT")]   
        public NewsUpdate GetTitle()
        {
            var n = new NewsUpdate
            {
                Id = 3,
                Headline = _stringLocalizer["headline"],
                Detail = _stringLocalizer["detail"]
            };            
            return n;
        }

        /* public IActionResult Index()
         {
             return View();
         }*/

        [HttpGet(Name = "GetNewsUpdate")]
         public IEnumerable<NewsUpdate> Get()
         {
             var news1 = new NewsUpdate
             {
                 Id = 1,
                 Headline = "Pakistan gets 23rd Prime Minister",
                 Detail = "After the no-confidence voting against Imran Khan, the members elected new prime minister in Shahbaz Sharif as the countrys' 23 premier"
             };

             var news2 = new NewsUpdate { 
                 Id = 2, 
                 Headline = "Liverpool draw against City", 
                 Detail = "In a crunch match over the weekend Liverpool draw 2-2 against title contenders Manchester City" 
             };

             NewsUpdate[] ls = new[] { news1, news2 };            
             return ls;
         }         
    }
}
