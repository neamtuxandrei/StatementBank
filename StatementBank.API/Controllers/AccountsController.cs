using Microsoft.AspNetCore.Mvc;
using StatementBank.DataAccess;

namespace StatementBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        // should have smthing in between api and data access?? for ex BusinessLogic, db context 
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet(Name = "GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAccounts()
        {
            try
            {
                var accounts = _accountRepository.GetAccounts();
                return new OkObjectResult(accounts);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}
