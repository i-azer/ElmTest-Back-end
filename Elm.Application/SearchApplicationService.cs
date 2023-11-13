using Elm.Application.Contracts.Dtos;
using Elm.Application.Contracts.Services;
using Elm.Domain.Shared;
using System.Collections.Generic;

namespace Elm.Application
{
    public class SearchApplicationService : ISearchApplicationService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICacheProvider _cacheProvider;
        public SearchApplicationService(IBookRepository bookRepository, ICacheProvider cacheProvider)
        {
            _bookRepository = bookRepository;
            _cacheProvider = cacheProvider;
        }
        public async Task<IEnumerable<BookDto>> SearchBooks(int offset, int limit, string Slug)
        {
            var cachedRecords = _cacheProvider.Get<IEnumerable<BookDto>>($"{Slug}");
            if (cachedRecords == null)
            {
                if (limit > BookConst.QueryDataSetLimit) limit = BookConst.QueryDataSetLimit;
                var dbRecords = await _bookRepository.GetBooks(offset, limit, Slug);

                if (dbRecords == null|| !dbRecords.Any()) return Enumerable.Empty<BookDto>();

                cachedRecords = (cachedRecords ?? Enumerable.Empty<BookDto>())
                    .Concat(dbRecords.Select(rec => new BookDto
                    {
                        BookId = rec.BookId,
                        BookInfo = rec.BookInfo,
                        LastModified = rec.LastModified
                    }));
                _cacheProvider.Add($"{Slug}", cachedRecords, BookConst.CacheExpiryPeriod);
            }
            return cachedRecords;
        }
    }
}