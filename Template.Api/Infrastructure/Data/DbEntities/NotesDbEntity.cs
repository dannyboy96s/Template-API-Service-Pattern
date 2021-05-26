using System.ComponentModel.DataAnnotations;
using System;
using Template.Api.Domain.SeedWork;

namespace Template.Api.Infrastructure.Data.DbEntities {
    public class NotesDbEntity : Entity, IAggregateRoot{

        [Key]
        public string NoteId { get; set; }

        public string Message { get; set; }

        public string MessageCreatedDate { get; set; }
    }
}
