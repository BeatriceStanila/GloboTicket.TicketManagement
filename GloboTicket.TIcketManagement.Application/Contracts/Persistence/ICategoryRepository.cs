using GloboTicket.TicketManagement.Domain.Entities;


namespace GloboTicket.TIcketManagement.Application.Contracts.Persistence
{
    public interface ICategoryRepository: IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
