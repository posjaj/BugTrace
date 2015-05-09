using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace JAJ.WinServer
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract(IsOneWay = true)]
        void UploadFile(TransferFileData request);

        [OperationContract]
        long GetUploadFileInfo(string id);

        [OperationContract]
        Stream DowndloadFile(string filePath);

    }
    [MessageContract]
    public class TransferFileData
    {
        [MessageHeader]
        public string FileType { get; set; }
        [MessageHeader]
        public string FileName { get; set; }
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public string FileUniqueID { get; set; }
        [MessageHeader]
        public string oldFileName { get; set; }
        [MessageBodyMember]
        public Stream FileData { get; set; }
    } 
}
