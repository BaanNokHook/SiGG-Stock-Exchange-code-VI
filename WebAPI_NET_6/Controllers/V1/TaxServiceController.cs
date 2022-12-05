using WebAPI_NET_6.Managers;
using WebAPI_NET_6.Models.Results;

namespace WebAPI_NET_6.Controllers.V1;

[Route("api/Stockbroker")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]

public class TaxServiceController : ControllerBase
{
    private readonly TaxServiceManager _taxServicemanager;
    private object registerTransactionTax;
    private object _registerTransactionTax;

    public TaxServiceController(TaxServiceManager TaxServiceManager)
    {
        _taxServicemanager = TaxServiceManager;   
    }

    [HttpPost("registerTransactionTax")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(TaxServiceResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]   
    public async Task<IActionResult> RegisterTransactionTax([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _taxServicemanager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var TaxServiceResult = await _taxServicemanager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(GetTaxService), TaxServiceResult);   
    }

    // GET: /api/TaxServiceManager/GetTaxService  
    [HttpGet("GetTaxService")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TaxServiceResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]  
    public async Task<IActionResult> GetTaxService(LoginAppUserDTO login)
    {
        var user = await _taxServicemanager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _taxServicemanager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)

            return NotFound("Email or password is not correct.");

        var TaxServiceManagerResult = await _taxServicemanager.GetSignedInAppUserToken(user);

        return Ok();
    }


    // PUT: /api/TaxServiceManager/FindTaxService   
    [HttpPut("FindTaxService")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TaxServiceResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> FindTaxService(LoginAppUserDTO login)
    {
        var user = await _taxServicemanager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _taxServicemanager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var taxServiceResult = await _taxServicemanager.GetSignedInAppUserToken(user);

        return Ok(taxServiceResult);   

    }

    // DELETE: /api/taxServicemanager/ClearTaxService    
    [HttpDelete("ClearTaxService")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TaxServiceResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Outlet(LoginAppUserDTO login)
    {
        var user = await _taxServicemanager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _taxServicemanager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var TransactionManagerResult = await _taxServicemanager.GetSignedInAppUserToken(user);

        return Ok(TransactionManagerResult);
    }
}

