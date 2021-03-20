namespace Models.TMDBApi
{
    public class TMDBCreatedByResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string name { get; set; }

        public int gender { get; set; }

        public string credit_id { get; set; }
        
        public object profile_path { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
