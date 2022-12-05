namespace WebAPI_NET_6.Controllers.V1;

[Route("api/Stockbroker")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize]
public class StockbrokerController : ControllerBase
{
    private readonly IStockbrokerManager _StockbrokerManager;
    private object Buystock;

    public StockbrokerController(IStockbrokerManager StockbrokerManager)
    {
        _StockbrokerManager = StockbrokerManager;
    }


    // POST: /api/Stockbroker/register
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
    [HttpPost("trade")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(StockbrokerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(List<ErrorResult>))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterAppUserDTO register)
    {
        if (ModelState.IsValid is false)
            return BadRequest();

        var result = await _StockbrokerManager.RegisterAppUserAsync(register);

        if (result.Succeeded is false)
        {
            var errorResult = new List<ErrorResult>();
            foreach (var error in result.Errors)
            {
                errorResult.Add(new ErrorResult() { ErrorCode = error.Code, Description = error.Description });
            }

            return BadRequest(errorResult);
        }

        var StockbrokerResult = await _StockbrokerManager.GetSignedInAppUserToken(register.Email);

        return CreatedAtAction(nameof(buyorders), StockbrokerResult);
    }

    // GET: /api/Stockbroker/buyorders
    [HttpGet("buyorders")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockbrokerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> buyorders(LoginAppUserDTO login)
    {
        var user = await _StockbrokerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockbrokerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockbrokerResult = await _StockbrokerManager.GetSignedInAppUserToken(user);

        return Ok(StockbrokerResult);
    }

    // GET: /api/Stockbroker/saleorders
    [HttpGet("saleorders")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockbrokerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Saleorders(LoginAppUserDTO login)
    {
        var user = await _StockbrokerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockbrokerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockbrokerResult = await _StockbrokerManager.GetSignedInAppUserToken(user);

        return Ok(StockbrokerResult);
    }

    // PUT: /api/Stockbroker/buyorders
    [HttpPut("buyorders")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockbrokerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Buyorders(LoginAppUserDTO login)
    {
        var user = await _StockbrokerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockbrokerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockbrokerResult = await _StockbrokerManager.GetSignedInAppUserToken(user);

        return Ok(StockbrokerResult);
    }

    // PUT: /api/Stockbroker/buyorders
    [HttpPut("saleorders")]
    [AllowAnonymous]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(StockbrokerResult))]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(string))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> saleorders(LoginAppUserDTO login)
    {
        var user = await _StockbrokerManager.GetAppUserByEmail(login.Email);
        var isUserWithPassword = await _StockbrokerManager.LoginAppUserAsync(login);
        if (user is null || isUserWithPassword is false)
            return NotFound("Email or password is not correct.");

        var StockbrokerResult = await _StockbrokerManager.GetSignedInAppUserToken(user);

        return Ok(StockbrokerResult);
    }

}
