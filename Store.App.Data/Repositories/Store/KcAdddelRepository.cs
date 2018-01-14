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
    public class KcAdddelRepository : EntityBaseRepository<kc_adddel>, IKcAdddelRepository
    {
        public KcAdddelRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
