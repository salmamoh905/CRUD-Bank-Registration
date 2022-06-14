
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
     [HttpPost]
        public async Task<IActionResult> PostAsync (Transaction transaction)
        {

            if(!ModelState.IsValid) {
                return  BadRequest(ModelState);
            }
            _context.Transactions.Add(transaction);
            //  _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();
            
            _context.Entry(transaction)
            .Reference(x => x.BankUser)
            .Load();
            var transactionDto = new TransactionDto() 
            {
                Id =transaction.Id,
                AccountNumber = transaction.AccountNumber,
                TransactionType = transaction.TransactionType,
                amount = transaction.amount,
                AccountBalance = transaction.AccountBalance,
                TransactionDate = transaction.TransactionDate,
                BankUserId = transaction.BankUser.Id
            

            };


            return Ok(new {id= transaction.Id });

           // return Ok(await _context.BankUsers.ToListAsync());
        }



    }
