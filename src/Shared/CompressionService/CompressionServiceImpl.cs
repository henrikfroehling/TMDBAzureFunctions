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
            using var input = new MemoryStream(jsonData);
            using var output = new MemoryStream();
            using var gzip = new GZipStream(output, CompressionMode.Compress);
            input.CopyTo(gzip);
            gzip.Close();
            byte[] compressedData = output.ToArray();
            return Convert.ToBase64String(compressedData);
        }

        public string DecompressBase64ToJSON(string data)
        {
            byte[] compressedData = Convert.FromBase64String(data);
            return DecompressToJson(compressedData);
        }

        public string DecompressToJson(byte[] compressedData)
        {
            using var input = new MemoryStream(compressedData);
            using var gzip = new GZipStream(input, CompressionMode.Decompress);
            using var output = new MemoryStream();
            gzip.CopyTo(output);
            gzip.Close();
            byte[] jsonData = output.ToArray();
            return Encoding.UTF8.GetString(jsonData);
        }
    }
}
