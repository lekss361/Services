using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

[Route("api/[controller]")]
[ApiController]
public class UserzController : ControllerBase
{
    private static readonly List<Userz> Users = new List<Userz>
    {
        new Userz { Id = 1, Name = "Alice", Age = 30 },
        new Userz { Id = 2, Name = "Bob", Age = 25 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Userz>> GetUsers()
    {
        return Users;
    }

    [HttpGet("{id}")]
    public ActionResult<Userz> GetUser(int id)
    {
        var user = Users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}

public class Userz
{
    public int Id { get; set; }
    public string Name { get;set; }
    public int Age { get; set; }
}