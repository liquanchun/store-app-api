using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App.Model.Dto
{
    public class CashBill
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
        public string InvoiceDate { get; set; }
        public string BuyType { get; set; }
        public string BuyLicense { get; set; }


        public string CustAttr { get; set; }
        public string PayType { get; set; }
        public string InsureCompany { get; set; }
        public string Discount { get; set; }
        public decimal NewCarFee { get; set; }

        public decimal FirstFee { get; set; }
        public decimal InsureFee { get; set; }
        public decimal BuyTaxFee { get; set; }
        public decimal FinanceSerFee { get; set; }
        public decimal DecorateFee { get; set; }

        public decimal TakeAllFee { get; set; }
        public decimal TakeCareFee { get; set; }
        public decimal IntimateFee { get; set; }
        public decimal GlassSerFee { get; set; }
        public decimal CardCashFee { get; set; }

        public decimal OtherFee { get; set; }
        public decimal ShouldAllFee { get; set; }
        public decimal InvoiceFee { get; set; }
        public decimal Deposit { get; set; }
        public decimal OldChangeFee { get; set; }

        public decimal LastFee { get; set; }
        public decimal OtherFee2 { get; set; }
        public decimal RealAllFee { get; set; }
        public decimal BaoxianFee { get; set; }
        public decimal ZhuangxFee { get; set; }

        public decimal Commission { get; set; }
        public decimal MaintainFee { get; set; }
        public decimal GasFee { get; set; }
        public decimal OtherFee3 { get; set; }
        public string Auditor { get; set; }

        public string AuditResult { get; set; }
        public string AuditSuggest { get; set; }

        public string Remark { get; set; }
        public string AuditTime { get; set; }
    }
}
