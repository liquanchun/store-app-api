 using System;


 
 namespace Store.App.API
{
  public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Fname {get;set;}
        public string Lname {get;set;}
    
    }
   
   
}