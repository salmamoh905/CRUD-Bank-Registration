using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

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
            _context.BankUsers.Add(bankuser);
            await _context.SaveChangesAsync();
            


            return Ok(new { message = "User created" });

           // return Ok(await _context.BankUsers.ToListAsync());
        }
       [HttpDelete("{id}")]
        public async Task<ActionResult<List<BankUser>>> Delete(int id)
        {
            var dbUser = await _context.BankUsers.FindAsync(id);
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
            dbUser.amount = request.amount;

            await _context.SaveChangesAsync();

            return Ok(await _context.BankUsers.ToListAsync());
        }


     

   
}


        



   

//remaining updating user by the id