using System;
using System.Threading.Tasks;
using Template.Api.Domain.Aggregates;
using Template.Api.Domain.SeedWork;
using Template.Api.Infrastructure.Data.DbEntities;
using System.Collections.Generic;
using AutoMapper;


namespace Template.Api.Infrastructure.Data {
    public class NotesRepository : INotesRepository {

        private readonly NotesDbContext _ctx;
        private readonly IMapper _mapper;

        public IUnitOfWork UnitOfWork => _ctx;

        public NotesRepository(NotesDbContext ctx, IMapper mapper)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<Notes> AddAsync(Notes note) {
            var result = note;
            var dbEntity = _mapper.Map<NotesDbEntity>(note);
            _ctx.NotesEntity.Add(dbEntity);
            result = _mapper.Map<Notes>(dbEntity);
            //
            return Task.FromResult(result);
        }

        public Task<Notes> GetAsync(string id) {
            var result = default(Notes);
            var dbEntity = _ctx.NotesEntity.Find(id);
            result = _mapper.Map<Notes>(dbEntity);
            //
            return Task.FromResult(result);
        }

        public async Task<bool> DeleteAsync(string id) {
            var result = false;
            var dbEntity = _ctx.NotesEntity.Find(id);
            if(dbEntity != null) {
                _ctx.NotesEntity.Remove(dbEntity);
                await _ctx.SaveChangesAsync();
                result = true;
            }
            //
            return result;
        }

        public async Task<bool> UpdateAsync(Notes note) {
            var result = false;
            var dbEntity = _ctx.NotesEntity.Find(note.NoteId);
            if(dbEntity == null) 
                return result;
            //
            _ctx.NotesEntity.Update(_mapper.Map<NotesDbEntity>(note));
            await _ctx.SaveChangesAsync();
            result = true;
            //
            return result;
        }

        public Task<List<Notes>> GetAllAsync() {
           var result = new List<Notes>();
           // get all the items in the inmem db
           var items = _ctx.NotesEntity;
           // add each item to the result list
           foreach(var i in items) result.Add(_mapper.Map<Notes>(i));
           //
           return Task.FromResult(result);
        }

    }
}
