using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace CompressionService
{
    public class CompressionServiceImpl : ICompressionService
    {
        public string CompressJSONAsBase64(string json)
        {
            byte[] jsonData = Encoding.UTF8.GetBytes(json);
            using var memory = new MemoryStream();
            using var gzip = new GZipStream(memory, CompressionMode.Compress, true);
            gzip.Write(jsonData, 0, jsonData.Length);
            byte[] compressedData = memory.ToArray();
            return Convert.ToBase64String(compressedData);
        }

        public string DecompressBase64ToJSON(string data)
        {
            byte[] compressedData = Convert.FromBase64String(data);
            return DecompressToJson(compressedData);
        }

        public string DecompressToJson(byte[] compressedData)
        {
            using var memory = new MemoryStream(compressedData);
            using var gzip = new GZipStream(memory, CompressionMode.Decompress);

            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];

            using var memoryBuffer = new MemoryStream();
            {
                int count = 0;

                do
                {
                    count = gzip.Read(buffer, 0, bufferSize);

                    if (count > 0)
                        memoryBuffer.Write(buffer, 0, count);
                }
                while (count > 0);
            }

            byte[] jsonData = memoryBuffer.ToArray();
            return Encoding.UTF8.GetString(jsonData);
        }
    }
}
