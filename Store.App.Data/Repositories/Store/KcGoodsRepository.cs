using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model.Store;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class KcGoodsRepository : EntityBaseRepository<kc_goods>, IKcGoodsRepository
    {
        public KcGoodsRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
