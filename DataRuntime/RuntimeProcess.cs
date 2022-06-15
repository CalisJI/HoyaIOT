using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using HOYA_IOT.ViewModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using HOYA_IOT.ObjectData;
using System.Windows.Forms;
using System.Windows.Data;
using System.Globalization;

namespace HOYA_IOT.DataRuntime
{
    public class RuntimeProcess : INotifyPropertyChanged
    {
        #region Trigger Notify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        internal class RelayCommand<T> : ICommand
        {
            //public event EventHandler CanExecuteChanged;
            private readonly Predicate<T> _canExcute;
            private readonly Action<T> _exeCute;

            public RelayCommand(Predicate<T> canExcute, Action<T> execute)
            {
                _canExcute = canExcute;
                _exeCute = execute;
            }
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
            public bool CanExecute(object parameter)
            {
                try
                {
                    return _canExcute == null ? true : _canExcute((T)parameter);
                }
                catch
                {

                    return true;
                }
            }

            public void Execute(object parameter)
            {
                _exeCute((T)parameter);
            }
        }
        #endregion


        #region Icommand

        public ICommand Trigger { get; set; }
        public ICommand Scannew { get; set; }
        public ICommand PrePareTranfer { get; set; }
        public ICommand Runsim { get; set; }

        #endregion


        #region Model
        private CollectionView collection;
        public CollectionView FilterDanhSach
        {
            get => collection;
            set => SetProperty(ref collection, value, nameof(FilterDanhSach));
        }
        private ObservableCollection<BatchTrackingData> _tracking;

        // Data cần cập nhật dự phòng

        public ObservableCollection<BatchTrackingData> BatchTrackingDatas
        {
            get => _tracking;
            set => SetProperty(ref _tracking, value, nameof(BatchTrackingDatas));
        }
        //private LinkDataQRCode linkDataQRCode;

        //public LinkDataQRCode LinkDataQRCode_V
        //{
        //    get => linkDataQRCode;
        //    set => SetProperty(ref linkDataQRCode, value, nameof(LinkDataQRCode_V));
        //}

        private bool _witinginput = true;

        public bool WaitingInput
        {
            get => _witinginput;
            set => SetProperty(ref _witinginput, value, nameof(WaitingInput));
        }

        private string _bat0Code;

        public string Bat0Code
        {
            get => _bat0Code;
            set => SetProperty(ref _bat0Code, value, nameof(Bat0Code));
        }
        private string _bat11Code;

        public string Bat11Code
        {
            get => _bat11Code;
            set => SetProperty(ref _bat11Code, value, nameof(Bat11Code));
        }
        private string _bat1Code;

        public string Bat1Code
        {
            get => _bat1Code;
            set => SetProperty(ref _bat1Code, value, nameof(Bat1Code));
        }
        private string _bat2Code;

        public string Bat2Code
        {
            get => _bat2Code;
            set => SetProperty(ref _bat2Code, value, nameof(Bat2Code));
        }

        private string _bat3Code;

        public string Bat3Code
        {
            get => _bat3Code;
            set => SetProperty(ref _bat3Code, value, nameof(Bat3Code));
        }

        private string _bat4Code;

        public string Bat4Code
        {
            get => _bat4Code;
            set => SetProperty(ref _bat4Code, value, nameof(Bat4Code));
        }

        private string _bat5Code;

        public string Bat5Code
        {
            get => _bat5Code;
            set => SetProperty(ref _bat5Code, value, nameof(Bat5Code));
        }

        private string _bat6Code;

        public string Bat6Code
        {
            get => _bat6Code;
            set => SetProperty(ref _bat6Code, value, nameof(Bat6Code));
        }

        private string _bat7Code;

        public string Bat7Code
        {
            get => _bat7Code;
            set => SetProperty(ref _bat7Code, value, nameof(Bat7Code));
        }
        private string _bat8Code;

        public string Bat8Code
        {
            get => _bat8Code;
            set => SetProperty(ref _bat8Code, value, nameof(Bat8Code));
        }
        private string _bat9Code;

        public string Bat9Code
        {
            get => _bat9Code;
            set => SetProperty(ref _bat9Code, value, nameof(Bat9Code));
        }
        private string _bat10Code;

        public string Bat10Code
        {
            get => _bat10Code;
            set => SetProperty(ref _bat10Code, value, nameof(Bat10Code));
        }

        private string _timedip;

        public string TimerDipTranfer
        {
            get => _timedip;
            set => SetProperty(ref _timedip, value, nameof(TimerDipTranfer));
        }
        private string _timerDipB4;

        public string TimerDipB4
        {
            get => _timerDipB4;
            set => SetProperty(ref _timerDipB4, value, nameof(TimerDipB4));
        }
        private string _timerDipB5;

        public string TimerDipB5
        {
            get => _timerDipB5;
            set => SetProperty(ref _timerDipB5, value, nameof(TimerDipB5));
        }
        private string _timerDipB6;

        public string TimerDipB6
        {
            get => _timerDipB6;
            set => SetProperty(ref _timerDipB6, value, nameof(TimerDipB6));
        }



        private bool _Tranfering;

        public bool Tranfering
        {
            get => _Tranfering;
            set => SetProperty(ref _Tranfering, value, nameof(Tranfering));
        }
        private string _totalt1;

        public string TotalT1
        {
            get => _totalt1;
            set => SetProperty(ref _totalt1, value, nameof(TotalT1));
        }
        private string _totalt2;

        public string TotalT2
        {
            get => _totalt2;
            set => SetProperty(ref _totalt2, value, nameof(TotalT2));

        }
        private string _totalt3;

        public string TotalT3
        {
            get => _totalt3;
            set => SetProperty(ref _totalt3, value, nameof(TotalT3));
        }

        private string _totalt4;

        public string TotalT4
        {
            get => _totalt4;
            set => SetProperty(ref _totalt4, value, nameof(TotalT4));
        }

        private string _totalt5;

        public string TotalT5
        {
            get => _totalt5;
            set => SetProperty(ref _totalt5, value, nameof(TotalT5));
        }
        private string _total6;

        public string TotalT6
        {
            get => _total6;
            set => SetProperty(ref _total6, value, nameof(TotalT6));
        }
        private string _totalt7;

        public string TotalT7
        {
            get => _totalt7;
            set => SetProperty(ref _totalt7, value, nameof(TotalT7));
        }
        private string _totalt8;

        public string TotalT8
        {
            get => _totalt8;
            set => SetProperty(ref _totalt8, value, nameof(TotalT8));
        }
        private string _totalt9;

        public string TotalT9
        {
            get => _totalt9;
            set => SetProperty(ref _totalt9, value, nameof(TotalT9));
        }
        private string _totalt10;

        public string TotalT10
        {
            get => _totalt10;
            set => SetProperty(ref _totalt10, value, nameof(TotalT10));
        }

        private bool _T12;

        public bool T12
        {
            get => _T12;
            set => SetProperty(ref _T12, value, nameof(T12));
        }

        private bool _T23;

        public bool T23
        {
            get => _T23;
            set => SetProperty(ref _T23, value, nameof(T23));
        }
        private bool _T31;

        public bool T31
        {
            get => _T31;
            set => SetProperty(ref _T31, value, nameof(T31));
        }

        private string _tranfer0;

        public string Tranfer0
        {
            get => _tranfer0;
            set => SetProperty(ref _tranfer0, value, nameof(Tranfer0));
        }

        private string _tranfer1;

        public string Tranfer1
        {
            get => _tranfer1;
            set => SetProperty(ref _tranfer1, value, nameof(Tranfer1));
        }

        private string _tranfer2;

        public string Tranfer2
        {
            get => _tranfer2;
            set => SetProperty(ref _tranfer2, value, nameof(Tranfer2));
        }
        private string _tranfer3;

        public string Tranfer3
        {
            get => _tranfer3;
            set => SetProperty(ref _tranfer3, value, nameof(Tranfer3));
        }

        private string _tranfer4;

        public string Tranfer4
        {
            get => _tranfer4;
            set => SetProperty(ref _tranfer4, value, nameof(Tranfer4));
        }

        private string _tranfer5;

        public string Tranfer5
        {
            get => _tranfer5;
            set => SetProperty(ref _tranfer5, value, nameof(Tranfer5));
        }

        private string _tranfer6;

        public string Tranfer6
        {
            get => _tranfer6;
            set => SetProperty(ref _tranfer6, value, nameof(Tranfer6));
        }
        private string _tranfer7;

        public string Tranfer7
        {
            get => _tranfer7;
            set => SetProperty(ref _tranfer7, value, nameof(Tranfer7));
        }

        private string _tranfer8;

        public string Tranfer8
        {
            get => _tranfer8;
            set => SetProperty(ref _tranfer8, value, nameof(Tranfer8));
        }
        private string _tranfer9;

        public string Tranfer9
        {
            get => _tranfer9;
            set => SetProperty(ref _tranfer9, value, nameof(Tranfer9));
        }
        private string _tranfer10;

        public string Tranfer10
        {
            get => _tranfer10;
            set => SetProperty(ref _tranfer10, value, nameof(Tranfer10));
        }

        private bool _run;

        public bool Runsim_
        {
            get => _run;
            set => SetProperty(ref _run, value, nameof(Runsim_));
        }
        private TimeSpan _timespan;

        public TimeSpan TranferBindingTime
        {
            get => _timespan;
            set => SetProperty(ref _timespan, value, nameof(TranferBindingTime));
        }

        //private string _timespan = "0:0:2";

        //public string TranferBindingTime
        //{
        //    get => _timespan;
        //    set => SetProperty(ref _timespan, value, nameof(TranferBindingTime));
        //}
        #endregion


        #region Variable
        /// <summary>
        /// Signl to check is Has rack in bath 1
        /// </summary>
        public static bool HasRack = true;
        /// <summary>
        /// Timer forr Coiunt Time of Tranfer process
        /// </summary>
        public static double TimercountTranfer = 0;
        /// <summary>
        /// Information of object at the first Bath
        /// </summary>
        public static BatchTrackingData CurrenbatchLocation = new BatchTrackingData();
        /// <summary>
        /// vaiable to count time at Area @ of Dip Machine
        /// </summary>
        public static double TimercountREG2 = 0;
        /// <summary>
        /// Timer to display timer of all Process Dip
        /// </summary>
        public static DispatcherTimer Counttime;
        /// <summary>
        /// Timer to display timer of all Process Dip at Area 2
        /// </summary>
        public static DispatcherTimer CounttimeREG2;
        /// <summary>
        /// Timer to check if has Rack at Bath 1 of Dip machine
        /// </summary>
        public static DispatcherTimer WaitDone;
        /// <summary>
        /// Timer To đípay all timer of each Bath
        /// </summary>
        public static DispatcherTimer MonitorRegion2;
        /// <summary>
        /// TImer for Tranfer Process
        /// </summary>
        public static DispatcherTimer TranferTime;
        /// <summary>
        /// Timer for delay tranfer process at Area 2
        /// </summary>
        public static DispatcherTimer TraferTimeB2;
        /// <summary>
        /// varriable to store The QR code have been Scaned 
        /// </summary>
        public static string CurrentNewQRCode = string.Empty;
        /// <summary>
        /// Varaboe to check if Tranfer Of Area 3 Done for Tranfer Process of Area 2 ACtive
        /// </summary>
        public static bool Tranfer3Done = false;
        /// <summary>
        /// Dictionary for store Data of Process Dip and Palce to store Data was Linked from LotTag and owner Qr Code Rack
        /// </summary>
        public static LinkDataQRCode LinkDataQRCode_V;
        #endregion

        public RuntimeProcess()
        {
            if (Counttime == null)
            {
                Counttime = new DispatcherTimer();
                Counttime.Tick += Counttime_Tick;
                Counttime.Interval = new TimeSpan(0, 0, 1);
                Counttime.IsEnabled = false;
            }
            if (WaitDone == null)
            {
                WaitDone = new DispatcherTimer();
                WaitDone.Tick += WaitDone_Tick;
                WaitDone.Interval = new TimeSpan(0, 0, 1);
                WaitDone.IsEnabled = false;
            }
            if (MonitorRegion2 == null)
            {
                MonitorRegion2 = new DispatcherTimer();
                MonitorRegion2.Tick += MonitorRegion2_Tick;
                MonitorRegion2.Interval = new TimeSpan(0, 0, 1);
                MonitorRegion2.IsEnabled = false;
            }
            if (CounttimeREG2 == null)
            {
                CounttimeREG2 = new DispatcherTimer();
                CounttimeREG2.Tick += CounttimeREG2_Tick;
                CounttimeREG2.Interval = new TimeSpan(0, 0, 1);
                CounttimeREG2.IsEnabled = false;
            }
            if (TranferTime == null)
            {
                TranferTime = new DispatcherTimer();
                TranferTime.Tick += TranferTime_Tick;
                TranferTime.Interval = new TimeSpan(0, 0, 2);
                TranferTime.IsEnabled = false;
                TranferBindingTime = TranferTime.Interval;
            }
            if (TraferTimeB2 == null)
            {
                TraferTimeB2 = new DispatcherTimer();
                TraferTimeB2.Tick += TraferTimeB2_Tick;
                TraferTimeB2.Interval = new TimeSpan(0, 0, 2);
                TraferTimeB2.IsEnabled = false;
            }
            if (LinkDataQRCode_V == null)
            {
                LinkDataQRCode_V = new LinkDataQRCode();
                Demo();
            }
            Runsim = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Runsim_ = !Runsim_;
            });
            Scannew = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    string a = (string)p;
                    //CurrentNewQRCode = a;
                    //TriggerDoProcess(a);
                    ScanNewQRCode(a);
                    UpdateSimulator();
                }
                catch (Exception)
                {


                }
            });
            Trigger = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    //string a = (string)p;
                    //BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.BatchState == BatchState.Queue);
                    //CurrentNewQRCode = b.QRCode;
                    //TriggerDoProcess(b.QRCode);

                    Tranfering = true;
                    UpdateTranferView();
                    if (!TranferTime.IsEnabled)
                    {
                        TranferTime.IsEnabled = true;
                        TranferTime.Start();
                    }

                }
                catch (Exception)
                {

                }
            });
            PrePareTranfer = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TranferProcess();
            });
        }

        private void TraferTimeB2_Tick(object sender, EventArgs e)
        {
            if (CurrenbatchLocation.Location == BatchLocation.Batch2_3)
            {
                if (Tranfer3Done)
                {
                    TranferCum2(CurrenbatchLocation);
                    TimercountREG2 = 0;
                    //CurrenbatchLocation = a;
                    UpdateSimulatorREG2();
                    TraferTimeB2.Stop();
                    TraferTimeB2.IsEnabled = false;
                    Tranfer3Done = false;
                    T12 = false;
                    T23 = false;
                    T31 = false;
                    if(CounttimeREG2.IsEnabled == false)
                    {
                        CounttimeREG2.IsEnabled = true;
                        CounttimeREG2.Start();
                    }
                }
            }
            else
            {
                TranferCum2(CurrenbatchLocation);
                TimercountREG2 = 0;
                //CurrenbatchLocation = a;
                UpdateSimulatorREG2();
                TraferTimeB2.Stop();
                TraferTimeB2.IsEnabled = false;
                T12 = false;
                T23 = false;
                T31 = false;
                if (CounttimeREG2.IsEnabled == false)
                {
                    CounttimeREG2.IsEnabled = true;
                    CounttimeREG2.Start();
                }
            }
        }

        private void TranferTime_Tick(object sender, EventArgs e)
        {
            TranferProcess();
            TranferTime.Stop();
            TranferTime.IsEnabled = false;
            Tranfering = false;
        }

        private void CounttimeREG2_Tick(object sender, EventArgs e)
        {
            if (CurrenbatchLocation.Location == BatchLocation.Batch2_1 || CurrenbatchLocation.Location == BatchLocation.Batch2_2 || CurrenbatchLocation.Location == BatchLocation.Batch2_3)
            {
                TimercountREG2++;
                TimeSpan timeSpan = TimeSpan.FromSeconds(TimercountREG2 / 4);
                string aa = timeSpan.ToString(@"mm\:ss");
                //BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
                //Bat4Code = a != null ? a.QRCode : "";
                //BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
                //Bat5Code = b != null ? b.QRCode : "";
                //BatchTrackingData c = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
                //Bat6Code = c != null ? c.QRCode : "";
                switch (CurrenbatchLocation.Location)
                {
                    case BatchLocation.Batch2_1:
                        TimerDipB4 = aa;
                        TimerDipB5 = "00:00";
                        TimerDipB6 = "00:00";
                        Bat4Code = CurrenbatchLocation.QRCode;
                        Bat5Code = "";
                        Bat6Code = "";
                        break;
                    case BatchLocation.Batch2_2:
                        TimerDipB4 = "00:00";
                        TimerDipB5 = aa;
                        TimerDipB6 = "00:00";
                        Bat4Code = "";
                        Bat5Code = CurrenbatchLocation.QRCode;
                        Bat6Code = "";
                        break;
                    case BatchLocation.Batch2_3:
                        TimerDipB4 = "00:00";
                        TimerDipB5 = "00:00";
                        TimerDipB6 = aa;
                        Bat4Code = "";
                        Bat5Code = "";
                        Bat6Code = CurrenbatchLocation.QRCode;
                        break;
                    default:
                        break;
                }
            }

        }

        private void MonitorRegion2_Tick(object sender, EventArgs e)
        {
            // Thay bằng thông số barcode đưa vào
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1 || x.Location == BatchLocation.Batch2_2 || x.Location == BatchLocation.Batch2_3);
            if (a != null)
            {
                TimeSpan diptime = DateTime.Now - a.TimeIn;
                CurrenbatchLocation = a;
                //Những trường hợp này chuyển thành các hàm Batch4Move;Batch5Move,Batch6Move
                switch (a.BatchKind)
                {
                    case BatchKind.P1:
                        if (diptime >= new TimeSpan(0, 0, 24))
                        {
                            UpdateTranferView2();
                            Tranferbat2visibility(2);
                            if (TraferTimeB2.IsEnabled == false)
                            {
                                TraferTimeB2.IsEnabled = true;
                                TraferTimeB2.Start();
                            }
                            if (CounttimeREG2.IsEnabled)
                            {
                                CounttimeREG2.Stop();
                                CounttimeREG2.IsEnabled = false;
                            }
                            //a.BatchMove();
                            //a.TimeIn = DateTime.Now;
                            //TimercountREG2 = 0;
                            //CurrenbatchLocation = a;
                            //UpdateSimulatorREG2();
                            break;
                        }
                        else
                        {
                            return;
                        }

                    case BatchKind.P2:
                        if (a.Location == BatchLocation.Batch2_1)
                        {
                            if (diptime >= new TimeSpan(0, 0, 2))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(0);
                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (a.Location == BatchLocation.Batch2_3)
                        {
                            if (diptime >= new TimeSpan(0, 0, 20))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(2);
                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    case BatchKind.P3:
                        if (a.Location == BatchLocation.Batch2_1)
                        {
                            if (diptime >= new TimeSpan(0, 0, 8))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(0);
                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (a.Location == BatchLocation.Batch2_3)
                        {
                            
                            if (diptime >= new TimeSpan(0, 0, 14))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(2);

                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    case BatchKind.P4:
                        if (a.Location == BatchLocation.Batch2_2)
                        {
                            if (diptime >= new TimeSpan(0, 0, 20))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(1);
                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (a.Location == BatchLocation.Batch2_3)
                        {
                            
                            if (diptime >= new TimeSpan(0, 0, 2))
                            {
                                UpdateTranferView2();
                                Tranferbat2visibility(2);
                                if (TraferTimeB2.IsEnabled == false)
                                {
                                    TraferTimeB2.IsEnabled = true;
                                    TraferTimeB2.Start();
                                }
                                if (CounttimeREG2.IsEnabled)
                                {
                                    CounttimeREG2.Stop();
                                    CounttimeREG2.IsEnabled = false;
                                }
                                //a.BatchMove();
                                //a.TimeIn = DateTime.Now;
                                //TimercountREG2 = 0;
                                //CurrenbatchLocation = a;
                                //UpdateSimulatorREG2();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void WaitDone_Tick(object sender, EventArgs e)
        {
            if (!WaitingInput)
            {
                if (CurrentNewQRCode != "")
                {
                    TriggerDoProcess(CurrentNewQRCode);
                    if (!MonitorRegion2.IsEnabled)
                    {
                        MonitorRegion2.IsEnabled = true;
                        MonitorRegion2.Start();
                    }
                    if (!CounttimeREG2.IsEnabled)
                    {
                        CounttimeREG2.IsEnabled = true;
                        CounttimeREG2.Start();
                    }
                    WaitDone.Stop();
                    WaitDone.IsEnabled = false;
                }
            }
        }

        private void Counttime_Tick(object sender, EventArgs e)
        {
            TimercountTranfer++;
            string aa = string.Empty;
            TimeSpan timeSpan = TimeSpan.FromSeconds(TimercountTranfer / 4);
            aa = timeSpan.ToString(@"mm\:ss");
            TimerDipTranfer = aa;
            UpdateTotalTime();

            // Trigger chạy tranfer
            if (aa == "00:06")
            {
                Tranfering = true;
                UpdateTranferView();
                if (!TranferTime.IsEnabled)
                {
                    TranferTime.IsEnabled = true;
                    TranferTime.Start();
                }
                //TranferProcess();
            }
            Filter();
        }

        #region Method
        /// <summary>
        /// Enable Tranfer View
        /// </summary>
        /// <param name="mode"> Mode 0(1-2),1(2-3),2(3-1)</param>
        public void Tranferbat2visibility(int mode)
        {
            switch (mode)
            {
                case 0:
                    T12 = true;
                    T23 = false;
                    T31 = false;
                    break;
                case 1:
                    T12 = false;
                    T23 = true;
                    T31 = false;
                    break;
                case 2:
                    T12 = false;
                    T23 = false;
                    T31 = true;
                    break;
                default:
                    break;
            }
        }

        private CollectionView GetMovieCollectionView(ObservableCollection<BatchTrackingData> chitietdon)
        {
            return (CollectionView)CollectionViewSource.GetDefaultView(chitietdon);
        }

        public void Filter()
        {
            FilterDanhSach = GetMovieCollectionView(BatchTrackingDatas);
            FilterDanhSach.Refresh();
        }


        /// <summary>
        /// Method to up date UI of Time of process
        /// </summary>
        public void UpdateTotalTime()
        {
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_1);
            TotalT1 = a != null ? a.TotalTime : "--:--";
            BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_2);
            TotalT2 = b != null ? b.TotalTime : "--:--";
            BatchTrackingData c = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_3);
            TotalT3 = c != null ? c.TotalTime : "--:--";
            BatchTrackingData d = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
            TotalT4 = d != null ? d.TotalTime : "--:--";
            BatchTrackingData e = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
            TotalT5 = e != null ? e.TotalTime : "--:--";
            BatchTrackingData f = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
            TotalT6 = f != null ? f.TotalTime : "--:--";
            BatchTrackingData g = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_1);
            TotalT7 = g != null ? g.TotalTime : "--:--";
            BatchTrackingData h = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_2);
            TotalT8 = h != null ? h.TotalTime : "--:--";
            BatchTrackingData i = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_3);
            TotalT9 = i != null ? i.TotalTime : "--:--";
            BatchTrackingData j = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_4);
            TotalT10 = j != null ? j.TotalTime : "--:--";
        }

        /// <summary>
        /// Khởi Chạy hệ thống
        /// </summary>
        /// <param name="barcode_demo"></param>
        public void TriggerDoProcess(string barcode_demo)
        {
            if (string.IsNullOrEmpty(barcode_demo))
            {
                RackIncomming(barcode_demo, WaitingInput);
                if (!WaitingInput)
                {
                    UpdateSimulator();
                    Counttime.IsEnabled = true;
                    TimercountTranfer = 0;
                    TimerDipTranfer = "00:00";
                    Counttime.Start();
                }
            }
            else
            {
                bool a = Checkexist(barcode_demo);
                if (a)
                {
                    //BatchTrackingData rack = BatchTrackingDatas.FirstOrDefault(x => x.QRCode == barcode_demo);
                    RackIncomming(barcode_demo, WaitingInput);
                    if (!WaitingInput)
                    {
                        UpdateSimulator();
                        Counttime.IsEnabled = true;
                        TimercountTranfer = 0;
                        TimerDipTranfer = "00:00";
                        Counttime.Start();
                    }

                }
            }
            
        }

        /// <summary>
        /// Kiểm Tra Rack có hàng hay ko
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Checkexist(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }
            if (!LinkDataQRCode_V.BlockLinkData.ContainsKey(code))
            {
                _ = MessageBox.Show("QRCode không tồn tại trong danh sách");
                return false;

            }
            else
            {
                if (LinkDataQRCode_V.BlockLinkData[code] != null)
                {

                    return true;
                }
                else
                {
                    _ = MessageBox.Show("LotTag Chưa Được Nhập");
                    return false;
                }
            }
        }
        /// <summary>
        /// Confirm before move to machine
        /// </summary>
        /// <param name="data">object of Tag</param>
        /// <param name="B1HasRack">signal to detect at B1</param>
        public void RackIncomming(string QRcode, bool B1HasRack)
        {
            if (B1HasRack)
            {

                //WaitingInput = true;
                /*Đệ quy*/
                //RackIncomming(QRcode, B1HasRack);

                if (!WaitDone.IsEnabled)
                {
                    WaitDone.IsEnabled = true;
                    WaitDone.Start();
                }
            }
            else
            {
                //if (BatchTrackingDatas == null)
                //{
                //    BatchTrackingDatas = new ObservableCollection<BatchTrackingData>();
                //}
                TranferCum1();
                TranferCum3();
                BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.QRCode == QRcode && x.BatchState == BatchState.Queue);
                if (a != null)
                {
                    a.BatchState = BatchState.InProcess;
                    a.TimeIn = DateTime.Now;
                    a.Location = BatchLocation.Batch1_1;
                }
                WaitingInput = false;
                if (!MonitorRegion2.IsEnabled)
                {
                    MonitorRegion2.IsEnabled = true;
                    MonitorRegion2.Start();
                }
                if (!CounttimeREG2.IsEnabled)
                {
                    CounttimeREG2.IsEnabled = true;
                    CounttimeREG2.Start();
                }
            }
        }
        /// <summary>
        /// Process of Process Scan New Rack input Dip machine
        /// </summary>
        /// <param name="QRcode"></param>
        public void ScanNewQRCode(string QRcode)
        {
            if (BatchTrackingDatas == null)
            {
                BatchTrackingDatas = new ObservableCollection<BatchTrackingData>();
            }
            if (LinkDataQRCode_V.BlockLinkData.ContainsKey(QRcode) == false)
            {
                MessageBox.Show("QRCODE Does not exist");
                return;
            }
            else 
            {
                if(LinkDataQRCode_V.BlockLinkData[QRcode] == null)
                {
                    MessageBox.Show("LotTag have not linked yet");
                }
                else 
                {
                    BatchTrackingData data = new BatchTrackingData
                    {
                        QRCode = QRcode,
                        STT = BatchTrackingDatas.Count == 0 ? 1 : BatchTrackingDatas.Count + 1,
                        BatchKind = LinkDataQRCode_V.BlockLinkData[QRcode].BatchKind,
                        Deviation = new TimeSpan(0),
                        BatchState = BatchState.Queue,
                        Location = BatchLocation.Queue
                    };

                    if (null == BatchTrackingDatas.FirstOrDefault(x => x.QRCode == data.QRCode && x.BatchState == BatchState.Queue))
                    {
                        BatchTrackingDatas.Add(data);
                    }
                }
            }
            
        }

        /// <summary>
        /// Method to simulate Tranfer Process
        /// </summary>
        public void TranferProcess()
        {
            if (Counttime.IsEnabled)
            {
                Counttime.Stop();
                Counttime.IsEnabled = false;
            }
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.BatchState == BatchState.Queue);
            if (a == null)
            {
                CurrentNewQRCode = null;
                TriggerDoProcess(null);
                //_ = MessageBox.Show("Chưa có Rack Đầu Vào");
            }
            else
            {
                CurrentNewQRCode = a.QRCode;
                TriggerDoProcess(a.QRCode);
            }
            // Some statment to do stop dipping
        }
        /// <summary>
        /// Method to Simulate tranfer process 2
        /// </summary>
        public void UpdateSimulatorREG2()
        {

            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
            Bat4Code = a != null ? a.QRCode : "";
            BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
            Bat5Code = b != null ? b.QRCode : "";
            BatchTrackingData c = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
            Bat6Code = c != null ? c.QRCode : "";
            UpdateSimulator();
        }
        /// <summary>
        /// 
        /// </summary>
        public void UpdateSimulator()
        {
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_1);
            Bat1Code = a != null ? a.QRCode : "";
            BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_2);
            Bat2Code = b != null ? b.QRCode : "";
            BatchTrackingData c = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_3);
            Bat3Code = c != null ? c.QRCode : "";
            //BatchTrackingData d = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
            //Bat4Code = d != null ? d.QRCode : "";
            //BatchTrackingData e = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
            //Bat5Code = e != null ? e.QRCode : "";
            //BatchTrackingData f = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
            //Bat6Code = f != null ? f.QRCode : "";
            BatchTrackingData g = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_1);
            Bat7Code = g != null ? g.QRCode : "";
            BatchTrackingData h = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_2);
            Bat8Code = h != null ? h.QRCode : "";
            BatchTrackingData i = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_3);
            Bat9Code = i != null ? i.QRCode : "";
            BatchTrackingData j = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_4 && x.BatchState==BatchState.InProcess);
            Bat10Code = j != null ? j.QRCode : "";

            BatchTrackingData k = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Queue);
            Bat0Code = k != null ? k.QRCode : "";
            BatchTrackingData l = BatchTrackingDatas.LastOrDefault(x => x.BatchState == BatchState.Done);
            Bat11Code = l != null ? l.QRCode : "";
        }


        public void UpdateTranferView()
        {
            Bat0Code = "";
            Bat1Code = "";
            Bat2Code = "";
            Bat3Code = "";
            //BatchTrackingData d = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
            //Bat4Code = d != null ? d.QRCode : "";
            //BatchTrackingData e = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
            //Bat5Code = e != null ? e.QRCode : "";
            //BatchTrackingData f = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
            //Bat6Code = f != null ? f.QRCode : "";
            Bat7Code = "";
            Bat8Code = "";
            Bat9Code = "";
            Bat10Code = "";
            BatchTrackingData i = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Queue);
            Tranfer0 = i != null ? i.QRCode : "";
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_1);
            Tranfer1 = a != null ? a.QRCode : "";
            BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_2);
            Tranfer2 = b != null ? b.QRCode : "";
            BatchTrackingData c = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch1_3);
            Tranfer3 = c != null ? c.QRCode : "";
            BatchTrackingData d = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_3);
            Tranfer6 = d != null ? d.QRCode : "";
            BatchTrackingData e = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_1);
            Tranfer7 = e != null ? e.QRCode : "";
            BatchTrackingData f = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_2);
            Tranfer8 = f != null ? f.QRCode : "";
            BatchTrackingData g = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch3_3);
            Tranfer9 = g != null ? g.QRCode : "";
            BatchTrackingData h = BatchTrackingDatas.LastOrDefault(x => x.Location == BatchLocation.Batch3_4 && x.BatchState != BatchState.Done);
            Tranfer10 = h != null ? h.QRCode : "";
            //BatchTrackingData h = BatchTrackingDatas.LastOrDefault(x => x.BatchState == BatchState.Done);
            //Tranfer10 = h != null ? h.QRCode : "";

        }
        public void UpdateTranferView2()
        {
            Bat4Code = "";
            Bat5Code = "";
            Bat6Code = "";
            BatchTrackingData a = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_1);
            Tranfer4 = a != null ? a.QRCode : "";
            BatchTrackingData b = BatchTrackingDatas.FirstOrDefault(x => x.Location == BatchLocation.Batch2_2);
            Tranfer5 = b != null ? b.QRCode : "";
        }


        public void Batch4Move(BatchTrackingData a)
        {
            try
            {

                if (a != null)
                {
                    a.BatchMove();
                }
            }
            catch (Exception)
            {

            }
        }
        public void Batch5Move(BatchTrackingData a)
        {
            try
            {

                if (a != null)
                {
                    a.BatchMove();
                }
            }
            catch (Exception)
            {

            }
        }
        public void Batch6Move(BatchTrackingData a)
        {
            try
            {

                if (a != null)
                {
                    a.BatchMove();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Method to Simualate Data from server After Link Data
        /// </summary>
        public void Demo()
        {
            string line = ApplicationConfig.ApplicationConfig.DemoFile;
            string[] lines = File.ReadAllLines(line);
            foreach (string item in lines)
            {
                string[] a = item.Split('-');
                Pakingdata pakingdata = new Pakingdata();
                switch (a[1])
                {
                    case "P1":
                        pakingdata.BatchKind = BatchKind.P1;
                        break;
                    case "P2":
                        pakingdata.BatchKind = BatchKind.P2;
                        break;
                    case "P3":
                        pakingdata.BatchKind = BatchKind.P3;
                        break;
                    case "P4":
                        pakingdata.BatchKind = BatchKind.P4;
                        break;
                    default:
                        pakingdata.BatchKind = BatchKind.P1;
                        break;
                }
                HoyaData hoyaData = new HoyaData();
                hoyaData.Name = a[2];
                hoyaData.Quantity = Convert.ToInt32(a[3]);
                pakingdata.HoyaDatas.Add(hoyaData);
                LinkDataQRCode_V.LinkNew(a[0], pakingdata);
            }
        }



        //============================================================================================++++++++++++++++++++++++++++++++++===========================+++++++++
        /// <summary>
        /// Method To Simualate Tranfer process of Area 1
        /// </summary>
        public void TranferCum1()
        {
            List<BatchTrackingData> a = BatchTrackingDatas.Where(x => x.BatchState == BatchState.InProcess && (x.Location == BatchLocation.Batch1_1 || x.Location == BatchLocation.Batch1_2 || x.Location == BatchLocation.Batch1_3)).ToList();
            foreach (BatchTrackingData item in a)
            {
                item.BatchMove();
                item.TimeIn = DateTime.Now;
            }
        }
        /// <summary>
        /// Method to simulate Tranfer Process of Area 2
        /// </summary>
        /// <param name="batchTrackingData"></param>
        public void TranferCum2(BatchTrackingData batchTrackingData)
        {
            switch (batchTrackingData.BatchKind)
            {
                case BatchKind.P1:
                    switch (batchTrackingData.Location)
                    {
                        case BatchLocation.Batch2_3:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        default:
                            break;
                    }

                    break;
                case BatchKind.P2:
                    switch (batchTrackingData.Location)
                    {

                        case BatchLocation.Batch2_1:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        case BatchLocation.Batch2_3:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        default:
                            break;
                    }

                    break;
                case BatchKind.P3:
                    switch (batchTrackingData.Location)
                    {

                        case BatchLocation.Batch2_1:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        case BatchLocation.Batch2_3:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                    break;
                case BatchKind.P4:
                    switch (batchTrackingData.Location)
                    {

                        case BatchLocation.Batch2_2:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        case BatchLocation.Batch2_3:
                            batchTrackingData.BatchMove();
                            batchTrackingData.TimeIn = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Method to Simulate Tranfer process of Area 3
        /// </summary>
        public void TranferCum3()
        {
            List<BatchTrackingData> a = BatchTrackingDatas.Where(x => x.BatchState == BatchState.InProcess && (x.Location == BatchLocation.Batch3_1 || x.Location == BatchLocation.Batch3_2 || x.Location == BatchLocation.Batch3_3 || x.Location == BatchLocation.Batch3_4)).ToList();
            if (a != null)
            {
                foreach (BatchTrackingData item in a)
                {
                    item.BatchMove();
                    item.TimeIn = DateTime.Now;
                    if (item.BatchState == BatchState.Done)
                    {
                        LinkDataQRCode_V.ResetRackData(item.QRCode);
                    }
                }
                Tranfer3Done = true;
            }
            
        }


        #endregion
    }
    /// <summary>
    /// Calss to support Converter from  Location variable to Real location information
    /// </summary>
    public class ConverLocation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BatchLocation batchLocation = (BatchLocation)value;
            switch (batchLocation)
            {
                case BatchLocation.Queue:
                    return "Queue";
                case BatchLocation.Batch1_1:
                    return "Bath1";
                case BatchLocation.Batch1_2:
                    return "Bath2";
                case BatchLocation.Batch1_3:
                    return "Bath3";
                case BatchLocation.Batch2_1:
                    return "Bath4";
                case BatchLocation.Batch2_2:
                    return "Bath5";
                case BatchLocation.Batch2_3:
                    return "Bath6";
                case BatchLocation.Batch3_1:
                    return "Bath7";
                case BatchLocation.Batch3_2:
                    return "Bath8";
                case BatchLocation.Batch3_3:
                    return "Bath9";
                case BatchLocation.Batch3_4:
                    return "Bath10";
                default:
                    return "Done";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    /// <summary>
    /// Class to converter from Timepsan to string time to display on UI
    /// </summary>
    public class KeytimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan a = (TimeSpan)value;
            string cc = a.ToString(@"mm\:ss");
            return cc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
