namespace Store.App.Model.Store
{
   using System;
   public partial class kc_goods : IEntityBase
   {
      ///<summary>
      ///
      ///</summary>
      public int Id { get; set; }
      ///<summary>
      ///
      ///</summary>
      public string Name { get; set; }
      ///<summary>
      ///
      ///</summary>
      public int TypeId { get; set; }
      ///<summary>
      ///
      ///</summary>
      public string Unit { get; set; }
      ///<summary>
      ///
      ///</summary>
      public decimal Price { get; set; }
      ///<summary>
      ///
      ///</summary>
      public decimal EmpPrice { get; set; }
      ///<summary>
      ///
      ///</summary>
      public decimal MaxAmount { get; set; }
      ///<summary>
      ///
      ///</summary>
      public decimal MinAmount { get; set; }
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

       public string GoodsCode { get; set; }

       public string GoodsNo { get; set; }
       /// <summary>
       /// Ʒ��
       /// </summary>
       public string GoodsBrand { get; set; }

       public string ImageName { get; set; }
    }
}
