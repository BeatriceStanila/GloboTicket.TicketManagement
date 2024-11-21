

using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest
    {
        public Guid EventId { get; set; }

    }
}
