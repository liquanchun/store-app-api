//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.App.Model.SYS
{
    using System;
    using System.Collections.Generic;
    
    public partial class SetCardUpgradeDto
    {
        public int Id { get; set; }
        public int OldCard { get; set; }
        public string OldCardTxt { get; set; }
        public int NewCard { get; set; }
        public string NewCardTxt { get; set; }
        public int NeedInte { get; set; }
        public int TakeInte { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public bool IsValid { get; set; }
        public string CreatedBy { get; set; }
    }
}
