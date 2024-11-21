using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TIcketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TIcketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
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
        }
    }
}
