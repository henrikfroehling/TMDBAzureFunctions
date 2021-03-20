using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBConfigurationImagesResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public string base_url { get; set; }

        public string secure_base_url { get; set; }

        public List<string> backdrop_sizes { get; set; }

        public List<string> logo_sizes { get; set; }

        public List<string> poster_sizes { get; set; }

        public List<string> profile_sizes { get; set; }

        public List<string> still_sizes { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
