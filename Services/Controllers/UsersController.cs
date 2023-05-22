namespace Services.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BAL.Services;
using Services.DAL;
using Services.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IDbRepository rpository;

    public UsersController(IUserService userService, IMapper mapper, IDbRepository rpository)
    {
        _userService = userService;
        _mapper = mapper;
        this.rpository = rpository;
    }
    [HttpPost]
    public ActionResult AddUser([FromBody] User userModel)
    {
        var user = _mapper.Map<UserDto>(userModel);

        var idAddedEntity = _userService.Add(user, userModel.Password);

        return StatusCode(StatusCodes.Status201Created, idAddedEntity);
    }

     [HttpGet]
    [Route("/1/{message}")]
    public ActionResult AddUser1(int message)
    {
        var c = rpository.Get<UserDto>(x=>x.Id== message);
        return StatusCode(StatusCodes.Status201Created, c);
    }

     [HttpPost]
    [Route("/2")]
    [AuthorizeRole(Role.User,Role.Admin)]

    public ActionResult AddUser1q([FromBody] User userModel)
    {
        return StatusCode(StatusCodes.Status201Created);
    }





}
