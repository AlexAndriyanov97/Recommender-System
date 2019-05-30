using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recommender_system.Models.Repositories;

namespace Recommender_system.Models
{
    public class UniversityInit
    {
        public UniversityInit(DbContextOptions options)
        {
            EntityEntry<University> result = null;
            var university = new University()
            {
                Id = 0,
                Name = "Nsu",
                Description = "hell",
                City = "Novosibirsk",
                Faculties = new List<Faculty>()
                {
                    new Faculty()
                    {
                       Id = 1,
                       IdUniversity = 0,
                       PassingPoints = new List<PassingPoints>()
                       {
                           new PassingPoints()
                           {
                               Id = 2,
                               IdFaculty = 1,
                               MinPoint = "200"
                           }
                       },
                       Name = "FIT",
                       Tag = "FIT",
                       NumberOfPoints = 200,
                       IsHaveBudgetPlace = true,
                       IsHavePaidPlace = true,
                       IsHaveIntramuralForm = true,
                       IsHaveExtramuralForm = false
                    }
                }
            };
            using (var dbContext = new RecommenderSystemContext(options))
            {
                result = dbContext.Universities.Add(university);
                dbContext.SaveChangesAsync();
            }

        }
        
        
    }
}