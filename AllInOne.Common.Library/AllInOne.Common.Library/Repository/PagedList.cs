using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOne.Common.Library.Repository
{
    public interface IPagedList
    {
        long TotalCount { get; set; }
        int TotalPages { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int FirstItem { get; }
        int LastItem { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    [Serializable]
    public class PagedList<T> : IPagedList
    {
        public List<T> Items { get; private set; }
        public int TotalPages { get; set; }
        public long TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PagedList()
        {
            Items = new List<T>();
        }

        public PagedList(IEnumerable<T> source, long totalCount, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            TotalPages = (int)(TotalCount / pageSize);

            if (TotalCount % pageSize > 0)
                TotalPages++;

            Items = new List<T>(source);
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get
            {

                return (PageIndex < (TotalPages - 1));

            }
        }

        public int FirstItem
        {
            get
            {
                return (PageIndex * PageSize) + 1;
            }
        }

        public int LastItem
        {
            get
            {
                return (FirstItem + PageSize - 1);
            }
        }
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int totalCount, int pageIndex, int pageSize)
        {
            return new PagedList<T>(source, totalCount, pageIndex, pageSize);
        }
    }
}
