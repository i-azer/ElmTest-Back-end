namespace Elm.Domain.Shared
{
    public static class BookConst
    {
        public readonly static int QueryDataSetLimit = 10;
        public readonly static string CacheKeyPrefix = "Elm.Cache.";
        public readonly static TimeSpan CacheExpiryPeriod = TimeSpan.FromMinutes(5);
    }
}