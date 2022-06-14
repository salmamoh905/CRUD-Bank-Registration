using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Dto;

namespace WebAPI.Controllers;

// [ApiController]
// [Route("api/registrations")]
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


            public async Task<IActionResult> PostAsync (BankUser bankuser)
        {

            if(!ModelState.IsValid) {
                return  BadRequest(ModelState);
            }
            _context.BankUsers.Add(bankuser);
            //  _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();
            
            _context.Entry(bankuser)
            .Reference(x => x.Transactions)
            .Load();
            var bankUserDto = new BankUserDto() 
            {
                Id =bankuser.Id,
                FirstName = bankuser.FirstName,
                LastName = bankuser.LastName,
                Email = bankuser.Email,
                Password = bankuser.Password
                
            

            };


            return Ok(new {id= bankuser.Id });

           // return Ok(await _context.BankUsers.ToListAsync());
        }

        
        // public async Task<IActionResult> PostAsync (BankUser   bankuser)
        // {
        //     _context.BankUsers.Add(bankuser);
        //      _context.Transactions.AddRange(bankuser.Transactions);
        //     await _context.SaveChangesAsync();
        //     // _context.BankUsers.Add(bankuser);
        //     // await _context.SaveChangesAsync();
            


        //     return Ok(new { message = "Bank User created" });

        //    // return Ok(await _context.BankUsers.ToListAsync());
        // }
      


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
            

            await _context.SaveChangesAsync();

            return Ok(await _context.BankUsers.ToListAsync());
        }


     

   
}


        



   

//remaining updating user by the id