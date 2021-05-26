using System;
using Template.Api.Domain.SeedWork;

namespace Template.Api.Domain.Aggregates
{
    public class Notes : Entity, IAggregateRoot {

        public Notes()
            => Id = Guid.NewGuid();
        
        public string NoteId {get; set;}
        
        public string Message { get; set; }

        public DateTime MessageCreatedDate { get; set; }
    }
}
