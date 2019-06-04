using System;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class Priority : Entity
    {
        // public Priority(Guid Id,
        //                 string descripion) 
        //     : base(Id)
        // {
        //     Description = descripion;
        // }

        public string Description { get; set; }
    }
}