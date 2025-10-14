using System.ComponentModel;
using System.Runtime.CompilerServices;

public class FinancialData : INotifyPropertyChanged
{
    private string _binding;
    private string _branch;
    private string _group;
    private string _client;
    private string _staffName;
    private decimal _spanMargin;
    private decimal _exposureMargin;
    private decimal _totalMargin;
    private decimal _peakMargin;
    private decimal _exposure;
    private decimal _varTotal;
    private decimal _peakVar;
    private decimal _todaysDelivery;
    private decimal _totalDelivery;
    private decimal _peakDeliv;
    private decimal _optRealDay;
    private decimal _optUnrealDay;
    private decimal _optMtmNet;
    private decimal _optMtmDay;
    private decimal _futRealDay;
    private decimal _futUnrealDay;
    private decimal _futMtmNet;
    private decimal _futMtmDay;
    private decimal _allotedFund;
    private double _utilizedPercentage;
    private decimal _exposureMargin2;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Binding
    {
        get => _binding;
        set => SetProperty(ref _binding, value);
    }

    public string Branch
    {
        get => _branch;
        set => SetProperty(ref _branch, value);
    }

    public string Group
    {
        get => _group;
        set => SetProperty(ref _group, value);
    }

    public string Client
    {
        get => _client;
        set => SetProperty(ref _client, value);
    }

    public string StaffName
    {
        get => _staffName;
        set => SetProperty(ref _staffName, value);
    }

    public decimal SpanMargin
    {
        get => _spanMargin;
        set => SetProperty(ref _spanMargin, value);
    }

    public decimal ExposureMargin
    {
        get => _exposureMargin;
        set => SetProperty(ref _exposureMargin, value);
    }

    public decimal TotalMargin
    {
        get => _totalMargin;
        set => SetProperty(ref _totalMargin, value);
    }

    public decimal PeakMargin
    {
        get => _peakMargin;
        set => SetProperty(ref _peakMargin, value);
    }

    public decimal Exposure
    {
        get => _exposure;
        set => SetProperty(ref _exposure, value);
    }

    public decimal VarTotal
    {
        get => _varTotal;
        set => SetProperty(ref _varTotal, value);
    }

    public decimal PeakVar
    {
        get => _peakVar;
        set => SetProperty(ref _peakVar, value);
    }

    public decimal TodaysDelivery
    {
        get => _todaysDelivery;
        set => SetProperty(ref _todaysDelivery, value);
    }

    public decimal TotalDelivery
    {
        get => _totalDelivery;
        set => SetProperty(ref _totalDelivery, value);
    }

    public decimal PeakDeliv
    {
        get => _peakDeliv;
        set => SetProperty(ref _peakDeliv, value);
    }

    public decimal OPTRealDay
    {
        get => _optRealDay;
        set => SetProperty(ref _optRealDay, value);
    }

    public decimal OPTUnrealDay
    {
        get => _optUnrealDay;
        set => SetProperty(ref _optUnrealDay, value);
    }

    public decimal OPTMTMNet
    {
        get => _optMtmNet;
        set => SetProperty(ref _optMtmNet, value);
    }

    public decimal OPTMTMDay
    {
        get => _optMtmDay;
        set => SetProperty(ref _optMtmDay, value);
    }

    public decimal FUTRealDay
    {
        get => _futRealDay;
        set => SetProperty(ref _futRealDay, value);
    }

    public decimal FUTUnrealDay
    {
        get => _futUnrealDay;
        set => SetProperty(ref _futUnrealDay, value);
    }

    public decimal FUTMTMNet
    {
        get => _futMtmNet;
        set => SetProperty(ref _futMtmNet, value);
    }

    public decimal FUTMTMDay
    {
        get => _futMtmDay;
        set => SetProperty(ref _futMtmDay, value);
    }

    public decimal AllotedFund
    {
        get => _allotedFund;
        set => SetProperty(ref _allotedFund, value);
    }

    public double UtilizedPercentage
    {
        get => _utilizedPercentage;
        set => SetProperty(ref _utilizedPercentage, value);
    }

    public decimal ExposureMargin2
    {
        get => _exposureMargin2;
        set => SetProperty(ref _exposureMargin2, value);
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (!Equals(field, value))
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        return false;
    }
}
