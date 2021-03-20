using Microsoft.Extensions.Logging;
using Models.TMDB;
using Models.TMDBApi;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TMDBService.API;

namespace TMDBService
{
    public class TMDBServiceImpl : ITMDBService
    {
        private const string BASE_URL = "https://api.themoviedb.org/3";

        private const int SHOWS_COMEDY_GENRE_ID = 35;
        private const int MOVIES_COMEDY_GENRE_ID = 35;
        private const int SHOWS_DRAMA_GENRE_ID = 18;
        private const int MOVIES_DRAMA_GENRE_ID = 18;
        private const int SHOWS_ACTION_ADVENTURE_GENRE_ID = 10759;
        private const int MOVIES_ACTION_GENRE_ID = 28;
        private const int MOVIES_ADVENTURE_GENRE_ID = 12;
        private const int SHOWS_ANIMATION_GENRE_ID = 16;
        private const int MOVIES_ANIMATION_GENRE_ID = 16;
        private const int SHOWS_SCIFI_GENRE_ID = 10765;
        private const int MOVIES_SCIFI_GENRE_ID = 878;
        private const int SHOWS_CRIME_GENRE_ID = 80;
        private const int MOVIES_CRIME_GENRE_ID = 80;
        private const int SHOWS_MYSTERY_GENRE_ID = 9648;
        private const int MOVIES_MYSTERY_GENRE_ID = 9648;
        private const int MOVIES_THRILLER_GENRE_ID = 53;
        private const int MOVIES_HORROR_GENRE_ID = 27;
        private const int SHOWS_FAMILY_GENRE_ID = 10751;
        private const int MOVIES_FAMILY_GENRE_ID = 10751;
        private const int SHOWS_KIDS_GENRE_ID = 10762;
        private const int SHOWS_WESTERN_GENRE_ID = 37;
        private const int MOVIES_WESTERN_GENRE_ID = 37;
        private const int MOVIES_FANTASY_GENRE_ID = 14;
        private const int MOVIES_HISTORY_GENRE_ID = 36;
        private const int MOVIES_ROMANCE_GENRE_ID = 10749;
        private const int SHOWS_WAR_GENRE_ID = 10768;
        private const int MOVIES_WAR_GENRE_ID = 10752;
        private const int SHOWS_DOCUMENTARY_GENRE_ID = 99;
        private const int MOVIES_DOCUMENTARY_GENRE_ID = 99;

        private const int THRILLER_KEYWORD_ID = 9950;
        private const int HORROR_KEYWORD_ID = 8087;
        private const int KIDS_KEYWORD_ID = 161155;
        private const int HISTORY_KEYWORD_ID = 9682;
        private const int ROMANCE_KEYWORD_ID = 9840;
        private const int SITCOM_KEYWORD_ID = 193171;
        private const int ANTHOLOGY_KEYWORD_ID = 9706;
        private const int ANIME_KEYOWRD_ID = 210024;
        private const int TEEN_DRAMA_KEYWORD_ID = 193400;
        private const int HISTORICAL_DRAMA_KEYWORD_ID = 192772;
        private const int WORKPLACE_COMEDY_KEYWORD_ID = 210605;
        private const int MEDICAL_DRAMA_KEYWORD_ID = 208788;

        private readonly ILogger _logger;
        private readonly string _apiKey = "";
        private readonly ITMDBApiClient _tmdbApiClient;
        private bool _isInitialized;
        private readonly Configuration _configuration;
        private readonly Dictionary<int, Genre> _showGenres;
        private readonly Dictionary<int, Genre> _movieGenres;
        private readonly List<ListItem> _trendingShowsAndMovies;
        private readonly List<ListItem> _comedyShowsAndMovies;
        private readonly List<ListItem> _dramaShowsAndMovies;
        private readonly List<ListItem> _actionAdventureShowsAndMovies;
        private readonly List<ListItem> _animationShowsAndMovies;
        private readonly List<ListItem> _scifiShowsAndMovies;
        private readonly List<ListItem> _crimeShowsAndMovies;
        private readonly List<ListItem> _mysteryShowsAndMovies;
        private readonly List<ListItem> _thrillerShowsAndMovies;
        private readonly List<ListItem> _horrorShowsAndMovies;
        private readonly List<ListItem> _familyShowsAndMovies;
        private readonly List<ListItem> _kidsShowsAndMovies;
        private readonly List<ListItem> _westernShowsAndMovies;
        private readonly List<ListItem> _fantasyMovies;
        private readonly List<ListItem> _historyShowsAndMovies;
        private readonly List<ListItem> _romanceShowsAndMovies;
        private readonly List<ListItem> _warShowsAndMovies;
        private readonly List<ListItem> _documentaryShowsAndMovies;
        private readonly List<ListItem> _sitcomShows;
        private readonly List<ListItem> _anthologyShows;
        private readonly List<ListItem> _animeShowsAndMovies;
        private readonly List<ListItem> _teenDramaShowsAndMovies;
        private readonly List<ListItem> _historicalDramaShowsAndMovies;
        private readonly List<ListItem> _workplaceComedyShowsAndMovies;
        private readonly List<ListItem> _medicalDramaShowsAndMovies;

        public TMDBServiceImpl(string apiKey, ILogger logger)
        {
            _apiKey = apiKey;
            _logger = logger;
            _tmdbApiClient = RestService.For<ITMDBApiClient>(BASE_URL);
            _configuration = new Configuration();
            _showGenres = new Dictionary<int, Genre>();
            _movieGenres = new Dictionary<int, Genre>();
            _trendingShowsAndMovies = new List<ListItem>();
            _comedyShowsAndMovies = new List<ListItem>();
            _dramaShowsAndMovies = new List<ListItem>();
            _actionAdventureShowsAndMovies = new List<ListItem>();
            _animationShowsAndMovies = new List<ListItem>();
            _scifiShowsAndMovies = new List<ListItem>();
            _crimeShowsAndMovies = new List<ListItem>();
            _mysteryShowsAndMovies = new List<ListItem>();
            _thrillerShowsAndMovies = new List<ListItem>();
            _horrorShowsAndMovies = new List<ListItem>();
            _familyShowsAndMovies = new List<ListItem>();
            _kidsShowsAndMovies = new List<ListItem>();
            _westernShowsAndMovies = new List<ListItem>();
            _fantasyMovies = new List<ListItem>();
            _historyShowsAndMovies = new List<ListItem>();
            _romanceShowsAndMovies = new List<ListItem>();
            _warShowsAndMovies = new List<ListItem>();
            _documentaryShowsAndMovies = new List<ListItem>();
            _sitcomShows = new List<ListItem>();
            _anthologyShows = new List<ListItem>();
            _animeShowsAndMovies = new List<ListItem>();
            _teenDramaShowsAndMovies = new List<ListItem>();
            _historicalDramaShowsAndMovies = new List<ListItem>();
            _workplaceComedyShowsAndMovies = new List<ListItem>();
            _medicalDramaShowsAndMovies = new List<ListItem>();
        }

        public Configuration Configuration => _configuration;

        public async Task InitializeAsync()
        {
            _logger.LogInformation($"TMDB Service: initialization started at: {DateTime.Now}");

            try
            {
                TMDBConfigurationResponse configurationResponse = await _tmdbApiClient.GetConfigurationAsync(_apiKey);
                
                _configuration.SecureBaseUrl = configurationResponse.images.secure_base_url;
                _configuration.BackdropSizes = configurationResponse.images.backdrop_sizes;
                _configuration.PosterSizes = configurationResponse.images.poster_sizes;
                _configuration.ProfileSizes = configurationResponse.images.profile_sizes;
                _configuration.LogoSizes = configurationResponse.images.logo_sizes;
                _configuration.StillSizes = configurationResponse.images.still_sizes;

                _isInitialized = true;
                _logger.LogInformation($"TMDB Service: initialization successfully finished at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TMDB Service: error on initialization");
            }
        }

        public async Task<Dictionary<int, Genre>> GetShowGenresAsync(string languageCode)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving show genres started at: {DateTime.Now}");

            if (_showGenres.Count == 0)
            {
                try
                {
                    TMDBGenresResponse showGenres = await _tmdbApiClient.GetShowGenresAsync(_apiKey, languageCode);

                    foreach (TMDBGenreResponse genre in showGenres.genres)
                    {
                        _showGenres.Add(genre.id, new Genre { Id = genre.id, Name = genre.name });
                    }

                    _logger.LogInformation($"TMDB Service: retrieving show genres successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving show genres");
                }
            }

            return _showGenres;
        }

        public async Task<Dictionary<int, Genre>> GetMovieGenresAsync(string languageCode)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving movie genres started at: {DateTime.Now}");

            if (_movieGenres.Count == 0)
            {
                try
                {
                    TMDBGenresResponse movieGenres = await _tmdbApiClient.GetMovieGenresAsync(_apiKey, languageCode);

                    foreach (TMDBGenreResponse genre in movieGenres.genres)
                    {
                        _movieGenres.Add(genre.id, new Genre { Id = genre.id, Name = genre.name });
                    }

                    _logger.LogInformation($"TMDB Service: retrieving movie genres successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving movie genres");
                }
            }

            return _movieGenres;
        }

        public async Task<List<ListItem>> GetTrendingShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving trending shows and movies started at: {DateTime.Now}");

            if (_trendingShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBTrendingShowResponse> trendingShows = await _tmdbApiClient.GetTrendingShowsAsync(_apiKey, languageCode, page);
                        TMDBListResponse<TMDBTrendingMovieResponse> trendingMovies = await _tmdbApiClient.GetTrendingMoviesAsync(_apiKey, languageCode, page);

                        foreach (TMDBTrendingShowResponse show in trendingShows.results)
                        {
                            if (show != null)
                                _trendingShowsAndMovies.Add(CreateListItem(ItemType.Show, show.id, show.name, show.overview, show.backdrop_path, show.poster_path));
                        }

                        foreach (TMDBTrendingMovieResponse movie in trendingMovies.results)
                        {
                            if (movie != null)
                                _trendingShowsAndMovies.Add(CreateListItem(ItemType.Movie, movie.id, movie.title, movie.overview, movie.backdrop_path, movie.poster_path));
                        }
                    }

                    _logger.LogInformation($"TMDB Service: retrieving trending shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving trending shows and movies");
                }
            }

            return _trendingShowsAndMovies;
        }

        public async Task<List<ListItem>> GetComedyShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving comedy shows and movies started at: {DateTime.Now}");

            if (_comedyShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> comedyShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_COMEDY_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> comedyMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_COMEDY_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(comedyShows.results, _comedyShowsAndMovies);
                        AddMovieItems(comedyMovies.results, _comedyShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving comedy shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving comedy shows and movies");
                }
            }

            return _comedyShowsAndMovies;
        }

        public async Task<List<ListItem>> GetActionAndAdventureShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving action / adventure shows and movies started at: {DateTime.Now}");

            if (_actionAdventureShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> actionAdventureShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_ACTION_ADVENTURE_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> actionAdventureMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_ACTION_GENRE_ID},{MOVIES_ADVENTURE_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(actionAdventureShows.results, _actionAdventureShowsAndMovies);
                        AddMovieItems(actionAdventureMovies.results, _actionAdventureShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving action / adventure shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving action / adventure shows and movies");
                }
            }

            return _actionAdventureShowsAndMovies;
        }

        public async Task<List<ListItem>> GetDramaShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving drama shows and movies started at: {DateTime.Now}");

            if (_dramaShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> dramaShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_DRAMA_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> dramaMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_DRAMA_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(dramaShows.results, _dramaShowsAndMovies);
                        AddMovieItems(dramaMovies.results, _dramaShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving drama shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving drama shows and movies");
                }
            }

            return _dramaShowsAndMovies;
        }

        public async Task<List<ListItem>> GetAnimationShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving animation shows and movies started at: {DateTime.Now}");

            if (_animationShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> animationShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_ANIMATION_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> animationMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_ANIMATION_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(animationShows.results, _animationShowsAndMovies);
                        AddMovieItems(animationMovies.results, _animationShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving animation shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving animation shows and movies");
                }
            }

            return _animationShowsAndMovies;
        }

        public async Task<List<ListItem>> GetScifiShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving scifi shows and movies started at: {DateTime.Now}");

            if (_scifiShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> scifiShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_SCIFI_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> scifiMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_SCIFI_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(scifiShows.results, _scifiShowsAndMovies);
                        AddMovieItems(scifiMovies.results, _scifiShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving scifi shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving scifi shows and movies");
                }
            }

            return _scifiShowsAndMovies;
        }

        public async Task<List<ListItem>> GetCrimeShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving crime shows and movies started at: {DateTime.Now}");

            if (_crimeShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> crimeShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_CRIME_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> crimeMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_CRIME_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(crimeShows.results, _crimeShowsAndMovies);
                        AddMovieItems(crimeMovies.results, _crimeShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving crime shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving crime shows and movies");
                }
            }

            return _crimeShowsAndMovies;
        }

        public async Task<List<ListItem>> GetMysteryShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving mystery shows and movies started at: {DateTime.Now}");

            if (_mysteryShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> mysteryShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_MYSTERY_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> mysteryMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_MYSTERY_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(mysteryShows.results, _mysteryShowsAndMovies);
                        AddMovieItems(mysteryMovies.results, _mysteryShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving mystery shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving mystery shows and movies");
                }
            }

            return _mysteryShowsAndMovies;
        }

        public async Task<List<ListItem>> GetThrillerShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving thriller shows and movies started at: {DateTime.Now}");

            if (_thrillerShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> thrillerShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{THRILLER_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> thrillerMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_THRILLER_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(thrillerShows.results, _thrillerShowsAndMovies);
                        AddMovieItems(thrillerMovies.results, _thrillerShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving thriller shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving thriller shows and movies");
                }
            }

            return _thrillerShowsAndMovies;
        }

        public async Task<List<ListItem>> GetHorrorShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving horror shows and movies started at: {DateTime.Now}");

            if (_horrorShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> horrorShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{HORROR_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> horrorMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_HORROR_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(horrorShows.results, _horrorShowsAndMovies);
                        AddMovieItems(horrorMovies.results, _horrorShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving horror shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving horror shows and movies");
                }
            }

            return _horrorShowsAndMovies;
        }

        public async Task<List<ListItem>> GetFamilyShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving family shows and movies started at: {DateTime.Now}");

            if (_familyShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> familyShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_FAMILY_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> familyMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_FAMILY_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(familyShows.results, _familyShowsAndMovies);
                        AddMovieItems(familyMovies.results, _familyShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving family shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving family shows and movies");
                }
            }

            return _familyShowsAndMovies;
        }

        public async Task<List<ListItem>> GetKidsShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving kids shows and movies started at: {DateTime.Now}");

            if (_kidsShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> kidsShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_KIDS_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> kidsMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{KIDS_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(kidsShows.results, _kidsShowsAndMovies);
                        AddMovieItems(kidsMovies.results, _kidsShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving kids shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving kids shows and movies");
                }
            }

            return _kidsShowsAndMovies;
        }

        public async Task<List<ListItem>> GetFantasyMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving fantasy movies started at: {DateTime.Now}");

            if (_fantasyMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableMovieResponse> fantasyMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_FANTASY_GENRE_ID}", page, languageCode, regionCode);

                        AddMovieItems(fantasyMovies.results, _fantasyMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving fantasy movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving fantasy movies");
                }
            }

            return _fantasyMovies;
        }

        public async Task<List<ListItem>> GetWesternShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving western shows and movies started at: {DateTime.Now}");

            if (_westernShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> westernShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_WESTERN_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> westernMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_WESTERN_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(westernShows.results, _westernShowsAndMovies);
                        AddMovieItems(westernMovies.results, _westernShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving western shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving western shows and movies");
                }
            }

            return _westernShowsAndMovies;
        }

        public async Task<List<ListItem>> GetHistoryShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving history shows and movies started at: {DateTime.Now}");

            if (_historyShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> historyShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{HISTORY_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> historyMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_HISTORY_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(historyShows.results, _historyShowsAndMovies);
                        AddMovieItems(historyMovies.results, _historyShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving history shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving history shows and movies");
                }
            }

            return _historyShowsAndMovies;
        }

        public async Task<List<ListItem>> GetRomanceShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving romance shows and movies started at: {DateTime.Now}");

            if (_romanceShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> romanceShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{ROMANCE_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> romanceMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_ROMANCE_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(romanceShows.results, _romanceShowsAndMovies);
                        AddMovieItems(romanceMovies.results, _romanceShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving romance shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving romance shows and movies");
                }
            }

            return _romanceShowsAndMovies;
        }

        public async Task<List<ListItem>> GetWarShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving war shows and movies started at: {DateTime.Now}");

            if (_warShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> warShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_WAR_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> warMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_WAR_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(warShows.results, _warShowsAndMovies);
                        AddMovieItems(warMovies.results, _warShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving war shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving war shows and movies");
                }
            }

            return _warShowsAndMovies;
        }

        public async Task<List<ListItem>> GetDocumentaryShowsAndMovies(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving documentary shows and movies started at: {DateTime.Now}");

            if (_documentaryShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> documentaryShows =
                            await _tmdbApiClient.GetDiscoverableShowsByGenresAsync(_apiKey, $"{SHOWS_DOCUMENTARY_GENRE_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> documentaryMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByGenresAsync(_apiKey, $"{MOVIES_DOCUMENTARY_GENRE_ID}", page, languageCode, regionCode);

                        AddShowItems(documentaryShows.results, _documentaryShowsAndMovies);
                        AddMovieItems(documentaryMovies.results, _documentaryShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving documentary shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving documentary shows and movies");
                }
            }

            return _documentaryShowsAndMovies;
        }

        public async Task<List<ListItem>> GetSitcomShowsAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving sitcom shows started at: {DateTime.Now}");

            if (_sitcomShows.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> sitcomShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{SITCOM_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(sitcomShows.results, _sitcomShows);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving sitcom shows successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving sitcom shows");
                }
            }

            return _sitcomShows;
        }

        public async Task<List<ListItem>> GetAnthologyShowsAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving anthology shows started at: {DateTime.Now}");

            if (_anthologyShows.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> anthologyShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{ANTHOLOGY_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(anthologyShows.results, _anthologyShows);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving anthology shows successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving anthology shows");
                }
            }

            return _anthologyShows;
        }

        public async Task<List<ListItem>> GetAnimeShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving anime shows and movies started at: {DateTime.Now}");

            if (_animeShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> animeShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{ANIME_KEYOWRD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> animeMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{ANIME_KEYOWRD_ID}", page, languageCode, regionCode);

                        AddShowItems(animeShows.results, _animeShowsAndMovies);
                        AddMovieItems(animeMovies.results, _animeShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving anime shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving anime shows and movies");
                }
            }

            return _animeShowsAndMovies;
        }

        public async Task<List<ListItem>> GetTeenDramaShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving teen drama shows and movies started at: {DateTime.Now}");

            if (_teenDramaShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> teenDramaShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{TEEN_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> teenDramaMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{TEEN_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(teenDramaShows.results, _teenDramaShowsAndMovies);
                        AddMovieItems(teenDramaMovies.results, _teenDramaShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving teen drama shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving teen drama shows and movies");
                }
            }

            return _teenDramaShowsAndMovies;
        }

        public async Task<List<ListItem>> GetHistoricalDramaShowsAndMovies(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving historical drama shows and movies started at: {DateTime.Now}");

            if (_historicalDramaShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> historicalDramaShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{HISTORICAL_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> historicalDramaMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{HISTORICAL_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(historicalDramaShows.results, _historicalDramaShowsAndMovies);
                        AddMovieItems(historicalDramaMovies.results, _historicalDramaShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving historical drama shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving historical drama shows and movies");
                }
            }

            return _historicalDramaShowsAndMovies;
        }

        public async Task<List<ListItem>> GetWorkplaceComedyShowsAndMovies(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving workplace comedy shows and movies started at: {DateTime.Now}");

            if (_workplaceComedyShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> workplaceComedyShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{WORKPLACE_COMEDY_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> workplaceComedyMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{WORKPLACE_COMEDY_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(workplaceComedyShows.results, _workplaceComedyShowsAndMovies);
                        AddMovieItems(workplaceComedyMovies.results, _workplaceComedyShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving workplace comedy shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving workplace comedy shows and movies");
                }
            }

            return _workplaceComedyShowsAndMovies;
        }

        public async Task<List<ListItem>> GetMedicalDramaShowsAndMovies(string languageCode, string regionCode, int pageCount = 1)
        {
            Debug.Assert(_isInitialized);
            _logger.LogInformation($"TMDB Service: retrieving medical drama shows and movies started at: {DateTime.Now}");

            if (_medicalDramaShowsAndMovies.Count == 0)
            {
                try
                {
                    for (int page = 1; page <= pageCount; page++)
                    {
                        TMDBListResponse<TMDBDiscoverableShowResponse> medicalDramaShows =
                            await _tmdbApiClient.GetDiscoverableShowsByKeywordsAsync(_apiKey, $"{MEDICAL_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        TMDBListResponse<TMDBDiscoverableMovieResponse> medicalDramaMovies =
                            await _tmdbApiClient.GetDiscoverableMoviesByKeywordsAsync(_apiKey, $"{MEDICAL_DRAMA_KEYWORD_ID}", page, languageCode, regionCode);

                        AddShowItems(medicalDramaShows.results, _medicalDramaShowsAndMovies);
                        AddMovieItems(medicalDramaMovies.results, _medicalDramaShowsAndMovies);
                    }

                    _logger.LogInformation($"TMDB Service: retrieving medical drama shows and movies successfully finished at: {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TMDB Service: error on retrieving medical drama shows and movies");
                }
            }

            return _medicalDramaShowsAndMovies;
        }

        public void Clear()
        {
            _showGenres.Clear();
            _movieGenres.Clear();
            _trendingShowsAndMovies.Clear();
            _comedyShowsAndMovies.Clear();
            _dramaShowsAndMovies.Clear();
            _actionAdventureShowsAndMovies.Clear();
            _animationShowsAndMovies.Clear();
            _scifiShowsAndMovies.Clear();
            _crimeShowsAndMovies.Clear();
            _mysteryShowsAndMovies.Clear();
            _thrillerShowsAndMovies.Clear();
            _horrorShowsAndMovies.Clear();
            _familyShowsAndMovies.Clear();
            _kidsShowsAndMovies.Clear();
            _westernShowsAndMovies.Clear();
            _fantasyMovies.Clear();
            _historyShowsAndMovies.Clear();
            _romanceShowsAndMovies.Clear();
            _warShowsAndMovies.Clear();
            _documentaryShowsAndMovies.Clear();
            _sitcomShows.Clear();
            _anthologyShows.Clear();
            _animeShowsAndMovies.Clear();
            _teenDramaShowsAndMovies.Clear();
            _historicalDramaShowsAndMovies.Clear();
            _workplaceComedyShowsAndMovies.Clear();
            _medicalDramaShowsAndMovies.Clear();
        }

        private void AddShowItems(List<TMDBDiscoverableShowResponse> shows, List<ListItem> listItems)
        {
            if (shows != null && listItems != null)
            {
                foreach (TMDBDiscoverableShowResponse show in shows)
                {
                    if (show != null)
                        listItems.Add(CreateListItem(ItemType.Show, show.id, show.name, show.overview, show.backdrop_path, show.poster_path));
                }
            }
        }

        private void AddMovieItems(List<TMDBDiscoverableMovieResponse> movies, List<ListItem> listItems)
        {
            if (movies != null && listItems != null)
            {
                foreach (TMDBDiscoverableMovieResponse movie in movies)
                {
                    if (movie != null)
                        listItems.Add(CreateListItem(ItemType.Movie, movie.id, movie.title, movie.overview, movie.backdrop_path, movie.poster_path));
                }
            }
        }

        private ListItem CreateListItem(ItemType itemType, int id, string title, string overview, string backdropPath, string posterPath)
        {
            var listItem = new ListItem
            {
                ItemType = itemType,
                Id = id,
                Title = title,
                Overview = overview
            };

            SetImagePathes(listItem, backdropPath, posterPath);
            return listItem;
        }

        private void SetImagePathes(ListItem item, string backdropPath, string posterPath)
        {
            if (item != null)
            {
                item.BackdropPathOriginal = !string.IsNullOrWhiteSpace(backdropPath) ? GetBackdropBasePath(BackdropQuality.Original) + backdropPath : string.Empty;
                item.BackdropPathW1280 = !string.IsNullOrWhiteSpace(backdropPath) ? GetBackdropBasePath(BackdropQuality.W1280) + backdropPath : string.Empty;
                item.BackdropPathW780 = !string.IsNullOrWhiteSpace(backdropPath) ? GetBackdropBasePath(BackdropQuality.W780) + backdropPath : string.Empty;
                item.BackdropPathW300 = !string.IsNullOrWhiteSpace(backdropPath) ? GetBackdropBasePath(BackdropQuality.W300) + backdropPath : string.Empty;
                item.PosterPathOriginal = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.Original) + posterPath : string.Empty;
                item.PosterPathW780 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W780) + posterPath : string.Empty;
                item.PosterPathW500 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W500) + posterPath : string.Empty;
                item.PosterPathW342 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W342) + posterPath : string.Empty;
                item.PosterPathW185 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W185) + posterPath : string.Empty;
                item.PosterPathW154 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W154) + posterPath : string.Empty;
                item.PosterPathW92 = !string.IsNullOrWhiteSpace(posterPath) ? GetPosterBasePath(PosterQuality.W92) + posterPath : string.Empty;
            };
        }

        private string GetBackdropBasePath(BackdropQuality quality) => _configuration.SecureBaseUrl + _configuration.BackdropSizes[(int)quality];

        private string GetPosterBasePath(PosterQuality quality) => _configuration.SecureBaseUrl + _configuration.PosterSizes[(int)quality];
    }
}
