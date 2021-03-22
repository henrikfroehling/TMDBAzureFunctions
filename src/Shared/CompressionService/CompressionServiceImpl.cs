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
            using var memory = new MemoryStream(jsonData);
            using var compressedMemory = new MemoryStream();
            using var gzip = new GZipStream(compressedMemory, CompressionMode.Compress);
            memory.CopyTo(gzip);
            byte[] compressedData = compressedMemory.ToArray();
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
            using var memoryBuffer = new MemoryStream();
            gzip.CopyTo(memoryBuffer);
            byte[] jsonData = memoryBuffer.ToArray();
            return Encoding.UTF8.GetString(jsonData);
        }
    }
}
