using Ecommerce_Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(ILogger<AccountController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Route("api/getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _unitOfWork.Account.GetAll();
            return Ok(accounts);
        }

        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Account.CreateAccount(account);
                await _unitOfWork.CompleteAsync();

                return Ok("Success");
            }

            return new JsonResult("Something Went Wrong") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("api/update")]
        public async Task<IActionResult> Update(int accountID, Account entity)
        {
            var accountUpdUOW = await _unitOfWork.Account.UpdateAccount(accountID, entity);

            if (accountUpdUOW == 0)
            {
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Update Account Success") { StatusCode = 200 };
            }
            else if (accountUpdUOW == 1)
            {
                return new JsonResult("Account ID is not map") { StatusCode = 500 };
            }
            else if (accountUpdUOW == 2)
            {
                return new JsonResult("Account is not exist") { StatusCode = 500 };
            }
            else
            {
                return new JsonResult("Account Update Error") { StatusCode = 500 };
            }
        }
    }
}
