
using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using MediatR;



namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // map from a CreateEventCommand into an event
           var @event = _mapper.Map<Event>(request);

            // instatiate the create event validator
            var valdiator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await valdiator.ValidateAsync(request); // this will trigger the validation rules

            // if there are any validation -> throw an custom exception
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);


                @event = await _eventRepository.AddAsync(@event);

            return @event.EventId;
        }
    }
}
