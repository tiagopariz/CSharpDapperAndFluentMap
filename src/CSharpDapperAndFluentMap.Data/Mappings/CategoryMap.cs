using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class CategoryMap : DommelEntityMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.Description).ToColumn("Description");
        }
    }
}