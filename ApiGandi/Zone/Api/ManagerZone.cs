using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using Api.Gandi.Snapshot.Response;
using Api.Gandi.Zone.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Gandi.Zone.Api
{
    /// <summary>
    /// Business layer for Gandi access
    /// </summary>
    public class ManagerZone : ManagerZoneAsync
    {
        /// <summary>
        /// Create a business manager to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">Api user key</param>
        public ManagerZone(string url, string apikey) : base(url, apikey)
        {
        }

        /// <summary>
        /// Get all zone liste
        /// </summary>
        /// <returns>id of evault if exist, else return string.Empty</returns>
        public ZoneListResponse GetList()
        {
            Task<ZoneListResponse> task = Task.Run(async () => await GetListAsync());
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get zone detail
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>id of evault if exist, else return string.Empty</returns>
        public ZoneDetailResponse GetDetail(string uuid)
        {
            Task<ZoneDetailResponse> task = Task.Run(async () => await GetDetailAsync(uuid));
            task.Wait();
            return task.Result;
        }


        /// <summary>
        /// Create a zone 
        /// </summary>
        /// <param name="zone">Content to create zone</param>
        /// <param name="sharingId">Sharing_id if need</param>
        /// <returns>an error code and the json response</returns>
        public ZoneCreateResponse Create(ZoneDto zone, string sharingId = null)
        {
            Task<ZoneCreateResponse> task = Task.Run(async () => await CreateAsync(zone,sharingId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update zone Detail 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="zone">the zone data </param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse UpdateDetail(string uuid, ZoneDto zone)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await UpdateDetailAsync(uuid, zone));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete zone Detail 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse Delete(string uuid)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await DeleteAsync(uuid));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Attach Domain to a zone 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="fqdn">Domain name</param>
        /// <returns>an error code and the json response</returns>
        public DomainDetailResponse AttachDomain(string uuid, string fqdn)
        {
            Task<DomainDetailResponse> task = Task.Run(async () => await AttachDomainAsync(uuid, fqdn));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public RecordListResponse GetAllRecords(string uuid)
        {
            Task<RecordListResponse> task = Task.Run(async () => await GetAllRecordsAsync(uuid));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Create zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse CreateRecords(string uuid, RecordDto record)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await CreateRecordsAsync(uuid, record));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse UpdateAllRecords(string uuid, List<RecordDto> records)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await UpdateAllRecordsAsync(uuid, records));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update zone Records with name in parameter 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse UpdateNamedRecords(string uuid, string name, List<RecordDto> records)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await UpdateNamedRecordsAsync(uuid, name, records));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update one zone Records in parameter 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse UpdateOneRecords(string uuid, string name, string type, RecordDto record)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await UpdateOneRecordsAsync(uuid, name, type, record));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get zone Records with name in parameter 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public RecordListResponse GetNamedRecords(string uuid, string name)
        {
            Task<RecordListResponse> task = Task.Run(async () => await GetNamedRecordsAsync(uuid, name));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get One zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public RecordDetailResponse GetOneRecords(string uuid, string name, string type)
        {
            Task<RecordDetailResponse> task = Task.Run(async () => await GetOneRecordsAsync(uuid, name, type));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete One zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse DeleteOneRecords(string uuid, string name, string type)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await DeleteOneRecordsAsync(uuid, name, type));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete Named zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse DeleteNamedRecords(string uuid, string name)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await DeleteNamedRecordsAsync(uuid, name));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete all zone Records 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse DeleteAllRecords(string uuid)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await DeleteAllRecordsAsync(uuid));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Create zone Snapshot 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <param name="content">Http request body content</param>
        /// <returns>an error code and the json response</returns>
        public ZoneUpdateResponse CreateSnapshot(string uuid)
        {
            Task<ZoneUpdateResponse> task = Task.Run(async () => await CreateSnapshotAsync(uuid));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get All zone Snapshots 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public SnapshotListResponse GetSnapshots(string uuid)
        {
            Task<SnapshotListResponse> task = Task.Run(async () => await GetSnapshotsAsync(uuid));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get One zone Snapshots 
        /// </summary>
        /// <param name="uuid">The uuid of the zone</param>
        /// <returns>an error code and the json response</returns>
        public SnapshotDetailResponse GetOneSnapshot(string uuid, string snapshotId)
        {
            Task<SnapshotDetailResponse> task = Task.Run(async () => await GetOneSnapshotAsync(uuid, snapshotId));
            task.Wait();
            return task.Result;
        }
    }
}
