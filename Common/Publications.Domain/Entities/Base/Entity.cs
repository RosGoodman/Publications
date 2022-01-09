
using Publications.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace Publications.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
