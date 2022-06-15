using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using System.Windows.Forms;
using HOYA_IOT.ObjectData;

namespace HOYA_IOT.Control
{
    public class PLC_Communication
    {
        #region Properties

        public Plc PLCDevice { get; set; }

        public string PLC_Ip { get; set; }
        public short PLC_Rack { get; set; }
        public short PLC_Slot { get; set; }
        public PlcObjectData PLCData { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// Open connection between PLC and Computer
        /// </summary>
        public void OpenPLC()
        {
            try
            {
                if (PLCDevice != null)
                {
                    PLCDevice.Open();
                }
            }
            catch (Exception ex)
            {

                _ = MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Close the connect between PLC and Computer
        /// </summary>
        public void ClosePLC()
        {
            try
            {
                if (PLCDevice != null)
                {
                    if (PLCDevice.IsConnected)
                    {
                        PLCDevice.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Read Byte From PLC
        /// </summary>
        /// <param name="dataType"> Kiểu Dữ Liệu</param>
        /// <param name="db">Index of Datablock</param>
        /// <param name="startByteAdr">vị trí Byte bắt đầu đọc</param>
        /// <param name="count">Số lượng cần độc (max 200)</param>
        /// <returns></returns>
        public byte[] ReadbytesFromPLC(DataType dataType, int db, int startByteAdr, int count)
        {
            return PLCDevice.ReadBytes(dataType, db, startByteAdr, count);
        }
        /// <summary>
        /// Ghi xuống PLC dữ liệu mảng byte
        /// </summary>
        /// <param name="dataType"> Kiểu Dữ Liệu</param>
        /// <param name="db">Index of Datablock</param>
        /// <param name="startByteAdr">vị trí Byte bắt đầu đọc</param>
        /// <param name="value">mảng giá trị cần ghi xuống</param>
        public void WriteBytesToPlC(DataType dataType, int db, int startByteAdr, byte[] value)
        {
            PLCDevice.WriteBytes(dataType, db, startByteAdr, value);
        }
        /// <summary>
        /// Đọc data từ plc (Bất đồng bộ)
        /// </summary>
        /// <param name="dataType">Kiểu Dữ Liệu</param>
        /// <param name="db">Chỉ mục cảu khối dữ liệu</param>
        /// <param name="startByteAdr">vị trí Byte bắt đầu đọc</param>
        /// <param name="count">Số lượng cần độc</param>
        /// <returns></returns>
        public Task<byte[]> ReadbytesFromPLCAsync(DataType dataType, int db, int startByteAdr, int count)
        {
            Task<byte[]> a = PLCDevice.ReadBytesAsync(dataType, db, startByteAdr, count);
            return a;
        }

        /// <summary>
        /// Ghi dữ liệu byte xuông PLC (Bất đồng bộ)
        /// </summary>
        /// <param name="dataType"> Kiểu Dữ Liệu</param>
        /// <param name="db">Index of Datablock</param>
        /// <param name="startByteAdr">vị trí Byte bắt đầu đọc</param>
        /// <param name="value">mảng giá trị cần ghi xuống</param>
        public void WriteBytesToPlCAsync(DataType dataType, int db, int startByteAdr, byte[] value)
        {
            var e = PLCDevice.WriteBytesAsync(dataType, db, startByteAdr, value);
        }

        /// <summary>
        /// Đọc giá trị của một biến nhớ
        /// </summary>
        /// <param name="variable">Tên biến cần đọc giá trị</param>
        /// <returns></returns>
        public object ReadSingleData(string variable)
        {
            var a = PLCDevice.Read(variable);
            return a;
        }
        /// <summary>
        /// Đọc giá trị của một biến nhớc(Bất Đồng Bộ)
        /// </summary>
        /// <param name="variable">Tên biến cần đọc giá trị</param>
        /// <returns></returns>
        public Task<object> ReadSingleDataAsync(string variable)
        {
            var a = PLCDevice.ReadAsync(variable);
            return a;
        }
        /// <summary>
        /// Ghi data xuống PLC
        /// </summary>
        /// <param name="varialble">Tên Biến</param>
        /// <param name="value">Data</param>
        public void WriteSingleData(string varialble,object value)
        {
            PLCDevice.Write(varialble, value);
            
        }
        /// <summary>
        /// Ghi data xuống PLC (Bất Đồng Bộ)
        /// </summary>
        /// <param name="varialble">Tên Biến</param>
        /// <param name="value">Data</param>
        public Task WriteSingleDataAsync(string varialble, object value)
        {
            var a = PLCDevice.WriteAsync(varialble, value);
            return a;
        }

        /// <summary>
        /// Đọc dữ liệu từ PLC vào Class
        /// </summary>
        /// <param name="data">Đối Tượng Class</param>
        /// <param name="db">Chỉ mục DataBlock</param>
        /// <param name="startByteAdr">Địa chỉ thanh ghi bắt đầu</param>
        public void ReadClass(object data, int db, int startByteAdr = 0)
        {
            PLCDevice.ReadClass(data, db, startByteAdr);
        }

        /// <summary>
        /// Đọc data Block (Bất Đồng Bộ)
        /// </summary>
        /// <param name="data">Dữ Liệu</param>
        /// <param name="db">Chỉ mục của khối dữ liệu</param>
        /// <param name="startByteAdr">Byte bắt đầu</param>
        /// <returns></returns>
        public Task ReadClassAsync(object data,int db, int startByteAdr =0)
        {
            var a = PLCDevice.ReadClassAsync(data,db,startByteAdr);
            return a;
        }

        /// <summary>
        /// Ghi Dữ Liệu Từ Class Xuống PLC (Bất Đồng Bộ)
        /// </summary>
        /// <param name="value">Dữ Liệu Cần Ghi</param>
        /// <param name="db">Chỉ mục của khối dữ liệu</param>
        /// <param name="startByteAdr">Byte bắt đầu</param>
        /// <returns></returns>
        public Task WriteClassAsync(object value,int db, int startByteAdr = 0)
        {
            var a = PLCDevice.WriteClassAsync(value, db, startByteAdr);
            return a;
        }
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PLC_Communication(CpuType cpuType, string ip, short rack, short slot)
        {
            PLC_Ip = ip;
            PLC_Rack = rack;
            PLC_Slot = slot;
            PLCDevice = new Plc(cpuType, ip, rack, slot);
        }
        ~PLC_Communication()
        {

        }
        #endregion


    }
}
