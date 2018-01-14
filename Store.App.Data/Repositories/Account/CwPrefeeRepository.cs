using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model.Account;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class CwPrefeeRepository : EntityBaseRepository<cw_prefee>, ICwPrefeeRepository
    {
        public CwPrefeeRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
