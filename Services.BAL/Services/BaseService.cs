namespace Services.BAL.Services;

using global::Services.DAL;
using global::Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseService
{
    protected readonly IDbRepository _rpository;

    protected BaseService(IDbRepository rpository)
    {
        _rpository = rpository;
    }

    protected static void ThrowIfEntityNotFound<T>(T? entity, int id)
    {
        if (entity is null)
            throw new NullReferenceException(typeof(T).Name+ id);
    }

    protected static void ThrowIfRoleDoesntHavePermissions()
    {
        throw new AuthenticationException("Your current role doesn't have permissions to do this.");
    }

    protected UserDto CheckUserRole(int userId, params Role[] roles)
    {
        var user = _rpository.Get<UserDto>(x=>x.Id==userId).First();
        ThrowIfEntityNotFound(user, userId);

        if (!roles.Contains(Role.User) || user.IsActive)
            ThrowIfRoleDoesntHavePermissions();

        return user;
    }
}
