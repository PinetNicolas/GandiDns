
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Api.Gandi
{
    public class ErrorMessageDto
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "object")]
        public string ObjectInfo { get; set; }
        [JsonProperty(PropertyName = "cause")]
        public string Cause { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "errors")]
        public List<ErrorDetailDto> Errors { get; set; }

        /// <summary>
        /// Format message with not empty field
        /// </summary>
        /// <returns>the message</returns>
        public string GetMessage()
        {
            StringBuilder ret = new StringBuilder();
            if(Code > 0)
                ret.AppendLine($"Code : {Code}");
            if(string.IsNullOrEmpty(Message))
                ret.AppendLine($"Message : {Message}");
            if (string.IsNullOrEmpty(ObjectInfo))
                ret.AppendLine($"ObjectInfo : {ObjectInfo}");
            if (string.IsNullOrEmpty(Cause))
                ret.AppendLine($"Cause : {Cause}");
            if (string.IsNullOrEmpty(Status))
                ret.AppendLine($"Status : {Status}");

            if(Errors != null && Errors.Count > 0)
            {
                foreach(ErrorDetailDto e in Errors)
                {
                    ret.Append(e.GetMessage());
                }
            }

            return ret.ToString();
        }

    }

    public class ErrorDetailDto
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "line")]
        public string Line { get; set; }
        [JsonProperty(PropertyName = "cause")]
        public string Cause { get; set; }

        /// <summary>
        /// Format message with not empty field
        /// </summary>
        /// <returns>the message</returns>
        public string GetMessage()
        {
            StringBuilder ret = new StringBuilder();
            if (string.IsNullOrEmpty(Location))
                ret.AppendLine($"Location : {Location}");
            if (string.IsNullOrEmpty(Name))
                ret.AppendLine($"Name : {Name}");
            if (string.IsNullOrEmpty(Description))
                ret.AppendLine($"Description : {Description}");
            if (string.IsNullOrEmpty(Line))
                ret.AppendLine($"Line : {Line}");
            if (string.IsNullOrEmpty(Cause))
                ret.AppendLine($"Cause : {Cause}");

            return ret.ToString();
        }
    }
}
