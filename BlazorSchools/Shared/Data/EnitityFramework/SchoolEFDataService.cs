using BlazorSchools.Shared.Data;
using BlazorSchools.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchools.Shared.Data.EnitityFramework
{
    public class SchoolEFDataService : ISchoolsDataService
    {
        private readonly SchoolDBContextFactory _contextFactory = null;
        private readonly NonQueryDataService<SchoolModel> _nonQueryDataService;

        public SchoolEFDataService(SchoolDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<SchoolModel>(contextFactory);
        }

        public async Task Create(SchoolItem school)
        {
            SchoolModel schoolModel = new SchoolModel();
            if (school.name == null)
                schoolModel.Name = "";
            else
                schoolModel.Name = school.name;
            if (school.street == null)
                schoolModel.Street = "";
            else
                schoolModel.Street = school.street;
            if (school.city == null)
                schoolModel.City = "";
            else
                schoolModel.City = school.city;
            if (school.state == null)
                schoolModel.State = "";
            else
                schoolModel.State = school.state;
            if (school.zip == null)
                schoolModel.Zip = "";
            else
                schoolModel.Zip = school.zip;

            await _nonQueryDataService.Create(schoolModel);
        }


        public async Task Create(Schools schools)
        {
            int index = 11000;
            await DeleteAllSchools();
            foreach (SchoolItem school in schools.schools)
            {
                school.Id = index++;
                await Create(school);
            }
        }

        public async Task DeleteAllSchools()
        {
            List<SchoolItem> schools = await GetSchoolsAsync();
            foreach (SchoolItem school in schools)
                await DeleteSchool(school.Id);

        }

        public async Task DeleteSchool(int id)
        {
            await _nonQueryDataService.Delete(id);
        }

        public async Task<SchoolItem> GetSchoolAsync(int id)
        {
            using SchoolDBContext context = _contextFactory.CreateDbContext();
            SchoolModel entity = await context.SchoolModels
                .FirstOrDefaultAsync((e) => e.Id == id);
            SchoolItem school = MakeSchoolFromModel(entity);
            return school;
        }

        public async Task<List<SchoolItem>> GetSchoolsAsync()
        {
            List<SchoolItem> schools = new List<SchoolItem>();

            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<SchoolModel> entities = await context.SchoolModels
                    .ToListAsync();


                foreach (SchoolModel schoolModel in entities)
                {
                    SchoolItem school = MakeSchoolFromModel(schoolModel);
                    schools.Add(school);
                }
            }

            return schools.ToList<SchoolItem>();

        }

        internal static SchoolItem MakeSchoolFromModel(SchoolModel schoolModel)
        {
            SchoolItem school = new SchoolItem
            {
                Id = schoolModel.Id,
                name = schoolModel.Name,
                street = schoolModel.Street,
                city = schoolModel.City,
                state = schoolModel.State,
                zip = schoolModel.Zip
            };

            return school;
        }
    }
}
