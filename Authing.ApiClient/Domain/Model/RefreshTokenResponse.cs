﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authing.ApiClient.Domain.Model
{
    public class RefreshTokenResponse
    {

        [JsonProperty("refreshToken")]
        public RefreshToken Result { get; set; }
    }
}
