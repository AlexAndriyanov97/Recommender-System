using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recommender_system.Models.Repositories;
using Recommender_system.Models.Repository;

namespace Recommender_system.Controllers
{
    public class UniversityController : Controller
    {
        private readonly RecommenderSystemContextRepository _universityService;

        public UniversityController(RecommenderSystemContextRepository universityService)
        {
            _universityService = universityService;
        }

        public async Task<ActionResult> Index()
        {
            var university = await _universityService.GetUniversityAsync();
            return View(university);
        }

        public ActionResult AddUniversity()
        {
            return View();
        }

        public ActionResult EditUniversity()
        {
            return View();
        }

        public ActionResult DeleteUniversity()
        {
            return View();
        }
    }
}