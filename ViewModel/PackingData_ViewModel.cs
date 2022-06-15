using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HOYA_IOT.ViewModel
{
    public class PackingData_ViewModel:BaseViewModel
    {
        #region Singleton
        private static PackingData_ViewModel _model;

        public static PackingData_ViewModel INS_PackingData_ViewModel
        {
            get
            {
                if (_model != null)
                {
                    return _model;
                }
                else
                {
                    _model = new PackingData_ViewModel();
                    return _model;
                }
            }
            set
            {
                _model = value;
            }
        }
        #endregion

        #region Model

        #endregion

        #region Icommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        #endregion
        public PackingData_ViewModel()
        {
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });
            Unloaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });
        }
    }
}
