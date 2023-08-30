﻿using Newtonsoft.Json;

namespace OnlineShop.Library.IdentityServer
{
    public class Token
    {
        [JsonProperty("access_token")] // this attribute for sirializing AccessToken to access_token
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}