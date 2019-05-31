using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Recommender_system.Models;
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
            var university = _universityService.GetUniversityAsync();
            return View(university);
        }

        public async Task<ActionResult> AddUniversity(string name, string description, string city,
            IEnumerable<Faculty> faculties)
        {
            var university = new University()
            {
                Name = name,
                Description = description,
                City = city,
                Faculties = new List<Faculty>(faculties)
            };
            if (_universityService != null)
            {
                await _universityService.AddUniversityAsync(university);
            }

            return View("Index", _universityService.GetUniversityAsync());
        }

        public async Task<ActionResult> EditUniversity(University newUniversity)
        {
            await _universityService.UpdateUniversityAsync(newUniversity);

            return View("Index", _universityService.GetUniversityAsync());
        }

        public async Task<ActionResult> DeleteUniversity(int id)
        {
            await _universityService.DeleteUniversityAsync(id);
            return View("Index", _universityService.GetUniversityAsync());
        }

        public ActionResult FindUniversity(TypeOfSubject typeOfFirstSubject,
            TypeOfSubject typeOfSecondSubject, TypeOfSubject typeOfThirdSubject, int numberOfFirstSubject,
            int numberOfSecondSubject, int numberOfThirdSubject)
        {
            var faculties = _universityService.FindUniversity(typeOfFirstSubject, typeOfSecondSubject, typeOfThirdSubject,
                numberOfFirstSubject, numberOfSecondSubject, numberOfThirdSubject);

            var universities = new List<University>();
            foreach (var faculty in faculties)
            {
                universities.Add(faculty.University);
            }
            return View("Index",universities);
        }
    }
}