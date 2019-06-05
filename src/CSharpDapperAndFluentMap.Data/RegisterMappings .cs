using CSharpDapperAndFluentMap.Data.Mappings;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
 
namespace CSharpDapperAndFluentMap.Data
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CategoryMap());
                config.AddMap(new PersonMap());
                config.AddMap(new ProjectMap());
                config.AddMap(new PersonProjectMap());
                config.AddMap(new PriorityMap());
                config.AddMap(new TicketMap());
                config.ForDommel();
            });
        }
    }
}