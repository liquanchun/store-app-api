using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.App.Model.House;
using Store.App.Data;
using Store.App.Data.Repositories;
using Store.App.Data.Abstract;

namespace Store.App.Data.Repositories
{
    public class FwCusgoodsRepository : EntityBaseRepository<fw_cusgoods>, IFwCusgoodsRepository
    {
        public FwCusgoodsRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
