using IpChecker.Infrastructure;
using System.Threading.Tasks;

namespace IpChecker.ViewModels;

public class DataOutputViewModel : ViewModelBase {

    private string _output;

    public string Output {
        get { return _output; }
        set {
            _output = value;
            OnPropertyChanged(nameof(Output));
        }
    }

    public async Task GetDataAsync(IpAdressInputViewModel ipAdress) {

        var ipData = await GetIpInfoApiService.GetIpInformation(ipAdress);

        Output = ipData.GetInformationString();
    }
}