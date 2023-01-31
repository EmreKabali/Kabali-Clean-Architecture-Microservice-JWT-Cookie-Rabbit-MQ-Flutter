using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platforms.Domain.DTO;
using Platforms.Domain.DTO.Account;
using Platforms.Domain.Entities;
using Platforms.Infrastructure.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platforms.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController>logger)
        {
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult Login(LoginDTO item)
        {
            _logger.LogInformation("Method started");
            try
            {
                if (ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse { Message = "Ok",Entity=new User { FullName="John",Email="johndave@gmail.com"} });
                }
                else
                {
                    return BadRequest(new ApiResponse { HasException = true, Message = Constants.ErrorMessages.ModelIsNotValid });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Login Method Exception", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,new ApiResponse { HasException=true,Message=Constants.ErrorMessages.SomethingsWrong});
           
            }
        }
    }
}

