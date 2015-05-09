using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace JAJ.WinServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FileService : IFileService
    {
        private const int BufferLen = 4096;
        private static Dictionary<string, long> _uploadInfoDict = new Dictionary<string, long>();
        private static object _lockObj = new object();
        public void UploadFile(TransferFileData request)
        {
            var uploadFolder = System.Environment.CurrentDirectory + "\\UploadFile\\" + request.FileType;

            string fileName = request.FileUniqueID+ request.FileName;
            Stream sourceStream = request.FileData;
            FileStream targetStream = null;
            if (!sourceStream.CanRead)
            {
                throw new Exception("Invalid Stream!");
            }
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            string filePath = Path.Combine(uploadFolder, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 4K chunks  
                //and save to output stream  const int bufferLen = 4096;    
                byte[] buffer = new byte[BufferLen];
                int count = 0;
                SetFileUploadInfo(request.FileUniqueID, 0);
                while ((count = sourceStream.Read(buffer, 0, BufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                    if (request.FileSize - (int)targetStream.Length > 100000)
                    {
                        SetFileUploadInfo(request.FileUniqueID, (int)targetStream.Length);                        
                    }
                }
                SetFileUploadInfo(request.FileUniqueID, request.FileSize);
                targetStream.Close();
                sourceStream.Close();
            }
            
            if (!string.IsNullOrWhiteSpace(request.oldFileName))
            {
                try
                {                    
                    string oldFilePath = Path.Combine(uploadFolder, request.oldFileName);                   
                    File.Delete(oldFilePath);
                }
                catch (Exception ex)
                {
                    MyLog.LogError("删除历史文件错误，文件不存在",ex);
                }
            }
        }
        private void SetFileUploadInfo(string id, long savedFileCount)
        {
            lock (_lockObj)
            {
                if (_uploadInfoDict.ContainsKey(id))
                    _uploadInfoDict[id] = savedFileCount;
                else
                    _uploadInfoDict.Add(id, savedFileCount);
            }
        }
        public long GetUploadFileInfo(string id)
        {
            if (_uploadInfoDict.ContainsKey(id))
                return _uploadInfoDict[id];
            else
                return 0;
        }
        public Stream DowndloadFile(string filePath)
        {           
            if (filePath.StartsWith("\\"))
            {//传相对路径时拼上当前目录
                filePath = System.Environment.CurrentDirectory + filePath;
            }
            if (File.Exists(filePath))
            {
                return File.OpenRead(filePath);
            }
            return null;
        }
    } 
}
