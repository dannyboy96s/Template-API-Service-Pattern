using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.Domain.Aggregates;

namespace Template.Api.App.Service {
    public class NotesService : INotesService {

        private readonly INotesRepository _repo;
        // add mapper to map request with model

        public NotesService(INotesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<Notes> CreateNotesAsync(Notes request) {
            var result = _repo.AddAsync(request);
            _repo.UnitOfWork.SaveChangesAsync();
            //
            return result;
        }
        public Task<Notes> GetNoteAsync(string id) {
            var entity = _repo.GetAsync(id);
            if(entity == null)
                throw new Exception($"Note with Id: {id}, not found!");
            //
            return entity;
        }

        public async Task<List<Notes>> GetAllAsync() {
            var result = await _repo.GetAllAsync();
            //
            return result;
        }

        public async Task<bool> UpdateNoteAsync(Notes request) {
            var result =  await _repo.UpdateAsync(request);
            if(result == false)  
                throw new Exception($"Could not update note with id {request.NoteId}");
            //
            return result;
        }

        public async Task<bool> DeleteNoteAsync(string id) {
            var result = await _repo.DeleteAsync(id);
             if(result == false)  
                throw new Exception($"Could not delete note with id {id}");
            //
            return result;

        }
    
    }

}
