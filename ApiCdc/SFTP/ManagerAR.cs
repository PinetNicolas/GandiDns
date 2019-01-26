using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ApiCdc
{
    public class ManagerAR : IDisposable
    {
        private readonly SftpClient _sftpClient = null; 

        public ManagerAR(string host, int port, string username, string password)
        {
            _sftpClient = new SftpClient(host, port, username, password);
        }

        public List<string> GetFile()
        {
            List<string> retour = new List<string>();
            try
            {
                _sftpClient.Connect();
                foreach (SftpFile sfile in _sftpClient.ListDirectory("."))
                {
                    if (sfile.IsDirectory)
                        continue;

                    string tempDirectory = Path.GetTempPath();
                    using (MemoryStream writeStream = new MemoryStream())
                    {
                        _sftpClient.DownloadFile(sfile.FullName, writeStream);

                        ZipFile zfile = new ZipFile(writeStream);
                        foreach (ZipEntry zipEntry in zfile)
                        {
                            if (!zipEntry.IsFile)
                            {
                                continue;
                            }

                            string entryFileName = zipEntry.Name;
                            // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                            // Optionally match entrynames against a selection list here to skip as desired.
                            // The unpacked length is available in the zipEntry.Size property.

                            byte[] buffer = new byte[4096];     // 4K is optimum
                            Stream zipStream = zfile.GetInputStream(zipEntry);

                            // Manipulate the output filename here as desired.
                            string fullZipToPath = Path.Combine(tempDirectory, entryFileName);

                            retour.Add(fullZipToPath);
                            string directoryName = Path.GetDirectoryName(fullZipToPath);
                            if (directoryName.Length > 0)
                                Directory.CreateDirectory(directoryName);

                            // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                            // of the file, but does not waste memory.
                            // The "using" will close the stream even if an exception occurs.
                            using (FileStream streamWriter = File.Create(fullZipToPath))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }
                        }
                    }
                }
            }
            finally
            {
                _sftpClient.Disconnect();
            }

            return retour;
        }

        public void lecturearchive(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("arki", @"http://www.arkhineo.fr/CFE/metadata/1.1");
            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.SelectNodes("arki:functional-ra/arki:sealing/arki:sum-up/arki:chaining/arki:archive-id", ns);
           
        }

        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                _sftpClient.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

    }
}
