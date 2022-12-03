namespace WebAPI_NET_6.Controllers.V1;

[Route("api/Stockprovider")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]
public class StockproviderController : ControllerBase
{
    private readonly IStockproviderManager _StockproviderManager;
    private object Buystock;

    public StockproviderController(IStockproviderManager StockproviderManager)
    {
        _StockproviderManager = StockproviderManager;
    }


    // POST: /api/Stockprovider/register
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
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(StockproviderResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _StockproviderManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var StockproviderResult = await _StockproviderManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(Buystock), StockproviderResult);
    }

    // GET: /api/Stockprovider/buystock
    [HttpGet("buystock")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockproviderResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> buystock(LoginAppUserDTO login)
    {
        var user = await _StockproviderManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockproviderManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockproviderResult = await _StockproviderManager.GetSignedInAppUserToken(user);

        return Ok(StockproviderResult);
    }

       // PUT: /api/Stockprovider/Findstock
    [HttpPut("Findstock")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockproviderResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Findstock(LoginAppUserDTO login)
    {
        var user = await _StockproviderManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockproviderManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockproviderResult = await _StockproviderManager.GetSignedInAppUserToken(user);

        return Ok(StockproviderResult);
    }

         // PUT: /api/Stockprovider/Outlet
    [HttpDelete("Outlet")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockproviderResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Outlet(LoginAppUserDTO login)
    {
        var user = await _StockproviderManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockproviderManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockproviderResult = await _StockproviderManager.GetSignedInAppUserToken(user);

        return Ok(StockproviderResult);
    }
}
