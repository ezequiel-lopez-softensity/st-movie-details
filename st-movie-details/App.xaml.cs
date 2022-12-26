using st_movie_details.MVVM.Views;

namespace st_movie_details;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SearchView();
	}
}
