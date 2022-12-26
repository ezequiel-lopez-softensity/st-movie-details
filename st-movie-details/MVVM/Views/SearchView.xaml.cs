using st_movie_details.MVVM.ViewModels;

namespace st_movie_details.MVVM.Views;

public partial class SearchView : ContentPage
{
	public SearchView()
	{
		InitializeComponent();
        BindingContext = new SearchViewModel();
    }
}