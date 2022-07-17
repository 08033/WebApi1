using Microsoft.AspNetCore.Mvc;

using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly FamilyTreeService _familyTreeService;

        public MemberController(FamilyTreeService familyTreeService) =>
            _familyTreeService = familyTreeService;


        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<List<Member>> Get() => await _familyTreeService.GetAsync();

        [HttpPost]

        public async Task<IActionResult> Post(Member member)
        {
            await _familyTreeService.CreateAsync(member);
            return CreatedAtAction(nameof(Post), new { id = member.Id }, member);
        }
    }
}
