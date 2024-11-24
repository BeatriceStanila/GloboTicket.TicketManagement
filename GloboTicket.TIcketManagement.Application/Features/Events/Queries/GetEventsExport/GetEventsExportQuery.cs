

using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery: IRequest<EventExportFileVm>
    {
    }
}
