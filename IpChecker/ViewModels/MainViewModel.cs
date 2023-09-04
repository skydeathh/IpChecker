using IpChecker.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IpChecker.Infrastructure;

namespace IpChecker.ViewModels;
public class MainViewModel : ViewModelBase {
    public ICommand GetLocationCommand { get; }

    private     IPAdressViewModel _ipModel;
    private LocationViewModel _locationModel;

    public IPAdressViewModel IpModel {
        get { return _ipModel; }
        set {
            _ipModel = value;
            OnPropertyChanged(nameof(IPAdressViewModel));
        }   
    }

    public LocationViewModel LocationModel {
        get { return _locationModel; }
        set {
            _locationModel = value;
            OnPropertyChanged(nameof(IPAdressViewModel));
        }
    }

    public MainViewModel() {
        LocationModel = new LocationViewModel();
        IpModel = new IPAdressViewModel();

        GetLocationCommand = new RelayCommand(async ()
            => await LocationModel.GetLocationAsync(IpModel));
    }
}