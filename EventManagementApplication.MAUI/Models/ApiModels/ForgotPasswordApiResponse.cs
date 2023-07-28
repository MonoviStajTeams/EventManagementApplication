using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ApiModels
{
    public class ForgotPasswordApiResponse
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }
}
