namespace Services;

using Microsoft.AspNetCore.Authorization;
using Services.Models;

public class AuthorizeRole : AuthorizeAttribute
{

    public AuthorizeRole(params Role[] roles) : base()
    {
        Roles = String.Join(",", roles);
    }

}
