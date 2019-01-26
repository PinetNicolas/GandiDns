
using Newtonsoft.Json;

namespace Api.Gandi.Base
{
    public abstract class Response<T>
    {
        public T Data { get; set; }

        /// <summary>
        /// Error message that can be display or log
        /// when ReturnCode != OK
        /// </summary>
        public ErrorMessageDto ErrorMessage { get; set; }

        /// <summary>
        /// Load a http response into dto
        /// </summary>
        /// <param name="resp">Response with brute data and code error</param>
        public void Load(ApiResponse resp)
        {
            if (resp.ReturnCode != ApiRequestCode.OK)
            {
                    this.ErrorMessage = JsonConvert.DeserializeObject<ErrorMessageDto>(resp.Response);
            }
            else
            {
                this.parseJson(resp.Response);
            }
        }

        /// <summary>
        /// Fonction to parse the json response
        /// </summary>
        /// <param name="doc">doc to parse</param>
        public abstract void parseJson(string json);
    }
}
