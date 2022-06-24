namespace WebAPI.Models.Dto
{
    public class TransactionDto
    {
        // public int AccountNumber {get; set; }

        public  string TransactionType  {get; set; }
         public int TransactedAmount { get; set; }
        public int AccountBalance {get; set; }
        public DateTime TransactionDate {get; set; }

        public int AccountNumber {get;set;}
        public int BankUserId {get;set;}
        
    }
}
