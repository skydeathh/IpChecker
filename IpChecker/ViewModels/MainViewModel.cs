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
public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string _location;
    private string _ip;
    public ICommand GetLocationCommand { get; }

    public MainViewModel()
        => GetLocationCommand = new RelayCommand(async ()
            => await GetLocationAsync());

    public string Location
    {
        get { return _location; }
        set
        {
            _location = value;
            OnPropertyChanged();
        }
    }

    public string IPAddress
    {
        get { return _ip; }
        set
        {
            _ip = value;
            OnPropertyChanged(nameof(IPAddress));
        }
    }

    private async Task GetLocationAsync()
    {
        string ip = IPAddress;

        Location = await Infrastructure.IpChecker.GetLocation(ip);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
