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
    public class CwPreauthRepository : EntityBaseRepository<cw_preauth>, ICwPreauthRepository
    {
        public CwPreauthRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
