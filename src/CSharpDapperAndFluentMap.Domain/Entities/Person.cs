using System;
using System.Collections.Generic;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}