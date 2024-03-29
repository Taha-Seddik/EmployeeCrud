﻿using System.Text.Json.Serialization;

namespace EmployeeCrud.Web.Models
{
    public class RefreshToken
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }   

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
