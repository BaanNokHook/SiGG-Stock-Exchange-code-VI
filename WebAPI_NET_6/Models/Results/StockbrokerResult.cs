namespace WebAPI_NET_6.Models.Results;

public class StockbrokerResult
{
    public string Username { get; set; }

    [Display(Name = "Fullname")]
    public string FullName { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}