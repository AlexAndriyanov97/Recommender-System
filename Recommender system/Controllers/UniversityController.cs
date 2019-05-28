using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recommender_system.Service;
using RecommenderSystem.Models.Repositories;

namespace Recommender_system.Controllers
{
    public class UniversityController:Controller
    {
        private readonly UniversityService _universityService;

        public UniversityController(UniversityService universityService)
        {
            _universityService = universityService;
        }

        public async Task<ActionResult> Index()
        {
            var university = await _universityService.GetStudentsAsync();
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