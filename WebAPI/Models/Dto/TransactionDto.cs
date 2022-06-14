namespace WebAPI.Models.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public int AccountNumber {get; set; }

        public string TransactionType  {get; set; }
        public int amount {get; set; }
        public int AccountBalance {get; set; }
        public DateTime TransactionDate {get; set; }

        public int BankUserId {get;set;}
        
    }
}
