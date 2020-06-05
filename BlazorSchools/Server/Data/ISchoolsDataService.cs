using BlazorSchools.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Data
{
    public interface ISchoolsDataService
    {
        Task Create(School school);
        Task Create(Schools schools);
        Task<List<School>> GetSchoolsAsync();
        Task<School> GetSchoolAsync(int id);
        Task DeleteSchool(int id);
        Task DeleteAllSchools();
    }
}