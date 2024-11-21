using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {

        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }


        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            // fetch the event by ID
           var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(eventToUpdate);
        }
    }
}
