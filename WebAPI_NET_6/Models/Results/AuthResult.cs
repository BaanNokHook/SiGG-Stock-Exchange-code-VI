namespace WebAPI_NET_6.Models.Results;

public class AuthResult
{
    internal object CustomerId;
    internal object StockName;
    internal object Amount;
    internal string PricePerStock;

    public string Username { get; set; }

    [Display(Name = "Fuulname")]
    public string FullName { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}