using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Dto;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
    public class RegistrationController : ControllerBase
   {
       private readonly DataContext _context;
       public RegistrationController(DataContext context){
           _context=context;
       }
       [HttpGet]
       public async Task<ActionResult<List<BankUser>>> Get(){
           return Ok(await _context.BankUsers.ToListAsync());
       }
        [HttpGet("{id}")]
        public async Task<ActionResult<BankUser>> Get(int id)
        {
            var bankuser = await _context.BankUsers.FindAsync(id);
            if (bankuser == null)
                return BadRequest("Bank user not found.");
            return Ok(bankuser);
        }

           
           
        [HttpPost]
            public async Task<IActionResult> PostAsync (BankUserDto bankUserDto)
        {

            var bankUser = new BankUser() 
            {
                FirstName = bankUserDto.FirstName,
                LastName = bankUserDto.LastName,
                Email = bankUserDto.Email,
                Password = bankUserDto.Password,
                Initialamount = bankUserDto.Initialamount,  
            };

             
           
            await _context.SaveChangesAsync();

            await _context.BankUsers.AddAsync(bankUser);
            //await _context.Transactions.AddAsync(new Transaction () { BankUser = bankUser});
            await _context.SaveChangesAsync();


            return Ok(bankUserDto);

           // return Ok(await _context.BankUsers.ToListAsync());
        }

                
       


       [HttpDelete("{id}")]
        public async Task<ActionResult<List<BankUser>>> Delete(int Id)
        {
            var dbUser = await _context.BankUsers.FindAsync(Id);
            if (dbUser == null)
                return BadRequest("user not found.");

            _context.BankUsers.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.BankUsers.ToListAsync());
        }


         [HttpPut("{id}")]
        public async Task<ActionResult<BankUser>> UpdateUser(BankUser request)
        {
            var dbUser = await _context.BankUsers.FindAsync(request.Id);
            if (dbUser == null)
                return BadRequest("user not found.");

            
            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.Email = request.Email;
            dbUser.Password = request.Password;
            dbUser.AccountNumber = request.AccountNumber;
            dbUser.Initialamount = request.Initialamount;
            

            await _context.SaveChangesAsync();

            return Ok(await _context.BankUsers.ToListAsync());
        }


     

   
}


        



   

//remaining updating user by the id