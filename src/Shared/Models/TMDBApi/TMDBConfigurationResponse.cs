using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBConfigurationResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public TMDBConfigurationImagesResponse images { get; set; }

        public List<string> change_keys { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
