using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class PriorityMap : DommelEntityMap<Priority>
    {
        public PriorityMap()
        {
            ToTable("Priority");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.Description).ToColumn("Description");
        }
    }
}