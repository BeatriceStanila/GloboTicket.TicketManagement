using GloboTicket.TicketManagement.Domain.Entities;


namespace GloboTicket.TIcketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository: IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
