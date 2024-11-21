

using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand: IRequest<Guid> // the return type is the ID of the event created
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date {  get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToLongDateString()}; Description: {Description}";
        }
    }
}
