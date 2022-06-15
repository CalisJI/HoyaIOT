using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HOYA_IOT.DataRuntime
{
    public class BatchTrackingData
    {
        private BatchLocation location;
        public int STT { get; set; }
        public BatchKind BatchKind { get; set; }
        public string QRCode { get; set; }
        public BatchLocation Location 
        {
            get => location;
            set
            {
                if (value == BatchLocation.Batch1_1)
                {
                    if (!TotalinTime.IsEnabled)
                    {
                        TotalinTime.IsEnabled = true;
                        TotalinTime.Start();
                    }
                    
                }
                location = value;
            }
        }
        public DateTime TimeIn { get; set; }
        public string TotalTime { get; set; }
        public TimeSpan Deviation
        {
            get;
            set;
        }
        public BatchState BatchState { get; set; }
        public BatchTrackingData()
        {
            TotalinTime = new DispatcherTimer();
            TotalinTime.Interval = new TimeSpan(0, 0, 1);
            TotalinTime.Tick += TotalinTime_Tick;
            TotalinTime.IsEnabled = false;
        }


        private double dem = 0;
        private void TotalinTime_Tick(object sender, EventArgs e)
        {
            dem++;
            var a = TimeSpan.FromSeconds(dem);
            TotalTime = a.ToString(@"mm\:ss");
        }

        #region Timer
        public DispatcherTimer TotalinTime
        { get; set; }
        #endregion

        #region Method

        public void BatchMove()
        {
            if(Location == BatchLocation.Batch3_4)
            {
                BatchState = BatchState.Done;
                if (TotalinTime.IsEnabled)
                {
                    TotalinTime.Stop();
                    TotalinTime.IsEnabled = false;
                }
            }
            else
            {
                switch (BatchKind)
                {
                    case BatchKind.P1:
                        if(Location == BatchLocation.Batch1_3) 
                        {
                            Location = BatchLocation.Batch2_3;
                        }
                        else
                        {
                            Location += 1;
                        }
                        break;
                    case BatchKind.P2:
                        if (Location == BatchLocation.Batch1_3)
                        {
                            Location = BatchLocation.Batch2_1;
                        }
                        else if(Location == BatchLocation.Batch2_1)
                        {
                            Location = BatchLocation.Batch2_3;
                        }
                        else
                        {
                            Location += 1;
                        }
                        break;
                    case BatchKind.P3:
                        if (Location == BatchLocation.Batch1_3)
                        {
                            Location = BatchLocation.Batch2_1;
                        }
                        else if (Location == BatchLocation.Batch2_1)
                        {
                            Location = BatchLocation.Batch2_3;
                        }
                        else
                        {
                            Location += 1;
                        }
                        break;
                    case BatchKind.P4:
                        if (Location == BatchLocation.Batch1_3)
                        {
                            Location = BatchLocation.Batch2_2;
                        }
                        else if (Location == BatchLocation.Batch2_1)
                        {
                            Location = BatchLocation.Batch2_3;
                        }
                        else
                        {
                            Location += 1;
                        }
                        break;
                }   
                
            }
            
        }
        #endregion
    }
    public enum BatchLocation
    {
       Queue,
       Batch1_1,
       Batch1_2,
       Batch1_3,
       Batch2_1,
       Batch2_2,
       Batch2_3,
       Batch3_1,
       Batch3_2,
       Batch3_3,
       Batch3_4
    }
    public enum BatchState
    {
        Queue,
        InProcess,
        Done
    }
    public enum BatchKind
    {
        P1,
        P2,
        P3,
        P4
    }
}
