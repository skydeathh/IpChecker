using System.Threading.Tasks;
using IpChecker.Infrastructure;

namespace IpChecker.ViewModels;

public class IPAdressModel : ViewModelBase {
    private string _ip;
    private string _location;

     public string IPAddressInput {
        get { return _ip; }
        set {
            _ip = value;
            OnPropertyChanged(nameof(IPAddressInput));
        }
    }
    public string Location {
        get { return _location; }
        set {
            _location = value;
            OnPropertyChanged(nameof(Location));
        }
    }
    public async Task GetLocationAsync() {

        Location = await IpData.GetLocation(IPAddressInput);
    }
}