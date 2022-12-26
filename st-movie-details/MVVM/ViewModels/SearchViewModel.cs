using PropertyChanged;
using st_movie_details.MVVM.Models;
using System.Text.Json;
using System.Windows.Input;

namespace st_movie_details.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class SearchViewModel
{
    public List<Movie> Movies { get; set; }
    public bool IsLoading { get; set; }
    private const string apiKey = "ddc113f857599594c6f74ac475da1278";
    private HttpClient client;

    public SearchViewModel()
    {
        client = new HttpClient();
    }

    public ICommand SearchCommand =>
    new Command(async (searchText) =>
    {
        await SearchMovies(searchText.ToString());
    });

    private async Task SearchMovies(string searchText)
    {
        var url = $"https://api.themoviedb.org/3/search/movie?query={searchText}&api_key={apiKey}";

        IsLoading = true;

        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<PagedResponse<Movie>>(responseStream);
                Movies = data.results;
            }
        }
        IsLoading = false;
    }
}
