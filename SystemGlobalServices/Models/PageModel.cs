using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemGlobalServices.Model
{
    public class PageModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public void UpdateData(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
        public void NextPage() => PageNumber++;
        public void PreviousPage() => PageNumber--;

        public void UpdatePage(int page)
        {
            this.PageNumber = page;
        }
    }
}
