

namespace Publications.Domain.Entities
{
    public class Publication : NamedEntity
    {
        public DateTime Date { get; set; }

        public ICollection<Person> Authors { get; set; } = new HashSet<Person>();
    }

    public class Person : NamedEntity
    {
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}
