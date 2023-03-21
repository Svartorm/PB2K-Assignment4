namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(FoxesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

