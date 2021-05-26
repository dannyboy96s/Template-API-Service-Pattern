using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.Domain.SeedWork;

namespace Template.Api.Domain.Aggregates
{
    public interface INotesRepository : ISqlRepository<Notes>
    {
        Task<Notes> AddAsync(Notes note);

        Task<Notes> GetAsync(string id);

        Task<bool> DeleteAsync(string id);

        Task<bool> UpdateAsync(Notes note);

        Task<List<Notes>> GetAllAsync();
        
    } 
}
