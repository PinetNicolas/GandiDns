using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCdc
{
    /// <summary>
    /// Business layer for cdc access
    /// </summary>
    public class ManagerCdc : ManagerCdcAsync
    {
        /// <summary>
        /// Create a business manager to acces CDC api
        /// </summary>
        /// <param name="url">Url of cdc api</param>
        /// <param name="login">user login to access api</param>
        /// <param name="password">user password to access api</param>
        /// <param name="evaultId">Identifiant of evault in CDC</param>
        public ManagerCdc(string url, string login, string password, string evaultId) : base(url, login, password, evaultId)
        {
        }

        /// <summary>
        /// Create a business manager to acces CDC api
        /// </summary>
        /// <param name="client">a cdc client configure</param>
        /// <param name="evaultId">Identifiant of evault in CDC</param>
        public ManagerCdc(ICdcClient client, string evaultId):base(client,evaultId)
        {
        }

        /// <summary>
        /// Find an evault by his name
        /// </summary>
        /// <returns>id of evault if exist, else return string.Empty</returns>
        public EvaultListResponse GetEvaultList()
        {
            Task<EvaultListResponse> task = Task.Run(async () => await GetEvaultListAsync());
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Find section by its name
        /// </summary>
        /// <returns>id of section if exist, else string.Empty</returns>
        public SectionListResponse GetSectionList()
        {
            Task<SectionListResponse> task = Task.Run(async () => await GetSectionListAsync());
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Find all archive in sections
        /// </summary>
        /// <param name="req">The request with parameter</param>
        /// <returns>id of section if exist, else string.Empty</returns>
        public ArchiveListResponse GetArchiveList(ArchiveListRequest req)
        {
            Task<ArchiveListResponse> task = Task.Run(async () => await GetArchiveListAsync(req));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Send file
        /// </summary>
        /// <param name="req">The request with parameter</param>
        /// <returns>a CDC response with ack and error message</returns>
        public SendFileResponse SendFile(SendFileRequest req)
        {
            Task<SendFileResponse> task = Task.Run(async () => await SendFileAsync(req));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get an archive file data
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public DocumentResponse GetArchiveData(string archiveId)
        {
            Task<DocumentResponse> task = Task.Run(async () => await GetArchiveDataAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get an archive metadata
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public ArchiveMetadataResponse GetArchiveMetadata(string archiveId)
        {
            Task<ArchiveMetadataResponse> task = Task.Run(async () => await GetArchiveMetadataAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get an archive dublin core informations
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public ArchiveDublinCoreResponse GetArchiveDublinCore(string archiveId)
        {
            Task<ArchiveDublinCoreResponse> task = Task.Run(async () => await GetArchiveDublinCoreAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get an archive status
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public ArchiveStatusResponse GetArchiveStatus(string archiveId)
        {
            Task<ArchiveStatusResponse> task = Task.Run(async () => await GetArchiveStatusAsync(archiveId));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Get an archive details
        /// </summary>
        /// <param name="archiveId">the id of archive</param>
        /// <returns>a CDC response with ack and error message</returns>
        public ArchiveResponse GetArchive(string archiveId)
        {
            Task<ArchiveResponse> task = Task.Run(async () => await GetArchiveAsync(archiveId));
            task.Wait();
            return task.Result;
        }
    }
}
