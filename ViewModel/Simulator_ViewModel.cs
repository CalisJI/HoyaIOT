using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HOYA_IOT.ViewModel
{
    public class Simulator_ViewModel : BaseViewModel
    {
        // Model of view
        #region Model
        /// <summary>
        /// 
        /// </summary>
        private static Simulator_ViewModel _model;

        public static Simulator_ViewModel INS_Simulator_ViewModel
        {
            get
            {
                if (_model != null) 
                {
                    return _model;
                }
                else
                {
                    _model = new Simulator_ViewModel();
                    return _model;
                }
            }
            set => _model = value;
        }
        private bool _trig;

        public bool Trig
        {
            get => _trig;
            set => SetProperty(ref _trig, value, nameof(Trig));
        }
        
        #endregion


        // ICommand
        #region ICommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        #endregion


        // Variable
        #region Variable

        #endregion
        public Simulator_ViewModel()
        {
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Trig = true;
            });
            Unloaded = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
            
            });
        }


        #region Method
        
        #endregion
    }
}
