namespace WebAPI_NET_6.Controllers.V1;

[Route("api/Stockbroker")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]

public class TransactionManagerController : ControllerBase
{
    private readonly TransactionManagerManager _TransactionManagerManager;
    private object Buystock;

    public TransactionManagerController(TransactionManagerManager TransactionManagerManager)
    {
        _TransactionManagerManager = TransactionManagerManager;
    }


    // POST: /api/TransactionManager/register
    /// <summary>
    ///     Register new application user.
    /// </summary>
    /// <remarks>
    /// Scheme EXP:
    /// 
    ///     {
    ///         "fullname": "fullname-01"
    ///         "email": "username01@gmail.com"
    ///         "password": "username01"
    ///         "passwordConfirmation": "username01"
    ///     }
    /// </remarks>
    /// <param name="register"></param>
    /// <returns></returns>
    [HttpPost("transaction")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(TransactionManagerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> transaction([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _TransactionManagerManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var TransactionManagerResult = await _TransactionManagerManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(Gettransaction), TransactionManagerResult);
    }

    // GET: /api/TransactionManager/buystock
    [HttpGet("transaction")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TransactionManagerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Gettransaction(LoginAppUserDTO login)
    {
        var user = await _TransactionManagerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _TransactionManagerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var TransactionManagerResult = await _TransactionManagerManager.GetSignedInAppUserToken(user);

        return Ok(TransactionManagerResult);
    }

    // PUT: /api/TransactionManager/Findstock
    [HttpPut("transaction/{id}")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TransactionManagerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Puttransaction(LoginAppUserDTO login)
    {
        var user = await _TransactionManagerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _TransactionManagerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var TransactionManagerResult = await _TransactionManagerManager.GetSignedInAppUserToken(user);

        return Ok(TransactionManagerResult);
    }

    // PUT: /api/TransactionManager/Outlet
    [HttpDelete("transaction/{id}")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(TransactionManagerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Outlet(LoginAppUserDTO login)
    {
        var user = await _TransactionManagerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _TransactionManagerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var TransactionManagerResult = await _TransactionManagerManager.GetSignedInAppUserToken(user);

        return Ok(TransactionManagerResult);
    }
}