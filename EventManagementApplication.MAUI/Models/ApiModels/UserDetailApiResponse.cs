using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ApiModels
{
    public class UserDetailApiResponse
    {
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("user")]
        public UserApiResponse User { get; set; }




    }
}
