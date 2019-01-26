using System.Threading.Tasks;

namespace ApiCdc
{
    public interface ICdcClient 
    {

        /// <summary>
        /// Get evault list
        /// </summary>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetEvaultList();

        /// <summary>
        /// Get evault list asynchronously
        /// </summary>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetEvaultListAsync();

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetSectionList(string evaultId);

        /// <summary>
        /// Get evault sections list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetSectionListAsync(string evaultId);

        /// <summary>
        /// Get archive list synchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchiveList(string evaultId, ArchiveListRequest req);

        /// <summary>
        /// Get archive list asynchronously
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveListAsync(string evaultId, ArchiveListRequest req);

        /// <summary>
        /// Get Archive status synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchiveStatus(string archiveId);

        /// <summary>
        /// Get Archive status asynchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveStatusAsync(string archiveId);

        /// <summary>
        /// Get Archive file Data synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchiveData(string archiveId);

        /// <summary>
        /// Get Archive file Data asynchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveDataAsync(string archiveId);

        /// <summary>
        /// Get Archive metadata descriptive synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchiveDublinCore(string archiveId);

        /// <summary>
        /// Get Archive metadata descriptive asynchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveDublinCoreAsync(string archiveId);

        /// <summary>
        /// Get Archive metadata applicative synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchiveMetadata(string archiveId);

        /// <summary>
        /// Get Archive metadata applicative asynchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveMetadataAsync(string archiveId);

        /// <summary>
        /// Get Archive Details synchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse GetArchive(string archiveId);

        /// <summary>
        /// Get Archive Details asynchronously
        /// </summary>
        /// <param name="archiveId">Archive identifiant</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> GetArchiveAsync(string archiveId);

        /// <summary>
        /// Put a file in cdc
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        CdcResponse PutArchive(string evaultId, SendFileRequest req);

        /// <summary>
        /// Put a file in cdc
        /// </summary>
        /// <param name="evaultId">Evault id</param>
        /// <param name="req">All data for request</param>
        /// <returns>an code of cdc call and the xml response</returns>
        Task<CdcResponse> PutArchiveAsync(string evaultId,  SendFileRequest req);


    }
}
