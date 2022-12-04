namespace WebAPI_NET_6.Controllers.V1;

[Route("api/Stockrequester")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]
public class StockrequesterController : ControllerBase
{
    private readonly IStockrequesterManager _StockrequesterManager;
    private object Buystock;

    public StockrequesterController(IStockrequesterManager StockrequesterManager)
    {
        _StockrequesterManager = StockrequesterManager;
    }


    // POST: /api/Stockrequester/register
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
    [HttpPost("sellstock")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(StockrequesterResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _StockrequesterManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var StockrequesterResult = await _StockrequesterManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(Buystock), StockrequesterResult);
    }

    // GET: /api/Stockrequester/buystock
    [HttpGet("buystock")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockrequesterResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> buystock(LoginAppUserDTO login)
    {
        var user = await _StockrequesterManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockrequesterManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockrequesterResult = await _StockrequesterManager.GetSignedInAppUserToken(user);

        return Ok(StockrequesterResult);
    }

       // PUT: /api/Stockrequester/Findstock
    [HttpPut("Findstock")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockrequesterResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Findstock(LoginAppUserDTO login)
    {
        var user = await _StockrequesterManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockrequesterManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockrequesterResult = await _StockrequesterManager.GetSignedInAppUserToken(user);

        return Ok(StockrequesterResult);
    }

         // PUT: /api/Stockrequester/Outlet
    [HttpDelete("Outlet")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockrequesterResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Outlet(LoginAppUserDTO login)
    {
        var user = await _StockrequesterManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockrequesterManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockrequesterResult = await _StockrequesterManager.GetSignedInAppUserToken(user);

        return Ok(StockrequesterResult);
    }
}
