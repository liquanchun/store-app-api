using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model.SYS;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class SysMenuRepository : EntityBaseRepository<sys_menu>, ISysMenuRepository
    {
        public SysMenuRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
