using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HOYA_IOT.ViewModel
{
    public class MainScreen_ViewModel : BaseViewModel
    {
       
        #region Model
        private static MainScreen_ViewModel model;
        public static MainScreen_ViewModel INS_MainScreenViewModel
        {
            get
            {
                if (model != null)
                {
                    return model;
                }
                else
                {
                    model = new MainScreen_ViewModel();
                    return model;
                }
            }
            set => model = value;
        }
        #endregion
        #region ICommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        #endregion
        #region Variable

        #endregion
        public MainScreen_ViewModel() 
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
