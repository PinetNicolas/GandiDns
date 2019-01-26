using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gandi.Zone.Api
{
    public class ApiClientZone : ApiClientCore
    {
        /// <summary>
        /// Create a client to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">user api key</param>
        public ApiClientZone(string url, string apikey) : base(url,apikey)
        {
        }

        /// <summary>
        /// Get zone list asynchronously
        /// </summary>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetListAsync()
        {
            string request = "zones";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Create a zone asynchronously
        /// </summary>
        /// <param name="toCreate">Zone data to create</param>
        /// <param name="sharingId">Sharing_id if need</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> CreateAsync(ZoneDto toCreate, string sharingId = null)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(toCreate), Encoding.Default, "application/json");
            string request = "zones";
            if (!string.IsNullOrEmpty(sharingId))
            {
                request += "?sharing_id=" + sharingId;
            }
            return await RequestPostAsync(request, content);
        }

        /// <summary>
        /// Get zone Detail asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetDetailAsync(string uuid)
        {
            string request = "zones/" + uuid;
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Update zone Detail asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="zone">the zone data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateDetailAsync(string uuid, ZoneDto zone)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(zone), Encoding.Default, "application/json");
            string request = "zones/" + uuid;
            return await RequestPatchAsync(request, content);
        }

        /// <summary>
        /// Delete zone Detail asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteAsync(string uuid)
        {
            string request = "zones/" + uuid;
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Attach Domain to a zone asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="fqdn">Domain name</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> AttachDomainAsync(string uuid, string fqdn)
        {
            string request = $"zones/{uuid}/domains/{fqdn}";
            return await RequestPostAsync(request, new StringContent("") );
        }
        
        /// <summary>
        /// Get zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetAllRecordsAsync(string uuid)
        {
            string request = $"zones/{uuid}/records";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Create zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> CreateRecordsAsync(string uuid, RecordDto record)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(record),Encoding.Default, "application/json");
                string request = $"zones/{uuid}/records";
            return await RequestPostAsync(request, content);
        }

        /// <summary>
        /// Update zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateAllRecordsAsync(string uuid, List<RecordDto> records)
        {
            StringContent content = new StringContent("{\"items\":"+JsonConvert.SerializeObject(records)+"}", Encoding.Default, "application/json");
            string request = $"zones/{uuid}/records";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Update zone Records with name in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateNamedRecordsAsync(string uuid, string name, List<RecordDto> records)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(records), Encoding.Default, "application/json");
            string request = $"zones/{uuid}/records/{name}";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Update one zone Records in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> UpdateOneRecordsAsync(string uuid, string name, string type, RecordDto record)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(record), Encoding.Default, "application/json");
            string request = $"zones/{uuid}/records/{name}/{type}";
            return await RequestPutAsync(request, content);
        }

        /// <summary>
        /// Get zone Records with name in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetNamedRecordsAsync(string uuid, string name)
        {
            string request = $"zones/{uuid}/records/{name}";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get One zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetOneRecordsAsync(string uuid, string name,string type)
        {
            string request = $"zones/{uuid}/records/{name}/{type}";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Delete One zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteOneRecordsAsync(string uuid, string name, string type)
        {
            string request = $"zones/{uuid}/records/{name}/{type}";
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Delete Named zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteNamedRecordsAsync(string uuid, string name)
        {
            string request = $"zones/{uuid}/records/{name}";
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Delete all zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> DeleteAllRecordsAsync(string uuid)
        {
            string request = $"zones/{uuid}/records";
            return await RequestDeleteAsync(request);
        }

        /// <summary>
        /// Create zone Snapshot asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="content">Http request body content</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> CreateSnapshotAsync(string uuid)
        {
            string request = $"zones/{uuid}/snapshots";
            return await RequestPostAsync(request, new StringContent(""));
        }

        /// <summary>
        /// Get All zone Snapshots asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetSnapshotsAsync(string uuid)
        {
            string request = $"zones/{uuid}/snapshots";
            return await RequestGetAsync(request);
        }

        /// <summary>
        /// Get One zone Snapshots asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ApiResponse> GetOneSnapshotAsync(string uuid, string snapshotId)
        {
            string request = $"zones/{uuid}/snapshots/{snapshotId}";
            return await RequestGetAsync(request);
        }
    }
}