using System.Collections.Generic;

namespace GaleriaDavinci.Web.Models
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int PageCount { get; set; }

        public PaginatedResult(IEnumerable<T> result, int page, int size, int pageCount)
        {
            Result = result;
            Page = page;
            Size = size;
            PageCount = pageCount;
        }
    }
}
