using System;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class PersonProject : Entity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}