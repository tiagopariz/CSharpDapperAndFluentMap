using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class PersonProjectMap : DommelEntityMap<PersonProject>
    {
        public PersonProjectMap()
        {
            ToTable("PersonProject");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.PersonId).ToColumn("PersonId");
            Map(x => x.Person).Ignore();
            Map(x => x.ProjectId).ToColumn("ProjectId");
            Map(x => x.Project).Ignore();            
        }
    }
}