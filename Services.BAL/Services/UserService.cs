namespace Services.BAL.Services;
using global::Services.BAL.Helpers;

using global::Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

public class UserService : BaseService, IUserService
{

    public UserService(DAL.IDbRepository rpository) : base(rpository)
    {
    }


    public int Add(UserDto entity, string password)
    {
        entity.PasswordHash = SecurePasswordHasher.Hash(password);
        var id = _rpository.Add<UserDto>(entity);
        _rpository.SaveChangesAsync();
        return _rpository.Get<UserDto>().OrderByDescending(i => i.Id).FirstOrDefault().Id;
    }

    public List<UserDto> GetList()
    {
        var entities = _rpository.GetAll<UserDto>();
        return entities.ToList();
    }


    public List<UserDto> GetListDelete()
    {
        var entities = _rpository.GetAll<UserDto>().Where(t => t.IsActive==false);
        return entities.ToList();

    }

    public void Update(int id, UserDto entity)
    {
        _rpository.Update<UserDto>(entity);
    }

    public void Delete(int id)
    {

        _rpository.Delete<UserDto>(id);

    }
}
