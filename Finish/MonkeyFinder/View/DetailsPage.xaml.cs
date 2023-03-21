namespace MonkeyFinder;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(FoxDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}