namespace Store.App.Model.House
{
   using System;
   public partial class fw_statelog : IEntityBase
   {
      ///<summary>
      ///
      ///</summary>
      public int Id { get; set; }
      ///<summary>
      ///房号
      ///</summary>
      public string HouseCode { get; set; }
      ///<summary>
      ///扫房时间
      ///</summary>
      public int OldState { get; set; }
      ///<summary>
      ///扫房人
      ///</summary>
      public int NewState { get; set; }
      ///<summary>
      ///
      ///</summary>
      public string Remark { get; set; }
      ///<summary>
      ///
      ///</summary>
      public DateTime CreatedAt { get; set; }
      ///<summary>
      ///
      ///</summary>
      public DateTime UpdatedAt { get; set; }
      ///<summary>
      ///
      ///</summary>
      public bool IsValid { get; set; }
      ///<summary>
      ///
      ///</summary>
      public string CreatedBy { get; set; }
      /// <summary>
      /// 订单号
      /// </summary>
      public  string OrderNo { get; set; }
   }
}
