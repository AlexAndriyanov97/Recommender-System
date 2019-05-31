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

        public ActionResult Index()
        {
            var university =  _universityService.GetUniversityAsync();
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

        public async Task<ActionResult> DeleteUniversity(int id)
        {
            await _universityService.DeleteUniversityAsync(id);
            return View("Index");
        }
    }
}