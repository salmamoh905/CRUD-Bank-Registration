using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public  BankUser TransactionType { get; set; }
        public BankUser TransactionAmount { get; set; }
        public BankUser CreatedAt { get; set; }
    
    }
}