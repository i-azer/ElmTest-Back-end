using Elm.Application.Contracts.Dtos;

namespace Elm.Application.Contracts.Services
{
    public interface ISearchApplicationService
    {
        Task<IEnumerable<BookDto>> SearchBooks(int offset,int limit, string Slug);
    }
}
