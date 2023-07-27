using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ApiModels
{
    public class InvitationApiResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("user")]
        public UserApiResponse User { get; set; }

        [JsonPropertyName("eventId")]
        public int EventId { get; set; }

        [JsonPropertyName("_event")]
        public EventApiResponse Event { get; set; }





    }
}
