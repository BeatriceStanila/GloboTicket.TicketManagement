

using MediatR;

namespace GloboTicket.TIcketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQuery: IRequest<List<CategoryListVm>>
    {
        // has no parameters -> will return a list of all categories
    }
}
