using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBGenresResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<TMDBGenreResponse> genres { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
