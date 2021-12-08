

using Microsoft.EntityFrameworkCore;
using Publications.Domain.Entityes;

namespace Publications.DAL.Context;

public class PublicationsDB : DbContext
{
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Person> Persons { get; set; }

    public PublicationsDB(DbContextOptions<PublicationsDB> options)
        : base(options)
    {
    }
}
