using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Gandi.Base
{
    public class ApiClientCore : IDisposable
    {
        HttpClient _clientweb = new HttpClient();
        string _url = string.Empty;
        string _credentials = string.Empty;

        /// <summary>
        /// Create a client to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">user api key</param>
        public ApiClientCore(string url, string apikey)
        {
            _url = url;
            _credentials = apikey;
            InitClient();
        }

        /// <summary>
        /// Init HttpClient for api request
        /// </summary>
        public void InitClient()
        {
            _clientweb.BaseAddress = new Uri(_url);
            _clientweb.DefaultRequestHeaders.Accept.Clear();
            _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _clientweb.DefaultRequestHeaders.Add("X-Api-Key", _credentials);
        }

        /// <summary>
        /// Translate the httpstatuscode of response 
        /// in GandiResquestCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private ApiRequestCode TransHttpStatusCode(HttpStatusCode code)
        {
            switch (code)
            {
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                    return ApiRequestCode.OK;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.RequestEntityTooLarge:
                case HttpStatusCode.RequestUriTooLong:
                    return ApiRequestCode.BadRequest;
                case HttpStatusCode.NotFound:
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.Gone:

                    return ApiRequestCode.RequestUrlError;
                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.GatewayTimeout:
                    return ApiRequestCode.RequestTimeout;
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.ProxyAuthenticationRequired:
                    return ApiRequestCode.CredentialError;
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.HttpVersionNotSupported:
                    return ApiRequestCode.GandiError;
                default:
                    return ApiRequestCode.UnknowError;
            }
        }

        /// <summary>
        /// Send Asynchronous Get request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <returns>a Gandi response with data and error information</returns>
        protected async Task<ApiResponse> RequestGetAsync(string url)
        {
            ApiResponse resp = new ApiResponse();
            using (HttpResponseMessage httpResponse = await _clientweb.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                resp.Response = await ReadContent(httpResponse);
                resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            }

            if (resp.Response == null && resp.ReturnCode == ApiRequestCode.OK)
            {
                resp.ReturnCode = ApiRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Read content in http response
        /// </summary>
        /// <param name="httpResponse">The http response to parse</param>
        /// <returns>XmlDocument contains in response</returns>
        private async Task<string> ReadContent(HttpResponseMessage httpResponse)
        {
            try
            {
                string resultContent = await httpResponse.Content.ReadAsStringAsync();
                // XmlDocument doc = new XmlDocument();
                // doc.LoadXml(Tools.RemoveNamespaceXml(resultContent));
                return resultContent;
            }
            catch (Exception e)
            {
            }

            return null;
        }

        /// <summary>
        /// Send Asynchronous Post request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <param name="content">Request content</param>
        /// <returns>a Gandi response with data and error information</returns>
        protected async Task<ApiResponse> RequestPostAsync(string url, HttpContent content)
        {
            ApiResponse resp = new ApiResponse();
            HttpResponseMessage httpResponse = await _clientweb.PostAsync(url, content);
            resp.Response = await ReadContent(httpResponse);
            resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            if (resp.Response == null && resp.ReturnCode == ApiRequestCode.OK)
            {
                resp.ReturnCode = ApiRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Send Asynchronous Patch request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <param name="content">Request content</param>
        /// <returns>a Gandi response with data and error information</returns>
        protected async Task<ApiResponse> RequestPatchAsync(string url, HttpContent content)
        {
            ApiResponse resp = new ApiResponse();
            HttpResponseMessage httpResponse = await _clientweb.PatchAsync(url, content);
            resp.Response = await ReadContent(httpResponse);
            resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            if (resp.Response == null && resp.ReturnCode == ApiRequestCode.OK)
            {
                resp.ReturnCode = ApiRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Send Asynchronous Delete request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <returns>a response with data and error information</returns>
        protected async Task<ApiResponse> RequestDeleteAsync(string url)
        {
            ApiResponse resp = new ApiResponse();
            using (HttpResponseMessage httpResponse = await _clientweb.DeleteAsync(url))
            {
                resp.Response = await ReadContent(httpResponse);
                resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            }

            if (resp.Response == null && resp.ReturnCode == ApiRequestCode.OK)
            {
                resp.ReturnCode = ApiRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Send Asynchronous Put request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <param name="content">Request content</param>
        /// <returns>a Gandi response with data and error information</returns>
        protected async Task<ApiResponse> RequestPutAsync(string url, HttpContent content)
        {
            ApiResponse resp = new ApiResponse();
            HttpResponseMessage httpResponse = await _clientweb.PutAsync(url, content);
            resp.Response = await ReadContent(httpResponse);
            resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            if (resp.Response == null && resp.ReturnCode == ApiRequestCode.OK)
            {
                resp.ReturnCode = ApiRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clientweb.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

    }
}