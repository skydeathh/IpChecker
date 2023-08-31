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
    //public IPAdressModel IPAdressModel { get; set; }
    public ICommand GetLocationCommand { get; }

    private IPAdressModel _ipModel;
    public IPAdressModel IpModel {
        get { return _ipModel; }
        set {
            _ipModel = value;
            OnPropertyChanged(nameof(IPAdressModel));
        }
    }
    public MainViewModel() {
        _ipModel = new IPAdressModel();
        GetLocationCommand = new RelayCommand(async ()
            => await IpModel.GetLocationAsync());
    }
}
