

namespace Publications.Domain.Entityes
{
    public class Publication : NamedEntity
    {
        public DateTime Date { get; set; }

        public ICollection<Person> Authors { get; set; } = new HashSet<Person>();
    }

    public class Person : NamedEntity
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}
