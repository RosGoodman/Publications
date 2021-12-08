
using System.ComponentModel.DataAnnotations;

namespace Publications.Domain.Entityes
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
