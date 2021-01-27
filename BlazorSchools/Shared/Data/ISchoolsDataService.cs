using BlazorSchools.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSchools.Shared.Data
{
    public interface ISchoolsDataService
    {
        Task Create(SchoolItem school);

        Task Create(Schools schools);

        Task<List<SchoolItem>> GetSchoolsAsync();

        Task<SchoolItem> GetSchoolAsync(int id);

        Task DeleteSchool(int id);

        Task DeleteAllSchools();
    }
}