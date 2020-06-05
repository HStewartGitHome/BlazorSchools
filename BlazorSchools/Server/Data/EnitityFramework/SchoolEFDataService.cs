using BlazorSchools.Server.Models;
using BlazorSchools.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Data.EnitityFramework
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

        public async Task Create(School school)
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
            foreach (School school in schools.schools)
            {
                school.id = index++;
                await Create(school);
            }
        }

        public async Task DeleteAllSchools()
        {
            List<School> schools = await GetSchoolsAsync();
            foreach (School school in schools)
                await DeleteSchool(school.id);

        }

        public async Task DeleteSchool(int id)
        {
            await _nonQueryDataService.Delete(id);
        }

        public async Task<School> GetSchoolAsync(int id)
        {
            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                SchoolModel entity = await context.SchoolModels
                    .FirstOrDefaultAsync((e) => e.id == id);
                School school = MakeSchoolFromModel(entity);
                return school;
            }
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
            List<School> schools = new List<School>();

            using (SchoolDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<SchoolModel> entities = await context.SchoolModels
                    .ToListAsync();


                foreach (SchoolModel schoolModel in entities)
                {
                    School school = MakeSchoolFromModel(schoolModel);
                    schools.Add(school);
                }
            }

            return schools.ToList<School>();

        }

        internal School MakeSchoolFromModel(SchoolModel schoolModel)
        {
            School school = new School();
            school.id = schoolModel.id;
            school.name = schoolModel.Name;
            school.street = schoolModel.Street;
            school.city = schoolModel.City;
            school.state = schoolModel.State;
            school.zip = schoolModel.Zip;

            return school;
        }
    }
}
