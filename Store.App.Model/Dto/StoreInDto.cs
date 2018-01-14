using System;
using System.Collections.Generic;
using System.Text;
using Store.App.Model.Store;

namespace Store.App.Model.Dto
{
    public class StoreInDto
    {

        public kc_storein Storein { get; set; }

        public List<kc_storeinlist> StoreinList { get; set; }
    }
    public class StoreInAllDto
    {
        public List<StoreInGridDto> StoreInList { get; set; }

        public List<StoreInListDto> StoreInDetailList { get; set; }
    }
}
