using Api.Gandi.Base;
using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Gandi.Domain.Api
{
    /// <summary>
    /// Business layer for Gandi access asynchornously
    /// </summary>
    public class ManagerDomainAsync : IDisposable
    {
        protected ApiClientDomain _client;

        public string EvaultId { get; set; }

        /// <summary>
        /// Create a business manager to acces Gandi api
        /// </summary>
        /// <param name="url">Url of Gandi api</param>
        /// <param name="apikey">user api key</param>
        public ManagerDomainAsync(string url, string apikey)
        {
            _client = new ApiClientDomain(url, apikey);
        }

        /// <summary>
        /// Get Domain list
        /// </summary>
        /// <returns>False if error or if id doesn't exist else true </returns>
        public async Task<DomainListResponse> GetListAsync()
        {
            ApiResponse resp = await _client.GetListAsync();
            DomainListResponse retour = new DomainListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get Domain detail
        /// </summary>
        /// <param name="fqdn">The fqdn of the Domain</param>
        /// <returns>False if error or if id doesn't exist else true </returns>
        public async Task<DomainDetailResponse> GetDetailAsync(string fqdn)
        {
            ApiResponse resp = await _client.GetDetailAsync(fqdn);
            DomainDetailResponse retour = new DomainDetailResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Create a domain asynchronously
        /// </summary>
        /// <param name="domain">Content to create domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainCreateResponse> CreateAsync(DomainDto domain)
        {
            ApiResponse resp = await _client.CreateAsync(domain);
            DomainCreateResponse retour = new DomainCreateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// update domain zone asynchronously
        /// </summary>
        /// <param name="fqdn">Domain identifiant</param>
        /// <param name="zoneUuid">Zone identifant</param>
        /// <returns>an code of Gandi call and the xml response</returns>
        public async Task<DomainUpdateResponse> UpdateZoneAsync(string fqdn, string zoneUuid)
        {
            ApiResponse resp = await _client.UpdateZoneAsync(fqdn, zoneUuid);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordListResponse> GetAllRecordsAsync(string fqdn)
        {
            ApiResponse resp = await _client.GetAllRecordsAsync(fqdn);
            RecordListResponse retour = new RecordListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Create domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="record">the record data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> CreateRecordsAsync(string fqdn, RecordDto record)
        {
            ApiResponse resp = await _client.CreateRecordsAsync(fqdn, record);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> UpdateAllRecordsAsync(string fqdn, List<RecordDto> records)
        {
            ApiResponse resp = await _client.UpdateAllRecordsAsync(fqdn, records);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update domain Records with name in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="records">All records data </param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> UpdateNamedRecordsAsync(string fqdn, string name, List<RecordDto> records)
        {
            ApiResponse resp = await _client.UpdateNamedRecordsAsync(fqdn, name, records);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Update one domain Records in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <param name="record">records data</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> UpdateOneRecordsAsync(string fqdn, string name, string type, RecordDto record)
        {
            ApiResponse resp = await _client.UpdateOneRecordsAsync(fqdn, name, type, record);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get domain Records with name in parameter asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordListResponse> GetNamedRecordsAsync(string fqdn, string name)
        {
            ApiResponse resp = await _client.GetNamedRecordsAsync(fqdn, name);
            RecordListResponse retour = new RecordListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get One domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<RecordDetailResponse> GetOneRecordsAsync(string fqdn, string name, string type)
        {
            ApiResponse resp = await _client.GetOneRecordsAsync(fqdn, name, type);
            RecordDetailResponse retour = new RecordDetailResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete One domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <param name="type">Type of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> DeleteOneRecordsAsync(string fqdn, string name, string type)
        {
            ApiResponse resp = await _client.DeleteOneRecordsAsync(fqdn, name, type);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete Named domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <param name="name">Name of Records</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> DeleteNamedRecordsAsync(string fqdn, string name)
        {
            ApiResponse resp = await _client.DeleteNamedRecordsAsync(fqdn, name);
            DomainUpdateResponse retour = new DomainUpdateResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Delete all domain Records asynchronously
        /// </summary>
        /// <param name="fqdn">The fqdn of the domain</param>
        /// <returns>an error code and the json response</returns>
        public async Task<DomainUpdateResponse> DeleteAllRecordsAsync(string fqdn)
        {
            ApiResponse resp = await _client.DeleteAllRecordsAsync(fqdn);
            DomainUpdateResponse retour = new DomainUpdateResponse();
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
