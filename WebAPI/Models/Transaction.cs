using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Models
{
    public class Transaction
    {
           
        [Key]
        public int Id { get; set; }
        public int AccountNumber{get; set; }
        public string? TransactionType { get; set; }
        public int amount { get; set; }
        public int AccountBalance { get; set; }
        public DateTime TransactionDate { get; set; }
    
       //navigation property an account can have one bankUser
       public int BankUserId { get; set; }
       public BankUser BankUser { get; set; }
    }
    
}