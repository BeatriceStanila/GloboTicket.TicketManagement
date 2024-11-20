
using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            // use the eventRepository to access the ListAllAsync method from the IAsyncRepository (the base interface) via IEventRepository
            // get all the event ordered by date
            // this gives back a list of entities and IOrderedEnumerable of Events (domain entities)
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);

            // don't want to return entities to my clients 
            // want to return objects that I'm in control of so that they only contain the property I want to return
            // these are available on EventListVm
            // automapper needs more information to actually works -> needs a profile
            return _mapper.Map<List<EventListVm>>(allEvents);


        }
    }
}
