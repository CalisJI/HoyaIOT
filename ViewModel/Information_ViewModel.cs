using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace HOYA_IOT.ViewModel
{
    public class Information_ViewModel : BaseViewModel
    {
        #region Model
        private static Information_ViewModel model;

        public static Information_ViewModel INS_Information_ViewModel
        {
            get
            {
                if (model != null)
                {
                    return model;
                }
                else
                {
                    model = new Information_ViewModel();
                    return model;
                }
            }
            set => model = value;
        }
        #endregion

        #region Icommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        #endregion

        #region Variable

        #endregion
        public Information_ViewModel()
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
