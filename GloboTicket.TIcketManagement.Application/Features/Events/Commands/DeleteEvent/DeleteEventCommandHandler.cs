using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using MediatR;


namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public  class DeleteEventCommandHandler: IRequestHandler<DeleteEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            await _eventRepository.DeleteAsync(eventToDelete);
        }
    }
}
