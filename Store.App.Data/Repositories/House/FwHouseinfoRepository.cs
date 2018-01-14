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
    public class FwHouseinfoRepository : EntityBaseRepository<fw_houseinfo>, IFwHouseinfoRepository
    {
        public FwHouseinfoRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
