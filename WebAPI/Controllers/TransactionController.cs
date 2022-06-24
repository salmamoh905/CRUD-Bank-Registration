
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Dto;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

    public class TransactionController : ControllerBase
    
    {
          private readonly DataContext _context;
    public TransactionController(DataContext context){
        _context=context;
    }
        [HttpGet]
       public async Task<ActionResult<List<Transaction>>> Get(){
           return Ok(await _context.Transactions.ToListAsync());
       }
  
        [HttpGet("{id}")]
          public async Task<ActionResult<List<Transaction>>> Get(int id)
        {
           // var transactionPerId = await _context.Transactions.FindAsync(id);
           
            var q =  (from pd in _context.Transactions join od in _context.BankUsers on pd.Id equals od.Id orderby od.Id
            select new { 
             id = pd.Id,
             name=od.FirstName,
            transactiontype = pd.TransactionType,
            amount = pd.TransactedAmount,
            AccountNumber=pd.AccountNumber}).ToListAsync();
            
            if (q == null)
                return BadRequest("User's Transaction not found.");
            return Ok(q);
        }

       

        [HttpPost]
      [Route("Transaction/{id}")]
        public async Task<IActionResult> AddNewTransaction([FromRoute] int id ,TransactionDto transactionDto)
        {

            if(!ModelState.IsValid) {
                return  BadRequest(ModelState);
            }
             var bankuserFK = await _context.BankUsers.FirstOrDefaultAsync(x => x.Id ==id);
            
            
             var calculatedBalance = _context.BankUsers.FromSqlRaw("SELECT  FROM amount in bankuserFK");
    
            var transaction = new Transaction() 

            {
                TransactionType = transactionDto.TransactionType,
                TransactedAmount = transactionDto.TransactedAmount,
                // AccountBalance = calculatedBalance,
                TransactionDate = transactionDto.TransactionDate,
                AccountNumber = transactionDto.AccountNumber,
                BankUserId = bankuserFK.Id,          
            };           
            await _context.SaveChangesAsync();

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
          return Ok(new {balance=transactionDto.AccountBalance });

        
        }



    }
