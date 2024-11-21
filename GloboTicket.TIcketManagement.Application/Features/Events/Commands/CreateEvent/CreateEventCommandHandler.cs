
using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using GloboTicket.TIcketManagement.Application.Models.Mail;
using MediatR;



namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
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

            // send email notification to admin address
            var email = new Email()
            {
                To = "admin@hotmail.com",
                Body = $"A new event was created: {request}",
                Subject = $"A new event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // this shouldn't stop the API from doing else so this can be logged
            }


            return @event.EventId;
        }
    }
}
