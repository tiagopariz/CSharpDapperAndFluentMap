using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
 
namespace CSharpDapperAndFluentMap.Data.Mappings
{
    public class TicketMap : DommelEntityMap<Ticket>
    {
        public TicketMap()
        {
            ToTable("Ticket");
            Map(x => x.Id).ToColumn("Id").IsKey();           
            Map(x => x.Description).ToColumn("Description");
            Map(x => x.PriorityId).ToColumn("PriorityId");
            Map(x => x.Priority).Ignore();            
            Map(x => x.PersonId).ToColumn("PersonId");
            Map(x => x.Person).Ignore();
            
        }
    }
}