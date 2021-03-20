using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBListResponse<T>
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<T> results { get; set; }

        public int page { get; set; }

        public int total_pages { get; set; }

        public int total_results { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
