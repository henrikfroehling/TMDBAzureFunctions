namespace CompressionService
{
    public interface ICompressionService
    {
        string CompressJSONAsBase64(string json);

        string DecompressBase64ToJSON(string data);

        string DecompressToJson(byte[] compressedData);
    }
}
