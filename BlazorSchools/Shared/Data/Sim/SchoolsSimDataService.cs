using BlazorSchools.Shared.Data;
using BlazorSchools.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchools.Shared.Data.Sim
{
    public class SchoolsSimDataService : ISchoolsDataService
    {
        private List<SchoolItem> _schools = new List<SchoolItem>();

        public async Task Create(SchoolItem school)
        {
            _schools.Add(school);
            await Task.Delay(0);
        }

        public async Task Create(Schools schools)
        {
            await DeleteAllSchools();
            foreach (SchoolItem school in schools.schools)
                await Create(school);
        }

        public async Task<List<SchoolItem>> GetSchoolsAsync()
        {
            await Task.Delay(0);
            return _schools;
        }

        public async Task<SchoolItem> GetSchoolAsync(int id)
        {
            return await Task.FromResult(_schools.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task DeleteSchool(int id)
        {
            await Task.Run(() => { _schools.Remove(_schools.Where(x => x.Id == id).FirstOrDefault()); });
        }

        public async Task DeleteAllSchools()
        {
            _schools = null;
            _schools = new List<SchoolItem>();
            await Task.Delay(0);
        }
    }
}