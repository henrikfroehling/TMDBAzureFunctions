namespace Models.Database
{
    public class DailyDownloads
    {
        public int Id { get; set; }

        public string CollectionIdsCompressedBase64JSONData { get; set; }

        public string NetworkIdsCompressedBase64JSONData { get; set; }

        public string KeywordIdsCompressedBase64JSONData { get; set; }
    }
}
