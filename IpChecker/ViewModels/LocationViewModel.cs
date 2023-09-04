using IpChecker.Infrastructure;
using System.Threading.Tasks;

namespace IpChecker.ViewModels;

public class LocationViewModel : ViewModelBase {

    private string _location;

    public string Location {
        get { return _location; }
        set {
            _location = value;
            OnPropertyChanged(nameof(Location));
        }
    }

    public async Task GetLocationAsync(IPAdressViewModel ipAdress) {

        Location = await IpData.GetLocation(ipAdress.IPAddressInput);
    }
}