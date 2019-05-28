using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recommender_system.Models;
using Recommender_system.Models.Repositories;

namespace RecommenderSystem.Models.Repositories
{
    public class UniversityRepository
    {
        private DbContextOptions _contextOptions;

        public UniversityRepository(DbContextOptions options)
        {
            _contextOptions = options;
        }

        public async Task<University> GetUniversityAsync(int id)
        {
            University university = null;
            using (var recommenderSystemContext = new RecommenderSystemContext(_contextOptions))
            {
                university = await recommenderSystemContext.Universities.FirstOrDefaultAsync(u => u.Id == id);
            }

            return university;
        }

        public async Task<EntityEntry<University>> AddUniversityAsync(University university)
        {
            EntityEntry<University> result = null;
            using (var recommenderSystemContext = new RecommenderSystemContext(_contextOptions))
            {
                result = recommenderSystemContext.Universities.Add(university);
                await recommenderSystemContext.SaveChangesAsync();
            }

            return result;
        }


        public async Task<IEnumerable<University>> GetUniversityAsync()
        {
            var result = new List<University>();

            using (var recommenderSystemContext = new RecommenderSystemContext(_contextOptions))
            {
                result = await recommenderSystemContext.Universities.ToListAsync();
            }

            return result;
        }

        public async Task DeleteUniversityAsync(int id)
        {
            using (var recommenderSystemContext = new RecommenderSystemContext(_contextOptions))
            {
                var university = await recommenderSystemContext.Universities.FirstOrDefaultAsync(u => u.Id == id);
                
                recommenderSystemContext.Entry(university).State = EntityState.Deleted;

                await recommenderSystemContext.SaveChangesAsync();
            }
        }

        public async Task<University> UpdateUniversityAsync(University university)
        {
            using (var recommenderSystemContext = new RecommenderSystemContext(_contextOptions))
            {
                recommenderSystemContext.Entry(university).State = EntityState.Modified;
                
                await recommenderSystemContext.SaveChangesAsync();
            }

            return university;

        }

    }
}