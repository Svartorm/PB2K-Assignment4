namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Fox), "Fox")]
public partial class FoxDetailsViewModel : BaseViewModel
{
    IMap map;
    public FoxDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Fox fox;

    [RelayCommand]
    async Task OpenMap()
    {
    }
}
