using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrossCutting.Contract
{
    [JsonObject]
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
        IEnumerable<T> Items { get; }
    }

    [JsonObject]
    public interface IPagedList
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        int FirstItemOnPage { get; }
        int LastItemOnPage { get; }
    }
}