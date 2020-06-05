using BlazorSchools.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Data.Sim
{
    public class SchoolsSimDataService : ISchoolsDataService
    {
        private List<School> _schools = new List<School>();


        public async Task Create(School school)
        {
            _schools.Add(school);
            await Task.Delay(0);
        }


        public async Task Create(Schools schools)
        {
            await DeleteAllSchools();
            foreach (School school in schools.schools)
                await Create(school);
        }


        public async Task<List<School>> GetSchoolsAsync()
        {
            await Task.Delay(0);
            return _schools;
        }



        public async Task<School> GetSchoolAsync(int id)
        {
            return await Task.FromResult(_schools.Where(x => x.id == id).FirstOrDefault());
        }



        public async Task DeleteSchool(int id)
        {
            await Task.Run(() => { _schools.Remove(_schools.Where(x => x.id == id).FirstOrDefault()); });
        }

        public async Task DeleteAllSchools()
        {
            _schools = null;
            _schools = new List<School>();
            await Task.Delay(0);
        }

    }
}
