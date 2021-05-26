using System;

namespace Template.Api.Domain.SeedWork
{
    // Base sql repository interface
    public interface ISqlRepository<T> where T: IAggregateRoot {

        IUnitOfWork UnitOfWork {get;}
    }
}

       