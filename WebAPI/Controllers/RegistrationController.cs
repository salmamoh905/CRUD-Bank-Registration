using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/registrations")]
    public class RegistrationController : ControllerBase
    {
        [HttpGet]
        public string[] GetUsers()
        {
            string[] users = { "salmi", "fes", "thou" };
            return users;
        }
    }

