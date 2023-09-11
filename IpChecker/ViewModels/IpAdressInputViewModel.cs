using System.Threading.Tasks;
using IpChecker.Infrastructure;

namespace IpChecker.ViewModels;

public class IpAdressInputViewModel : ViewModelBase {
    private string _ip;

     public string Ip {
        get { return _ip; }
        set {
            _ip = value;
            OnPropertyChanged(nameof(Ip));
        }
     }
}