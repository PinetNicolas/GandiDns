
using System.Collections.Generic;

namespace ApiCdc.SFTP
{
    public class Ack
    {
        /// <summary>
        /// The path in sftp ressource
        /// </summary>
        public string SftpFile { get; set; }

        /// <summary>
        /// liste of file in zip ack
        /// </summary>
        public List<string> FileInArchive { get; set; }
    }
}
