﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App.Model.Dto
{
    public class StoreOutListDto
    {///<summary>
        ///
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///
        ///</summary>
        public int GoodsId { get; set; }
        public string GoodsIdTxt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsTypeId { get; set; }

        public string GoodsTypeIdTxt { get; set; }


        public string GoodsBrand { get; set; }

        public string unit { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal number { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal price { get; set; }
        ///<summary>
        ///
        ///</summary>
        public decimal amount { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string orderno { get; set; }

        public string batchno { get; set; }

        public string goodscode { get; set; }

        public string goodssite { get; set; }
    }
}
