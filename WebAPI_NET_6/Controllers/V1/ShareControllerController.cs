using Microsoft.Extensions.Logging;

namespace WebAPI_NET_6.Controllers.V1;

[Route("api/ShareController")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]
public class ShareControllerController : ControllerBase
{
    private readonly IShareControllerManager _ShareControllerManager;
    private object Buystock;

    public ShareControllerController(IShareControllerManager ShareControllerManager)
    {
        _ShareControllerManager = ShareControllerManager;
    }


    // POST: /api/ShareController/transferStocks
    [HttpPost("transferStocks")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> transferStocks([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _ShareControllerManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(ledger), ShareControllerResult);
    }

    // POST: /api/ShareController/ensureOwnership
    [HttpPost("ensureOwnership")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ensureOwnership([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _ShareControllerManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(ledger), ShareControllerResult);
    }

    // GET: /api/ShareController/ledger
    [HttpGet("ledger")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ledger(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }

    // GET: /api/ShareController/ledger/customerid
    [HttpGet("ledger/customerid")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> customerid(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }

    // PUT: /api/ShareController/ledger
    [HttpPut("ledger")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Putledger(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }

    // PUT: /api/ShareController/ledger/customerid
    [HttpPut("ledger/customerid")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Putcustomerid(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }

    // DELETE: /api/ShareController/ledger
    [HttpDelete("ledger")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Deleteledger(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }

    // DELETE: /api/ShareController/ledger/customerid
    [HttpDelete("ledger/customerid")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ShareControllerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Deletecustomerid(LoginAppUserDTO login)
    {
        var user = await _ShareControllerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _ShareControllerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var ShareControllerResult = await _ShareControllerManager.GetSignedInAppUserToken(user);

        return Ok(ShareControllerResult);
    }
}
