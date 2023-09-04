using System.Threading.Tasks;
using IpChecker.Infrastructure;

namespace IpChecker.ViewModels;

public class IPAdressViewModel : ViewModelBase {
    private string _ip;

     public string IPAddressInput {
        get { return _ip; }
        set {
            _ip = value;
            OnPropertyChanged(nameof(IPAddressInput));
        }
     }
}