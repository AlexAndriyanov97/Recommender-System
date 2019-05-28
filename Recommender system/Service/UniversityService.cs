using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recommender_system.Models;
using RecommenderSystem.Models.Repositories;

namespace Recommender_system.Service
{
    public class UniversityService
    {
        private readonly UniversityRepository _universityRepository;

        public UniversityService(UniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<IEnumerable<University>> GetStudentsAsync()
        {
            return await _universityRepository.GetUniversityAsync();
        }


        public async Task<University> GetStudentAsync(int id)
        {
            return await _universityRepository.GetUniversityAsync(id);
        }

        public async Task<University> UpdateStudentAsync(University university)
        {
            return await _universityRepository.UpdateUniversityAsync(university);
        }

        public async Task<EntityEntry> AddUniversity(University university)
        {
            return await _universityRepository.AddUniversityAsync(university);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _universityRepository.DeleteUniversityAsync(id);
        }
    }
}