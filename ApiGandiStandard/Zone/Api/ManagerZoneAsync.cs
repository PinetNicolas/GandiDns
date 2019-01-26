using Api.Gandi.Base;
using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using Api.Gandi.Snapshot.Response;
using Api.Gandi.Zone.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Gandi.Zone.Api
{
    /// <summary>
    /// Business layer for Gandi access asynchornously
    /// </summary>
    public class ManagerZoneAsync : IDisposable
    {
        protected ApiClientZone _client;

        public string EvaultId { get; set; }

        /// <summary>
        /// Create a business manager to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">user api key</param>
        public ManagerZoneAsync(string url, string apikey)
        {
            _client = new ApiClientZone(url, apikey);
        }

        /// <summary>
        /// Get zone list
        /// </summary>
        /// <returns>False if error or if id doesn't exist else true </returns>
        public async Task<ZoneListResponse> GetListAsync()
        {
            ApiResponse resp = await _client.GetListAsync();
            ZoneListResponse retour = new ZoneListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get zone detail
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>False if error or if id doesn't exist else true </returns>
        public async Task<ZoneDetailResponse> GetDetailAsync(string uuid)
        {
            ApiResponse resp = await _client.GetDetailAsync(uuid);
            ZoneDetailResponse retour = new ZoneDetailResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Create a zone asynchronously
        /// </summary>
        /// <param name="zone">Content to create zone</param>
        /// <param name="sharingId">Sharing_id if need</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneCreateResponse> CreateAsync(ZoneDto zone, string sharingId = null)
        {
            ApiResponse resp = await _client.CreateAsync(zone, sharingId);
            ZoneCreateResponse retour = new ZoneCreateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update zone Detail asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="zone">the zone data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> UpdateDetailAsync(string uuid, ZoneDto zone)
        {
            ApiResponse resp = await _client.UpdateDetailAsync(uuid,zone);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete zone Detail asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> DeleteAsync(string uuid)
        {
            ApiResponse resp = await _client.DeleteAsync(uuid);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Attach Domain to a zone asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="fqdn">Domain name</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainDetailResponse> AttachDomainAsync(string uuid, string fqdn)
        {
            ApiResponse resp = await _client.AttachDomainAsync(uuid, fqdn);
            DomainDetailResponse retour = new DomainDetailResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordListResponse> GetAllRecordsAsync(string uuid)
        {
            ApiResponse resp = await _client.GetAllRecordsAsync(uuid);
            RecordListResponse retour = new RecordListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Create zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> CreateRecordsAsync(string uuid, RecordDto record)
        {
            ApiResponse resp = await _client.CreateRecordsAsync(uuid, record);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> UpdateAllRecordsAsync(string uuid, List<RecordDto> records)
        {
            ApiResponse resp = await _client.UpdateAllRecordsAsync(uuid, records);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update zone Records with name in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> UpdateNamedRecordsAsync(string uuid, string name, List<RecordDto> records)
        {
            ApiResponse resp = await _client.UpdateNamedRecordsAsync(uuid, name, records);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update one zone Records in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> UpdateOneRecordsAsync(string uuid, string name, string type, RecordDto record)
        {
            ApiResponse resp = await _client.UpdateOneRecordsAsync(uuid, name, type, record);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get zone Records with name in parameter asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordListResponse> GetNamedRecordsAsync(string uuid, string name)
        {
            ApiResponse resp = await _client.GetNamedRecordsAsync(uuid, name);
            RecordListResponse retour = new RecordListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get One zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordDetailResponse> GetOneRecordsAsync(string uuid, string name, string type)
        {
            ApiResponse resp = await _client.GetOneRecordsAsync(uuid, name, type);
            RecordDetailResponse retour = new RecordDetailResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete One zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> DeleteOneRecordsAsync(string uuid, string name, string type)
        {
            ApiResponse resp = await _client.DeleteOneRecordsAsync(uuid, name, type);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete Named zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> DeleteNamedRecordsAsync(string uuid, string name)
        {
            ApiResponse resp = await _client.DeleteNamedRecordsAsync(uuid, name);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete all zone Records asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> DeleteAllRecordsAsync(string uuid)
        {
            ApiResponse resp = await _client.DeleteAllRecordsAsync(uuid);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Create zone Snapshot asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="content">Http request body content</param>
        /// <returns>an error code and the json response</returns>
        public async Task<ZoneUpdateResponse> CreateSnapshotAsync(string uuid)
        {
            ApiResponse resp = await _client.CreateSnapshotAsync(uuid);
            ZoneUpdateResponse retour = new ZoneUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get All zone Snapshots asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<SnapshotListResponse> GetSnapshotsAsync(string uuid)
        {
            ApiResponse resp = await _client.GetSnapshotsAsync(uuid);
            SnapshotListResponse retour = new SnapshotListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get One zone Snapshots asynchronously
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public async Task<SnapshotDetailResponse> GetOneSnapshotAsync(string uuid, string snapshotId)
        {
            ApiResponse resp = await _client.GetOneSnapshotAsync(uuid, snapshotId);
            SnapshotDetailResponse retour = new SnapshotDetailResponse();
            retour.Load(resp);
            return retour;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_client is IDisposable)
                    ((IDisposable) _client).Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
