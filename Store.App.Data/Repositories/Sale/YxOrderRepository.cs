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
    public class YxOrderRepository : EntityBaseRepository<yx_order>, IYxOrderRepository
    {
        public YxOrderRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
