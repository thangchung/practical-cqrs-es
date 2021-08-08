using System;
using Marten.Pagination;

namespace N8T.Infrastructure.Marten
{
    public static class PagedListExtensions
    {
        public static PagedListResponse<T> ToResponse<T>(this IPagedList<T> pagedList)
        {
            if (pagedList == null) throw new ArgumentNullException(nameof(pagedList));

            return new PagedListResponse<T>(pagedList, pagedList.TotalItemCount, pagedList.HasNextPage);
        }
    }
}
