

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Publications.Domain.Entityes;
using Publications.Domain.Entityes.Identity;

namespace Publications.DAL.Context;

public class PublicationsDB : IdentityDbContext<User, Role, string>
{
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Person> Persons { get; set; }

    public PublicationsDB(DbContextOptions<PublicationsDB> options)
        : base(options)
    {
    }
}
