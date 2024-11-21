
using FluentValidation;
using GloboTicket.TIcketManagement.Application.Contracts.Persistence;
using System.Runtime.CompilerServices;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;


            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.UtcNow);

            // custom validation rule
              // for this have to bring in the eventRepository
            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
            
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
        {
            // add the method into the event repository
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
        }
    }
}
