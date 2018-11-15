using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App.Model.Dto
{
    public class SaleBill
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string SaleMan { get; set; }
        public string DMSNo { get; set; }
        public string SelfConfig { get; set; }


        public decimal GuidePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Deposit { get; set; }
        public int Days1 { get; set; }

        public decimal PredictFee { get; set; }
        public int Days2 { get; set; }
        public decimal WholeFee { get; set; }
        public string FinaceCompany { get; set; }
        public decimal FirstFee { get; set; }

        public int Stages { get; set; }
        public int Days3 { get; set; }
        public string PreCarDate { get; set; }
        public string PickCarType { get; set; }
        public string PickCarMan { get; set; }

        public string PickCarMobile { get; set; }
        public string Remark { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LinkMan { get; set; }

        public string Phone { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public string Vinno { get; set; }
        public string Status { get; set; }

        public string IdCard { get; set; }
        public string LicenseType { get; set; }
        public string IdAddress { get; set; }
        public string CustType { get; set; }
        public string CarTrim { get; set; }

        public string TakeCarSite { get; set; }
        public string TakePhone { get; set; }
        public string Auditor { get; set; }
        public string AuditResult { get; set; }
        public string AuditSuggest { get; set; }

        public string PayType { get; set; }
        public string AuditTime { get; set; }
    }
}
