using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gandi.Domain
{
    public class ApiClientDomain : ApiClientCore
    {
        /// <summary>
        /// Create a client to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">user api key</param>
        public ApiClientDomain(string url, string apikey) : base(url, apikey)
        {
        }

        /// <summary>
        /// Get domain list asynchronously
        /// </summary>
        /// <returns>an code of Gandi call and the xml response</returns>
        public async Task<ApiResponse> GetListAsync()
        {
            string request = $"domains";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Create a domain asynchronously
        /// </summary>
        /// <param name="content">Content to create domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> CreateAsync(DomainDto domain)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(domain), Encoding.Default, "application/json");            
            string request = "domains";
            return await RequestPostAsync(request, content);
        }

        /// <summary>
        /// Get domain Detail asynchronously
        /// </summary>
        /// <param name="fqdn">Domain identifiant</param>
        /// <returns>an code of Gandi call and the xml response</returns>
        public async Task<ApiResponse> GetDetailAsync(string fqdn)
        {
            string request = $"domains/" + fqdn;
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// update domain zone asynchronously
        /// </summary>
        /// <param name="fqdn">Domain identifiant</param>
        /// <param name="zoneUuid">Zone identifant</param>
        /// <returns>an code of Gandi call and the xml response</returns>
        public async Task<ApiResponse> UpdateZoneAsync(string fqdn, string zoneUuid)
        {
            StringContent content = new StringContent("{\"zone_uuid\":\""+zoneUuid+"\"}", Encoding.Default, "application/json");
            string request = $"domains/" + fqdn;
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetAllRecordsAsync(string fqdn)
        {
            string request = $"domains/{fqdn}/records";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Create domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> CreateRecordsAsync(string fqdn, RecordDto record)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.Default, "application/json");
            string request = $"domains/{fqdn}/records";
            return await RequestPostAsync(request, content);
        }

        /// <summary>
        /// Update domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateAllRecordsAsync(string fqdn, List<RecordDto> records)
        {
            StringContent content = new StringContent("{\"items\":" + JsonConvert.SerializeObject(records) + "}", Encoding.Default, "application/json");
            string request = $"domains/{fqdn}/records";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Update domain Records with name in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateNamedRecordsAsync(string fqdn, string name, List<RecordDto> records)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(records), Encoding.Default, "application/json");
            string request = $"domains/{fqdn}/records/{name}";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Update one domain Records in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateOneRecordsAsync(string fqdn, string name, string type, RecordDto record)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.Default, "application/json");
            string request = $"domains/{fqdn}/records/{name}/{type}";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Get domain Records with name in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetNamedRecordsAsync(string fqdn, string name)
        {
            string request = $"domains/{fqdn}/records/{name}";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get One domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetOneRecordsAsync(string fqdn, string name, string type)
        {
            string request = $"domains/{fqdn}/records/{name}/{type}";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Delete One domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteOneRecordsAsync(string fqdn, string name, string type)
        {
            string request = $"domains/{fqdn}/records/{name}/{type}";
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Delete Named domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteNamedRecordsAsync(string fqdn, string name)
        {
            string request = $"domains/{fqdn}/records/{name}";
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Delete all domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteAllRecordsAsync(string fqdn)
        {
            string request = $"domains/{fqdn}/records";
            return await RequestDeleteAsync(request);
        }
    }
}