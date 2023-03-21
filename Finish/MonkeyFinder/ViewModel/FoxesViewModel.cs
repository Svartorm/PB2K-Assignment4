using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class FoxesViewModel : BaseViewModel
{
    public ObservableCollection<Fox> Foxes { get; } = new();
    FoxService foxService;
    IConnectivity connectivity;
    IGeolocation geolocation;
    public FoxesViewModel(FoxService foxService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        this.foxService = foxService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }
    
    [RelayCommand]
    async Task GoToDetails(Fox fox)
    {
        if (fox == null)
        return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Fox", fox }
        });
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetFoxesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var foxes = await foxService.GetFoxes();

            if(Foxes.Count != 0)
                Foxes.Clear();

            foreach(var fox in foxes)
                Foxes.Add(fox);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GetClosestMonkey()
    {
    }
}
