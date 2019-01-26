using System;
using System.Threading.Tasks;

namespace ApiCdc
{
    /// <summary>
    /// Business layer for cdc access asynchornously
    /// </summary>
    public class ManagerCdcAsync : IDisposable
    {
        protected ICdcClient _client;

        public string EvaultId { get; set; }

        /// <summary>
        /// Create a business manager to acces CDC api
        /// </summary>
        /// <param name="url">Url of cdc api</param>
        /// <param name="login">user login to access api</param>
        /// <param name="password">user password to access api</param>
        /// <param name="evaultId">Identifiant of evault in CDC</param>
        public ManagerCdcAsync(string url, string login, string password, string evaultId)
        {
            _client = new CdcClient(url,login,password);
            EvaultId = evaultId;
        }

        /// <summary>
        /// Create a business manager to acces CDC api
        /// </summary>
        /// <param name="client">a cdc client configure</param>
        /// <param name="evaultId">Identifiant of evault in CDC</param>
        public ManagerCdcAsync(ICdcClient client, string evaultId)
        {
            _client = client;
            EvaultId = evaultId;
        }

        /// <summary>
        /// Check if evault id is correct and exist in cdc
        /// </summary>
        /// <returns>False if error or if id doesn't exist else true </returns>
        public async Task<EvaultListResponse> GetEvaultListAsync()
        {
            CdcResponse resp = await _client.GetEvaultListAsync();
            EvaultListResponse retour = new EvaultListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Find section by its name
        /// </summary>
        /// <returns>id of section if exist, else string.Empty</returns>
        public async Task<SectionListResponse> GetSectionListAsync()
        {
            CdcResponse resp = await _client.GetSectionListAsync(EvaultId);
            SectionListResponse retour = new SectionListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Find all archive in sections
        /// </summary>
        /// <param name="req">The request with parameter</param>
        /// <returns>id of section if exist, else string.Empty</returns>
        public async Task<ArchiveListResponse> GetArchiveListAsync(ArchiveListRequest req)
        {
            CdcResponse resp = await _client.GetArchiveListAsync(EvaultId, req);
            ArchiveListResponse retour = new ArchiveListResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Send file
        /// </summary>
        /// <param name="req">The request with parameter</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<SendFileResponse> SendFileAsync(SendFileRequest req)
        {
            CdcResponse resp = await _client.PutArchiveAsync(EvaultId, req);
            SendFileResponse retour = new SendFileResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get an archive file data
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<DocumentResponse> GetArchiveDataAsync(string archiveId)
        {
            CdcResponse resp = await _client.GetArchiveDataAsync(archiveId);
            DocumentResponse retour = new DocumentResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get an archive metadata
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<ArchiveMetadataResponse> GetArchiveMetadataAsync(string archiveId)
        {
            CdcResponse resp = await _client.GetArchiveMetadataAsync(archiveId);
            ArchiveMetadataResponse retour = new ArchiveMetadataResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get an archive dublin core informations
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<ArchiveDublinCoreResponse> GetArchiveDublinCoreAsync(string archiveId)
        {
            CdcResponse resp = await _client.GetArchiveDublinCoreAsync(archiveId);
            ArchiveDublinCoreResponse retour = new ArchiveDublinCoreResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get an archive status
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<ArchiveStatusResponse> GetArchiveStatusAsync(string archiveId)
        {
            CdcResponse resp = await _client.GetArchiveStatusAsync(archiveId);
            ArchiveStatusResponse retour = new ArchiveStatusResponse();
            retour.Load(resp);
            return retour;
        }

        /// <summary>
        /// Get an archive details
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public async Task<ArchiveResponse> GetArchiveAsync(string archiveId)
        {
            CdcResponse resp = await _client.GetArchiveAsync(archiveId);
            ArchiveResponse retour = new ArchiveResponse();
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
