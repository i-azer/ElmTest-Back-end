using Elm.Domain;

namespace Elm.Application.Contracts.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks(int offset, int limit,string slug);
    }
}
