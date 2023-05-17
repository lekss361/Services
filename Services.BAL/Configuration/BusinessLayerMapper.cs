namespace Services.BAL.Configuration;

using AutoMapper;
using global::Services.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

public class BusinessLayerMapper : Profile
{
    public BusinessLayerMapper()
    {
        
        CreateMap<User, UserDto>().ReverseMap();
    }
}
