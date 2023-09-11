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
using System.Collections.ObjectModel;
using IpChecker.Models;

namespace IpChecker.ViewModels;
public class MainViewModel : ViewModelBase {
    public ICommand GetDataCommand { get; }

    private IpAdressInputViewModel _ipInputModel;
    private DataOutputViewModel _dataOutputModel;

    public IpAdressInputViewModel IpInputModel {
        get { return _ipInputModel; }
        set {
            _ipInputModel = value;
            OnPropertyChanged(nameof(IpAdressInputViewModel));
        }   
    }

    public DataOutputViewModel DataOutputModel {
        get { return _dataOutputModel; }
        set {
            _dataOutputModel = value;
            OnPropertyChanged(nameof(_dataOutputModel));
        }
    }

    public MainViewModel() {
        IpInputModel = new IpAdressInputViewModel();
        DataOutputModel = new DataOutputViewModel();

        GetDataCommand = new RelayCommand(async ()
            => await DataOutputModel.GetDataAsync(IpInputModel));
    }
}