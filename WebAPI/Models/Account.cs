using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public BankUser accountType { get; set; }
    
        public Transaction Transaction { get; set; }
    }
}