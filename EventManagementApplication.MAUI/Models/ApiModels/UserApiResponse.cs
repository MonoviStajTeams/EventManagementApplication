using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ApiModels
{
    public class UserApiResponse
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("mail")]
        public string Mail { get; set; }

        [JsonPropertyName("passwordSalt")]
        public string PasswordSalt { get; set; }

        [JsonPropertyName("PasswordHash")]
        public string PasswordHash { get; set; }

        [JsonPropertyName("Status")]
        public bool Status { get; set; }

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }

        [JsonPropertyName("role")]
        public object Role { get; set; }

        [JsonPropertyName("resetToken")]
        public string ResetToken { get; set; }

        [JsonPropertyName("resetTokenExpiration")]
        public DateTime ResetTokenExpiration { get; set; }


    }
}
