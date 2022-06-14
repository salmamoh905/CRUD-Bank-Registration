
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
        public async Task<IActionResult> PostAsync (TransactionDto transactionDto)
        {

            if(!ModelState.IsValid) {
                return  BadRequest(ModelState);
            }
           
            //  _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();
            
            // _context.Entry(transactionDto)
            // .Reference(x => x.BankUser)
            // .Load();
            var transaction = new Transaction() 
            {
                AccountNumber = transactionDto.AccountNumber,
                TransactionType = transactionDto.TransactionType,
                amount = transactionDto.amount,
                AccountBalance = transactionDto.AccountBalance,
                TransactionDate = transactionDto.TransactionDate,
                BankUserId = transactionDto.BankUserId
            

            };
            
            await _context.SaveChangesAsync();

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();



           //return Ok(new {id= transaction.Id });

           return Ok(await _context.Transactions.ToListAsync());
        }



    }
