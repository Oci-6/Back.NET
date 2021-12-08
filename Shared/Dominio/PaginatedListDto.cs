using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio
{
    public class PaginatedListDto<T>
    {
        public int PageIndex { get; private set; }
        public int Total { get; private set; }
        public List<T> Items { get; set; }
    }
}
