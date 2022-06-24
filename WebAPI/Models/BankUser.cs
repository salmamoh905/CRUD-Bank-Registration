using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class BankUser
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Password { get; set; }
      public int? AccountNumber{get; set; }
       public int? Initialamount { get; set; }
        

       
        //navigation property
        public  List<Transaction> Transactions { get; set; }
        
      
       
        



    }
}