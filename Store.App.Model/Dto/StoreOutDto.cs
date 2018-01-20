﻿using System;
using System.Collections.Generic;
using System.Text;
using Store.App.Model.Store;

namespace Store.App.Model.Dto
{
    public class StoreOutDto
    {

        public kc_storeout Storeout { get; set; }

        public List<kc_storeoutlist> StoreoutList { get; set; }
    }
    public class StoreOutAllDto
    {
        public List<StoreOutGridDto> StoreOutList { get; set; }

        public List<StoreOutListDto> StoreOutDetailList { get; set; }
    }
}
