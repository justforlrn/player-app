﻿using System;

namespace WebActiveHealthyKidsVietNam.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }
}
