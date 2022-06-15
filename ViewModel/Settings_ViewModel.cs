using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HOYA_IOT.ViewModel
{
    public class Settings_ViewModel : BaseViewModel
    {

        #region Model
        private static Settings_ViewModel _model;
        public static Settings_ViewModel INS_Settings_ViewModel
        {
            get
            {
                if (_model != null)
                {
                    return _model;
                }
                else
                {
                    _model = new Settings_ViewModel();
                    return _model;
                }
            }
            set => _model = value;
        }

        #endregion

        #region Icommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        #endregion

        #region Variable

        #endregion
        public Settings_ViewModel()
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
