using AtmApp.Data;
using AtmApp.Domain;
using AtmApp.Models;
using AtmApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtmApp.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionRepository _transactionRepository;


        public AccountController(IAccountService accountService, ITransactionRepository transactionRepository)
        {
            _accountService = accountService;
            _transactionRepository = transactionRepository;
        }

        [HttpGet("{type}")]
        public async Task<ActionResult<Account>> GetAccount(AccountType type)
        {
            try
            {
                var account = await _accountService.GetAccountAsync(type);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{type}/deposit")]
        public async Task<IActionResult> Deposit(AccountType type, [FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Deposit amount must be greater than 0.");

            try
            {
                await _accountService.DepositAsync(type, amount);
                return Ok(new { message = $"Deposited {amount:C} to {type} account." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{type}/withdraw")]
        public async Task<IActionResult> Withdraw(AccountType type, [FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Withdrawal amount must be greater than 0.");

            try
            {
                await _accountService.WithdrawAsync(type, amount);
                return Ok(new { message = $"Withdrew {amount:C} from {type} account." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            if (request.Amount <= 0)
                return BadRequest("Transfer amount must be greater than 0.");

            try
            {
                await _accountService.TransferAsync(request.From, request.To, request.Amount);
                return Ok(new { message = $"Transferred {request.Amount:C} from {request.From} to {request.To}." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionHistory()
        {
            var history = await _transactionRepository.GetTransactionsAsync();
            return Ok(history);
        }
    }
}
