using System;
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

    public class QueryPara
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string SelectedOrg { get; set; }

        public string Operator {get; set; }
    }

    public class vw_storeout
    {
        public int Id { get; set; }

        public int OrgId { get; set; }

        public int Operator { get; set; }

        public DateTime OutTime { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public string DicName { get; set; }

        public decimal Number { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public string Remark { get; set; }
    }
}