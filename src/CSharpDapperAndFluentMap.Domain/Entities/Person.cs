using System;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class Person : Entity
    {
        // public Person(Guid Id,
        //               string name,
        //               int age,
        //               Guid categoryId,
        //               Category category) 
        //     : base(Id) 
        // {
        //     Name = name;
        //     Age = age;
        //     CategoryId = categoryId;
        //     Category = category;
        // }

        public string Name { get; set; }
        public int Age { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}