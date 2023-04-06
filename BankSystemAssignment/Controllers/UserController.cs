using BankSystemAssignment.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystemAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(int userId, double money)
        {
            if (money< 100)
            {
                return BadRequest("Money can't be less than $100");
            }
            return Ok(await _userBusiness.CreateAccount(userId, money));
        }
        [HttpGet]
        public async Task<IActionResult> GetUserAccount(int userId)
        {
            return Ok(await _userBusiness.GetUserAccount(userId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAccount(int accountId)
        {
            return Ok(await _userBusiness.DeleteUserAccount(accountId));
        }

    }
}
