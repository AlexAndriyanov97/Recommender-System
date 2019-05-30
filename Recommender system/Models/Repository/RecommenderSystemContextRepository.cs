using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recommender_system.Models.Repositories;

namespace Recommender_system.Models.Repository
{
    public class RecommenderSystemContextRepository
    {
        private DbContextOptions _options;

        public RecommenderSystemContextRepository(DbContextOptions options)
        {
            _options = options;
            /*

            var university = new University()
            {
                Name = "Nsu",
                Description = "hell",
                City = "Novosibirsk",
            };
            var faculty = new Faculty()
            {
                IdUniversity = university.Id,
                University = university,
                Name = "FIT",
                Tag = "FIT",
                NumberOfPoints = 200,
                IsHaveBudgetPlace = true,
                IsHavePaidPlace = true,
                IsHaveIntramuralForm = true,
                IsHaveExtramuralForm = false
            };
            var passingPoint = new PassingPoints()
            {
                Faculty = faculty,
                IdFaculty = faculty.Id,
                MinPoint = "200"
            };


            using (var dbContext = new RecommenderSystemContext(options))
            {
                dbContext.Universities.Add(university);
                dbContext.Faculties.Add(faculty);
                dbContext.PassingPoints.Add(passingPoint);

                dbContext.SaveChanges();

            }*/
        }


        public async Task<University> GetUniversityAsync(int id)
        {
            University university = null;
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                university = await dbContext.Universities.FirstOrDefaultAsync(u => u.Id == id);
            }

            return university;
        }

        public async Task<EntityEntry<University>> AddUniversityAsync(University university)
        {
            EntityEntry<University> result = null;
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                result = dbContext.Universities.Add(university);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }


        public async Task<IEnumerable<University>> GetUniversityAsync()
        {
            var result = new List<University>();
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                result = dbContext.Universities.ToList();
            }

            return result;
        }

        public async Task DeleteUniversityAsync(int id)
        {
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                var university = await dbContext.Universities.FirstOrDefaultAsync(u => u.Id == id);

                dbContext.Entry(university).State = EntityState.Deleted;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<University> UpdateUniversityAsync(University university)
        {
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                dbContext.Entry(university).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();
            }

            return university;
        }
    }
}