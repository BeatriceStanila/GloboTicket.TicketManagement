using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Features.Categories.Commands;
using GloboTicket.TIcketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TIcketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TIcketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TIcketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TIcketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TIcketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TIcketManagement.Application.Features.Events.Queries.GetEventsList;


namespace GloboTicket.TIcketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();


            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

        }
    }
}
