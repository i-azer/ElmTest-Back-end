namespace Elm.Application.Contracts.Services
{
    public interface ICacheProvider
    {
        void Add<TItem>(string key, TItem item, TimeSpan timeToLeft);

        TItem Get<TItem>(string key) where TItem : class;
    }
}
