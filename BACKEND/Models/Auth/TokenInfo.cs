﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Models.Auth
{
    public class TokenInfo
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
