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
    public class SmsSettingRepository : EntityBaseRepository<sms_setting>, ISmsSettingRepository
    {
        public SmsSettingRepository(StoreAppContext context)
            : base(context)
        { }
    }
}
