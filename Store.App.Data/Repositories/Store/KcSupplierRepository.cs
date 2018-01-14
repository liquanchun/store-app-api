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
    public class KcSupplierRepository : EntityBaseRepository<kc_supplier>, IKcSupplierRepository
    {
        public KcSupplierRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
