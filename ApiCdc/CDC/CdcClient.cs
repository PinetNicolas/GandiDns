using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiCdc
{
    public class CdcClient: ICdcClient, IDisposable
    {
        HttpClient _clientweb = new HttpClient();
        string _url = string.Empty;
        string _credentials = string.Empty;

        /// <summary>
        /// Create a client to acces CDC api
        /// </summary>
        /// <param name="url">Url of cdc api</param>
        /// <param name="login">user login to access api</param>
        /// <param name="password">user password to access api</param>
        public CdcClient(string url,string login, string password)
        {
            _url = url;
            byte[] byteArray = Encoding.ASCII.GetBytes($"{login}:{password}");
            _credentials = Convert.ToBase64String(byteArray);
            InitClient();
        }

        /// <summary>
        /// Init HttpClient for api request
        /// </summary>
        public void InitClient()
        {
            _clientweb.BaseAddress = new Uri(_url);
            _clientweb.DefaultRequestHeaders.Accept.Clear();
            _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _clientweb.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);
        }

        /// <summary>
        /// Translate the httpstatuscode of response 
        /// in cdcResquestCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private CdcRequestCode TransHttpStatusCode(HttpStatusCode code)
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
                    return CdcRequestCode.OK;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.RequestEntityTooLarge:
                case HttpStatusCode.RequestUriTooLong:
                    return CdcRequestCode.BadRequest;
                case HttpStatusCode.NotFound:
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.Gone:

                    return CdcRequestCode.RequestUrlError;
                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.GatewayTimeout:
                    return CdcRequestCode.RequestTimeout;
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.ProxyAuthenticationRequired:
                    return CdcRequestCode.CredentialError;
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.HttpVersionNotSupported:
                    return CdcRequestCode.CdcError;
                default:
                    return CdcRequestCode.UnknowError;
            }
        }

        /// <summary>
        /// Send Asynchronous Get request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <returns>a Cdc response with data and error information</returns>
        private async Task<CdcResponse> RequestGetAsync(string url)
        {
            CdcResponse resp = new CdcResponse();
            using (HttpResponseMessage httpResponse = await _clientweb.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                resp.Response = await ReadContent(httpResponse);
                resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            }

            if (resp.Response == null && resp.ReturnCode == CdcRequestCode.OK)
            {
                resp.ReturnCode = CdcRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Read content in http response
        /// </summary>
        /// <param name="httpResponse">The http response to parse</param>
        /// <returns>XmlDocument contains in response</returns>
        private async Task<XmlDocument> ReadContent(HttpResponseMessage httpResponse)
        {
            try
            {
                // if response is not xml and filename is not empty
                // Then we have a document from cdc
                if (httpResponse.Content.Headers.ContentType.MediaType != "text/xml"
                    && httpResponse.Content.Headers.ContentDisposition != null
                    && !string.IsNullOrEmpty(httpResponse.Content.Headers.ContentDisposition.FileName))
                {
                    string xmlResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                    string fileName = httpResponse.Content.Headers.ContentDisposition.FileName.Replace("\"",string.Empty);
                    xmlResponse += "<file name=\"" + fileName + "\"";
                    xmlResponse += " mime=\"" + httpResponse.Content.Headers.ContentType.MediaType + "\">";

                    string extension = new FileInfo(fileName).Extension;
                    using (Stream streamToReadFrom = await httpResponse.Content.ReadAsStreamAsync())
                    {
                        using (MemoryStream streamToWriteTo = new MemoryStream())
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                            xmlResponse += Convert.ToBase64String(streamToWriteTo.ToArray());
                        }
                    }

                    
                    xmlResponse += "</file>";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlResponse);
                    return doc;
                }
                else
                {
                    string resultContent = await httpResponse.Content.ReadAsStringAsync();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Tools.RemoveNamespaceXml(resultContent));
                    return doc;
                }
            }
            catch(Exception e)
            {
            }

            return null;
        }

        /// <summary>
        /// Send Asynchronous Post request
        /// </summary>
        /// <param name="url">url to request</param>
        /// <param name="content">Request content</param>
        /// <returns>a Cdc response with data and error information</returns>
        private async Task<CdcResponse> RequestPostAsync(string url, HttpContent content)
        {
            CdcResponse resp = new CdcResponse();
            HttpResponseMessage httpResponse = await _clientweb.PostAsync(url, content);
            resp.Response = await ReadContent(httpResponse);
            resp.ReturnCode = TransHttpStatusCode(httpResponse.StatusCode);
            if (resp.Response == null && resp.ReturnCode == CdcRequestCode.OK)
            {
                resp.ReturnCode = CdcRequestCode.BadResponse;
            }

            return resp;
        }

        /// <summary>
        /// Get evault list
        /// </summary>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetEvaultList()
        {
            Task<CdcResponse> task = Task.Run(async () => await GetEvaultListAsync());
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get evault list asynchronously
        /// </summary>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetEvaultListAsync()
        {
            string request = "cfes";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetSectionList(string evaultId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetSectionListAsync(evaultId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetSectionListAsync(string evaultId)
        {
            string request = $"cfes/{evaultId}/sections";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchiveList(string evaultId, ArchiveListRequest req)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveListAsync(evaultId, req));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveListAsync(string evaultId, ArchiveListRequest req)
        {
            string request = $"cfes/{evaultId}/sections/{req.SectionId}/archives";
            request += req.GetParameters();
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Put a file in cdc
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse PutArchive(string evaultId, SendFileRequest req)
        {
            Task<CdcResponse> task = Task.Run(async () => await PutArchiveAsync(evaultId, req));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Put a file in cdc
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> PutArchiveAsync(string evaultId, SendFileRequest req)
        {
            string request = $"depot/cfes/{evaultId}/sections/{req.SectionId}/archives";
            return await RequestPostAsync(request, req.GetContent());
        }

        /// <summary>
        /// Get Archive status synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchiveStatus(string archiveId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveStatusAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Archive status synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveStatusAsync(string archiveId)
        {
            string request = $"cfes/archives/{archiveId}/status";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get Archive file Data synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchiveData(string archiveId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveDataAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Archive file Data synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveDataAsync(string archiveId)
        {
            string request = $"cfes/archives/{archiveId}/data-object";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get Archive metadata descriptive synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchiveDublinCore(string archiveId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveDublinCoreAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Archive metadata descriptive synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveDublinCoreAsync(string archiveId)
        {
            string request = $"cfes/archives/{archiveId}/desc";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get Archive metadata synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchiveMetadata(string archiveId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveMetadataAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Archive metadata synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveMetadataAsync(string archiveId)
        {
            string request = $"cfes/archives/{archiveId}/app";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get Archive Details synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public CdcResponse GetArchive(string archiveId)
        {
            Task<CdcResponse> task = Task.Run(async () => await GetArchiveAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Archive Details synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        public async Task<CdcResponse> GetArchiveAsync(string archiveId)
        {
            string request = $"cfes/archives/{archiveId}";
            return await RequestGetAsync(request);
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
