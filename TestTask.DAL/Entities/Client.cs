
using TestTask.DAL.Entities.Base;

namespace TestTask.DAL.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
