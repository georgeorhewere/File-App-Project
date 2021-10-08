﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface IJWTConfig
    {
        string SigningKey { get;  set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        int ExpiryTimeInMinutes { get; set; }
    }
}