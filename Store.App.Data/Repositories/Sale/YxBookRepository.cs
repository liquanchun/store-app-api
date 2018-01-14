using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model.Sale;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class YxBookRepository : EntityBaseRepository<yx_book>, IYxBookRepository
    {
        public YxBookRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
