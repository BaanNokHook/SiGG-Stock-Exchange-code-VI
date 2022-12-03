namespace WebAPI_NET_6.Models.Entities;

public class AppUser : IdentityUser
{
    internal object CustomerId;
    internal object StockName;

    public string FullName { get; set; }
}
