using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOYA_IOT.Control;
using System.Windows.Input;
using System.Windows.Documents;
using System.Data;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using HOYA_IOT.ObjectData;

namespace HOYA_IOT.ViewModel
{
    public class ProcessOverView_ViewModel : BaseViewModel
    {
        #region Model

        /// <summary>
        /// Singleton
        /// </summary>
        private static ProcessOverView_ViewModel model;

        public static ProcessOverView_ViewModel INS_ProcessOverView_ViewModel
        {
            get
            {
                if (model != null)
                {
                    return model;
                }
                else
                {
                    model = new ProcessOverView_ViewModel();
                    return model;
                }
            }
        }

        private FixedDocumentSequence _xps;

        public FixedDocumentSequence XPSDocument
        {
            get => _xps;
            set => SetProperty(ref _xps, value, nameof(XPSDocument));
        }

        private DataTable _table;

        public DataTable TableExcel
        {
            get => _table;
            set => SetProperty(ref _table, value, nameof(TableExcel));
        }

     
        private bool _editable;
        /// <summary>
        /// Variable to allow Edit Configuration
        /// </summary>
        public bool Editable
        {
            get => _editable;
            set => SetProperty(ref _editable, value, nameof(Editable));
        }

     
        private double _diptimetranfer;
        /// <summary>
        /// Property to Storage Dip timer of Area 1 and Area 3
        /// </summary>
        public double Diptimetranfer
        {
            get => _diptimetranfer;
            set => SetProperty(ref _diptimetranfer, value, nameof(Diptimetranfer));
        }

      
        private double _dipP1;
        /// <summary>
        /// Property to Storage TimerDip of P1 At Bath6
        /// </summary>
        public double DipP1
        {
            get => _dipP1;
            set => SetProperty(ref _dipP1, value, nameof(DipP1));
        }

      
        private double _dip1P2;
        /// <summary>
        /// Property to Storage TimerDip of P2 At Bath3
        /// </summary>
        public double Dip1P2
        {
            get => _dip1P2;
            set => SetProperty(ref _dip1P2, value, nameof(Dip1P2));
        }

       
        private double _dip2P2;
        /// <summary>
        /// Property to Storage TimerDip of P2 At Bath6
        /// </summary>
        public double Dip2P2
        {
            get => _dip2P2;
            set => SetProperty(ref _dip2P2, value, nameof(Dip2P2));
        }
       
        private double _dip1P3;
        /// <summary>
        /// Property to Storage TimerDip of P3 At Bath3
        /// </summary>
        public double Dip1P3
        {
            get => _dip1P3;
            set => SetProperty(ref _dip1P3, value, nameof(Dip1P3));
        }
        
        private double _dip2P3;
        /// <summary>
        /// Property to Storage TimerDip of P3 At Bath6
        /// </summary>
        public double Dip2P3
        {
            get => _dip2P3;
            set => SetProperty(ref _dip2P3, value, nameof(Dip2P3));
        }
       
        private double _dip1P4;
        /// <summary>
        /// Property to Storage TimerDip of P4 At Bath5
        /// </summary>
        public double Dip1P4
        {
            get => _dip1P4;
            set => SetProperty(ref _dip1P4, value, nameof(Dip1P4));
        }

        
        private double _dip2P4;
        /// <summary>
        /// Property to Storage TimerDip of P4 At Bath6
        /// </summary>
        public double Dip2P4
        {
            get => _dip2P4;
            set => SetProperty(ref _dip2P4, value, nameof(Dip2P4));
        }
        
        private double _tranfertime;
        /// <summary>
        /// Property to Storage Timer of tranfer process At Area 1 And Area 3
        /// </summary>
        public double TranferTime
        {
            get => _tranfertime;
            set => SetProperty(ref _tranfertime, value, nameof(TranferTime));
        }


        #endregion

        #region ICommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        /// <summary>
        /// Triger for Allow Edit Configuration
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// Trigger of Cancel Edit Configuration
        /// </summary>
        public ICommand CancelCommand { get; set; }
        /// <summary>
        /// Trigger for Apply Configuration
        /// </summary>
        public ICommand ApplyCommmand { get; set; }
        /// <summary>
        /// Trigger to test Configuration to Check Suitibility
        /// </summary>
        public ICommand CheckCommand { get; set; }
        #endregion

        #region Variable
        /// <summary>
        /// object to save Data Timer Process of Dip Machine
        /// </summary>

        public static ProcessTimerData ProcessTimerData = new ProcessTimerData();
        #endregion
        public ProcessOverView_ViewModel()
        {
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //ExcelFileParse.Get_excel(@"F:\FILE\EXCEL\HOYAConcept\Hoyareedit.xlsx");
                //TableExcel = ExcelFileParse.DataTableCollection[ExcelFileParse.ListSheet[0]];
                //XPSDocument = ExcelFileParse.BrowseFile();
            });
            Unloaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            });
            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });

            ApplyCommmand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });

            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });
            CheckCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });
        }
        /// <summary>
        /// Method Set value for object Timer of Process Dip and update to File Storage
        /// </summary>
        public void ApplyConfig()
        {
            ProcessTimerData.Diptranfertime = Diptimetranfer;
            ProcessTimerData.DipP1Time = DipP1;
            ProcessTimerData.Dip1P2Time = Dip1P2;
            ProcessTimerData.Dip1P3Time = Dip1P3;
            ProcessTimerData.Dip1P4Time = Dip1P4;
            ProcessTimerData.Dip2P2Time = Dip2P2;
            ProcessTimerData.Dip2P3Time = Dip2P3;
            ProcessTimerData.Dip2P4Time = Dip2P4;
            ProcessTimerData.TranferTime = TranferTime;

            ApplicationConfig.ApplicationConfig.UpdateProcessTimerData(ProcessTimerData);
        }
    }
    public class NotifyProcess : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var a = (string)value;
            switch (a)
            {
                case "OK":
                    return Colors.Green;
                case "NG":
                    return Colors.Red;
                default:
                    return Colors.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
