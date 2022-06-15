using HOYA_IOT.ObjectData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOYA_IOT.DataRuntime
{
    public class LinkDataQRCode
    {
        public Dictionary<string, Pakingdata> BlockLinkData { get; set; }
        /// <summary>
        /// Contructor
        /// </summary>
        public LinkDataQRCode()
        {
            BlockLinkData = new Dictionary<string, Pakingdata>();
        }
        ~LinkDataQRCode()
        {

        }


        #region Method
        /// <summary>
        /// Reset Data of Rack When Process finished
        /// </summary>
        /// <param name="QRcode"> Rack QRCode</param>
        public void ResetRackData(string QRcode)
        {
            if (BlockLinkData.ContainsKey(QRcode))
            {
                BlockLinkData[QRcode] = null;
            }
        }

        /// <summary>
        /// Link new data packed from server to Rack QRCode
        /// </summary>
        /// <param name="Qrcode">Rack QRCode</param>
        /// <param name="collection">Data Get from Server</param>
        public void LinkNew(string Qrcode, Pakingdata collection)
        {
            if (!BlockLinkData.ContainsKey(Qrcode))
            {
                BlockLinkData.Add(Qrcode, collection);
            }
            else
            {
                BlockLinkData[Qrcode] = collection;
            }
        }
        #endregion
    }
    public class Pakingdata
    {
        public BatchKind BatchKind { get; set; }
        public ObservableCollection<HoyaData> HoyaDatas { get; set; }

        public Pakingdata()
        {
            HoyaDatas = new ObservableCollection<HoyaData>();
        }
    }
}
