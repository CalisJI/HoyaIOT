using HOYA_IOT.ObjectData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace HOYA_IOT.ApplicationConfig
{
    public class ApplicationConfig
    {
        /// <summary>
        /// Path File Of System Config File for Application
        /// </summary>
        private static readonly string Systemconfiguration = Directory.GetCurrentDirectory() + @"\" + "ApplicationConfig.xml";
        /// <summary>
        /// Path file of Process Tiemr Data Config File
        /// </summary>
        private static readonly string ProcessTimerConfigFile = Directory.GetCurrentDirectory() + @"\" + "ProcessTimerConfig.xml";
        /// <summary>
        /// File excel to seit and overview process of Dip machine
        /// </summary>
        public static readonly string ProcessExcelFile = Directory.GetCurrentDirectory() + @"\" + "Hoyareedit.xlsx";
        /// <summary>
        /// File Demo data to test application
        /// </summary>
        public static readonly string DemoFile = Directory.GetCurrentDirectory() + @"\" + "demohoya.txt";
        public static SystemConfig SystemConfig;
        public ApplicationConfig()
        {
            SystemConfig = GetData<SystemConfig>();
            
        }
        /// <summary>
        /// Get Config of Application from file system configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetData<T>()
        {
            if (File.Exists(Systemconfiguration))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(Systemconfiguration, FileMode.Open);
                T mapping = (T)xmlSerializer.Deserialize(stream);
                stream.Close();
                return mapping;
            }
            else
            {
                T generic = (T)Activator.CreateInstance(typeof(T));

                //

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(Systemconfiguration, FileMode.Create);
                using (XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8))
                {
                    xmlSerializer.Serialize(xmlwriter, generic);
                    xmlwriter.Close();
                }
                stream.Close();
                return generic;
            }
        }
        /// <summary>
        /// Update Config of Application setting to file Sysyemconfig
        /// </summary>
        /// <param name="data">Systemconfig data type object</param>
        public static void UpdateData(object data)
        {
            Type type = data.GetType();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextWriter textWriter = new StreamWriter(Systemconfiguration))
            {
                xmlSerializer.Serialize(textWriter, data);
                textWriter.Close();
            }
        }

        /// <summary>
        /// Get Config of Process TimerData from File Config
        /// </summary>
        /// <typeparam name="T"> Type of ProcessTimerConfig Data</typeparam>
        /// <returns></returns>
        public static T GetProcessTimerData<T>()
        {
            if (File.Exists(ProcessTimerConfigFile))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(ProcessTimerConfigFile, FileMode.Open);
                T mapping = (T)xmlSerializer.Deserialize(stream);
                stream.Close();
                return mapping;
            }
            else
            {
                T generic = (T)Activator.CreateInstance(typeof(T));

                //

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(ProcessTimerConfigFile, FileMode.Create);
                using (XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8))
                {
                    xmlSerializer.Serialize(xmlwriter, generic);
                    xmlwriter.Close();
                }
                stream.Close();
                return generic;
            }
        }
        /// <summary>
        /// Update Config of ProcessTimer Dip Machine
        /// </summary>
        /// <param name="data">ProcessTimerData object type</param>
        public static void UpdateProcessTimerData(object data)
        {
            Type type = data.GetType();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextWriter textWriter = new StreamWriter(ProcessTimerConfigFile))
            {
                xmlSerializer.Serialize(textWriter, data);
                textWriter.Close();
            }
        }
    }
}
