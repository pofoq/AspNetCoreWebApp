﻿using System;


namespace BusinessLayer.Abstraction.Dto
{
    public sealed class RefreshToken
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
