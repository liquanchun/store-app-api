namespace Store.App.Model.SYS
{
   using System;
   public partial class sys_role_user : IEntityBase
   {
      ///<summary>
      ///
      ///</summary>
      public int Id { get; set; }
      ///<summary>
      ///
      ///</summary>
      public int RoleId { get; set; }
      ///<summary>
      ///
      ///</summary>
      public int UserId { get; set; }
   }
}
