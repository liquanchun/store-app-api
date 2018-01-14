using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model;
using Store.App.Model.SYS;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class SysFunctionRepository : EntityBaseRepository<sys_function>, ISysFunctionRepository
    {
        public SysFunctionRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
