namespace Services.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BAL.Services;
using Services.Models;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;

    }
    [HttpPost]
    public ActionResult AddUser([FromBody] User userModel)
    {
        var user = _mapper.Map<UserDto>(userModel);

        var idAddedEntity = _userService.Add(user, userModel.Password);

        return StatusCode(StatusCodes.Status201Created, idAddedEntity);
    }

     [HttpPost]
    [Route("/1")]
    [Authorize]
    public ActionResult AddUser1([FromBody] User userModel)
    {

        return StatusCode(StatusCodes.Status201Created);
    }

     [HttpPost]
    [Route("/2")]
    [AuthorizeRole(Role.User,Role.Admin)]

    public ActionResult AddUser1q([FromBody] User userModel)
    {
        return StatusCode(StatusCodes.Status201Created);
    }





}
