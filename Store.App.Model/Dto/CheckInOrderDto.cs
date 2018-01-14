using System;
using System.Collections.Generic;
using System.Text;
using Store.App.Model.Sale;

namespace Store.App.Model.Dto
{
    public class CheckInOrderDto
    {
        public yx_order YxOrder { get; set; }
        public List<yx_orderlist> YxOrderList {get; set; }
    }
    public class OrderDataDto
    {
        public List<OrderDto> OrderList { get; set; }
        public List<OrderListDto> OrderDetailList { get; set; }
    }
}
