using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.Domain.Aggregates;

namespace Template.Api.App.Service {
    public interface INotesService {

        Task<Notes> CreateNotesAsync(Notes request);
        Task<Notes> GetNoteAsync(string id);
        Task<List<Notes>> GetAllAsync();
        Task<bool> UpdateNoteAsync(Notes request);
        Task<bool> DeleteNoteAsync(string id);
    
    }

}
