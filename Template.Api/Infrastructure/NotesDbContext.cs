using Microsoft.EntityFrameworkCore;
using Template.Api.Infrastructure.Data.DbEntities;
using Template.Api.Domain.SeedWork;
using System;

namespace Template.Api.Infrastructure.Data {
    public class NotesDbContext : DbContext, IUnitOfWork {

        public NotesDbContext(DbContextOptions<NotesDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<NotesDbEntity> NotesEntity { get; set; }
    }
}
        