using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Recommender_system.Models.Repositories;

namespace Recommender_system.Models.Repository
{
    public class RecommenderSystemContextRepository
    {
        private DbContextOptions _options;

        public RecommenderSystemContextRepository(DbContextOptions options)
        {
            _options = options;
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


        public IEnumerable<University> GetUniversityAsync()
        {
            var result = new List<University>();
            using (var dbContext = new RecommenderSystemContext(_options))
            {
                result = dbContext.Universities.ToList();
                foreach (var university in result)
                {
                    foreach (var faculty in dbContext.Faculties)
                    {
                        if (faculty.IdUniversity == university.Id)
                        {
                            university.Faculties.Add(faculty);
                        }

                        foreach (var passingPoint in dbContext.PassingPoints)
                        {
                            if (passingPoint.IdFaculty == faculty.Id)
                            {
                                faculty.PassingPoints.Add(passingPoint);
                            }
                        }
                    }
                }

                dbContext.SaveChanges();
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

        public List<Faculty> FindUniversity(TypeOfSubject typeOfFirstSubject,
            TypeOfSubject typeOfSecondSubject, TypeOfSubject typeOfThirdSubject, int numberOfFirstSubject,
            int numberOfSecondSubject, int numberOfThirdSubject)
        {
            var result = new List<Faculty>();

            using (var dbContext = new RecommenderSystemContext(_options))
            {
                var universities = dbContext.Universities;
                foreach (var university in universities)
                {
                    foreach (var faculty in university.Faculties)
                    {
                        if (faculty.PassingPoints.Any(x => x.TypeOfSubject == typeOfFirstSubject) &&
                            faculty.PassingPoints.Any(x => x.TypeOfSubject == typeOfSecondSubject) &&
                            faculty.PassingPoints.Any(x => x.TypeOfSubject == typeOfThirdSubject))
                        {
                            if (faculty.PassingPoints.FirstOrDefault(x => x.TypeOfSubject == typeOfFirstSubject)
                                    .MinPoint <= numberOfFirstSubject &&
                                faculty.PassingPoints.FirstOrDefault(x => x.TypeOfSubject == typeOfSecondSubject)
                                    .MinPoint <= numberOfSecondSubject &&
                                faculty.PassingPoints.FirstOrDefault(x => x.TypeOfSubject == typeOfThirdSubject)
                                    .MinPoint <= numberOfThirdSubject)
                            {
                                result.Add(faculty);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}