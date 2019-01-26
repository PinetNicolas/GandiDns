namespace Api.Gandi.Base
{
    /// <summary>
    /// Class for Gandi response
    /// Since call is ascync we need a structure with 
    ///     Response
    ///     ErrorCode
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Error Code of resquest. If None response contains data
        /// </summary>
        public ApiRequestCode ReturnCode { get; set; }

        /// <summary>
        /// Response of request if everything is ok.
        /// ReturnCode == ErrorCode.None
        /// </summary>
        public string Response { get; set; }
    }
}
