using Factorial.Services;
using Factorialn;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Factorial.Controllers;

[ApiController]
[Route("[controller]")]
public class FactorialController : ControllerBase
{
    private readonly IStringLocalizer _stringLocalizer;
    private readonly FactorialService _factorialService;

    public FactorialController(FactorialService factorialService, IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        _factorialService = factorialService;
    }

    /// <summary>
    /// Calculates factorial from given value. The n value must be between 0 and 10. 
    /// You have 5 free calculates :) Your promo code is 9999.
    /// </summary>
    /// <param name="n"></param>
    [HttpGet(Name = "GetFactorial")]
    public IActionResult Get(int n=5)
    {
        if (n==9999)
        {
            _factorialService.AddFunds(5);
            return Ok(_stringLocalizer.GetString("promo-code-ok"));
        }

        if (n < 0)
            return BadRequest(
                new ClientError(Error.VALIDATION,
                    _stringLocalizer.GetString("validation-error-must-be-greater-or-equal-zero"),
                    nameof(n)));

        if (n > 10)
            return BadRequest(
                new ClientError(Error.VALIDATION,
                    _stringLocalizer.GetString("validation-error-too-large"),
                    nameof(n)));

        if (_factorialService.Funds <= 0)
            return BadRequest(
                new ClientError(Error.NO_FUNDS,
                    _stringLocalizer.GetString("no-funds-please-pay"),
                    nameof(n)));

        return Ok(_factorialService.GetFactorial(n));
    }
}
