using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Gandi.Domain.Api
{
    /// <summary>
    /// Business layer for Gandi access
    /// </summary>
    public class ManagerDomain : ManagerDomainAsync
    {
        /// <summary>
        /// Create a business manager to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">Api user key</param>
        public ManagerDomain(string url, string apikey) : base(url, apikey)
        {
        }

        /// <summary>
        /// Get all Domain liste
        /// </summary>
        /// <returns>id of evault if exist, else return string.Empty</returns>
        public DomainListResponse GetList()
        {
            Task<DomainListResponse> task = Task.Run(async () => await GetListAsync());
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get Domain detail
        /// </summary>
        /// <param name="fqdn">The fqdn of the Domain</param>
        /// <returns>id of evault if exist, else return string.Empty</returns>
        public DomainDetailResponse GetDetail(string fqdn)
        {
            Task<DomainDetailResponse> task = Task.Run(async () => await GetDetailAsync(fqdn));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update domain Detail 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="zone_uuid">zone identifiant </param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse UpdateZone(string fqdn,string zone_uuid)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await UpdateZoneAsync(fqdn, zone_uuid));
            task.Wait();
            return task.Result;
        }
        
        /// <summary>
        /// Get domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public RecordListResponse GetAllRecords(string fqdn)
        {
            Task<RecordListResponse> task = Task.Run(async () => await GetAllRecordsAsync(fqdn));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Create domain 
        /// </summary>
        /// <param name="domain">The data of the domain</param>>
        /// <returns>an error code and the json response</returns>
        public DomainCreateResponse Create(DomainDto domain)
        {
            Task<DomainCreateResponse> task = Task.Run(async () => await CreateAsync(domain));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Create domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse CreateRecords(string fqdn, RecordDto record)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await CreateRecordsAsync(fqdn, record));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse UpdateAllRecords(string fqdn, List<RecordDto> records)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await UpdateAllRecordsAsync(fqdn, records));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update domain Records with name in parameter 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse UpdateNamedRecords(string fqdn, string name, List<RecordDto> records)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await UpdateNamedRecordsAsync(fqdn, name, records));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update one domain Records in parameter 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse UpdateOneRecords(string fqdn, string name, string type, RecordDto record)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await UpdateOneRecordsAsync(fqdn, name, type, record));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get domain Records with name in parameter 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public RecordListResponse GetNamedRecords(string fqdn, string name)
        {
            Task<RecordListResponse> task = Task.Run(async () => await GetNamedRecordsAsync(fqdn, name));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get One domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public RecordDetailResponse GetOneRecords(string fqdn, string name, string type)
        {
            Task<RecordDetailResponse> task = Task.Run(async () => await GetOneRecordsAsync(fqdn, name, type));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete One domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse DeleteOneRecords(string fqdn, string name, string type)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await DeleteOneRecordsAsync(fqdn, name, type));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete Named domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse DeleteNamedRecords(string fqdn, string name)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await DeleteNamedRecordsAsync(fqdn, name));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Delete all domain Records 
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public DomainUpdateResponse DeleteAllRecords(string fqdn)
        {
            Task<DomainUpdateResponse> task = Task.Run(async () => await DeleteAllRecordsAsync(fqdn));
            task.Wait();
            return task.Result;
        }
    }
}
