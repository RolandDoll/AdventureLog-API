using Microsoft.EntityFrameworkCore;

namespace AdventureLog_API.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
}
