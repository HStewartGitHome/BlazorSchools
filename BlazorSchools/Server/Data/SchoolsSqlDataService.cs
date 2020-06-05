
using BlazorSchools.Server.DataAccess;
using BlazorSchools.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Data
{
    public class SchoolsSqlDataService : ISchoolsDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public SchoolsSqlDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task Create(School school)
        {
            var p = new
            {
                school.name,
                school.street,
                school.city,
                school.state,
                school.zip
            };

            await _dataAccess.SaveData("dbo.spSchools_Create", p, "SQLDB");
        }


        public async Task Create(Schools schools)
        {
            await DeleteAllSchools();
            foreach (School school in schools.schools)
                await Create(school);
        }


        public async Task<List<School>> GetSchoolsAsync()
        {
            var schools = await _dataAccess.LoadData<School, dynamic>("dbo.spSchools_Get",
                                                                              new { },
                                                                              "SQLDB");
            return schools.ToList<School>();
        }



        public async Task<School> GetSchoolAsync(int id)
        {
            var schools = await _dataAccess.LoadData<School, dynamic>("dbo.spSchools_GetOne",
                                                                              new { Id = id },
                                                                              "SQLDB");
            return schools.FirstOrDefault();
        }



        public async Task DeleteSchool(int id)
        {
            await _dataAccess.SaveData("dbo.spSchools_Delete", new { Id = id }, "SQLDB");
        }

        public async Task DeleteAllSchools()
        {
            await _dataAccess.SaveData("dbo.spSchools_DeleteAll", new { }, "SQLDB");
        }

    }
}
