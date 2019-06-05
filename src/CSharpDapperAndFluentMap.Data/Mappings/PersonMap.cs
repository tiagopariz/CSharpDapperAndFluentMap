using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class PersonMap : DommelEntityMap<Person>
    {
        public PersonMap()
        {
            ToTable("Person");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.Name).ToColumn("Description");
            Map(x => x.Age).ToColumn("Age");
            Map(x => x.CategoryId).ToColumn("CategoryId");
            Map(x => x.Category).Ignore();
            Map(x => x.Projects).Ignore();
        }
    }
}