﻿namespace Services.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BaseDto : IBaseDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
}
