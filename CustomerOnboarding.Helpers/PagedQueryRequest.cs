using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Helpers
{
    public class PagedQueryRequest
    {
        public static readonly int DefaultPageSize = 20;
        public static readonly int DefaultPageNumber = 1;
        public static readonly int MaxPageSize = 100;
        /// <summary>
        /// The page number for the paginated results.  Default is 1.
        /// Setting a number beyond the last page will just return the last page of data.
        /// </summary>
        public int PageNumber { get; set; } = DefaultPageNumber;

        private int _pageSize = DefaultPageSize;
        /// <summary>
        /// The number of items returned for the page. A maximum size of 100 is set.  Default is 20.
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = Math.Min(value, MaxPageSize); }
        }

    }

    //public class DateSearch
    //{
    //    DateTime Start { get; set; }
    //    DateTime End { get; set; }
    //}


}
