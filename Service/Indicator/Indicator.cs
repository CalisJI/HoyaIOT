using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HOYA_IOT.Service.Indicator
{
    public static class Indicator
    {
        private static IndicatorDialog _indicatorDialog;
        public static IndicatorDialog IndicatorDialog
        {
            get
            {
                if(_indicatorDialog != null)
                {
                    return _indicatorDialog;
                }
                else
                {
                    _indicatorDialog = new IndicatorDialog();
                    return _indicatorDialog;
                }
            }
            set => _indicatorDialog = value;
        }

        public static void Beingbusy()
        {
            Thread thread = new Thread(() =>
            {
                IndicatorDialog = new IndicatorDialog();
                _ = IndicatorDialog.ShowDialog();

            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public static void Finished()
        {
            try
            {

                _ = IndicatorDialog.Dispatcher.BeginInvoke(new Action(() =>
                {
                    IndicatorDialog.Close();
                }));


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
