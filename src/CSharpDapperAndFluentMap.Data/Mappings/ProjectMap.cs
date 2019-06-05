using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class ProjectMap : DommelEntityMap<Project>
    {
        public ProjectMap()
        {
            ToTable("Project");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.Name).ToColumn("Name");
        }
    }
}