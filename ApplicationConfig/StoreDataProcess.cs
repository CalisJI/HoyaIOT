using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using HOYA_IOT.ObjectData;
using System.Diagnostics;

namespace HOYA_IOT.ApplicationConfig
{
    public class StoreDataProcess
    {
        private static readonly string BackupFile = Directory.GetCurrentDirectory() + @"\" + "Backup.txt";
        private static readonly string BackupFileclone = Directory.GetCurrentDirectory() + @"\" + "Backup1.txt";
        private static readonly string CheckFile = Directory.GetCurrentDirectory() + @"\" + "Check.txt";
        public static bool Unusualaction = true;
        public BackupData BackupData { get; set; }
        public StoreDataProcess()
        {
            BackupData = new BackupData();
            if (!File.Exists(CheckFile))
            {
                File.WriteAllText(CheckFile, "true");
            }
            if (!File.Exists(BackupFile))
            {
                File.Create(BackupFile).Close();
            }
            if (!File.Exists(BackupFileclone))
            {
                File.Create(BackupFileclone).Close();
            }
            else
            {
                if (CheckUnsual())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    BackupData = RecoveryData();
                    SetNG();
                    stopwatch.Stop();
                    TimeSpan timeSpan = stopwatch.Elapsed;
                    Console.WriteLine(timeSpan.ToString(@"mm\:ss"));
                }
                else
                {
                    SetNG();
                }
            }
           
        }

        public static BackupData RecoveryData ()
        {
            //if (File.Exists(BackupFile))
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            //    Stream stream = new FileStream(BackupFile, FileMode.Open);
            //    T mapping = (T)xmlSerializer.Deserialize(stream);
            //    stream.Close();
            //    return mapping;
            //}
            //else
            //{
            //    T generic = (T)Activator.CreateInstance(typeof(T));

            //    //

            //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            //    Stream stream = new FileStream(BackupFile, FileMode.Create);
            //    using (XmlWriter xmlwriter = new XmlTextWriter(stream, Encoding.UTF8))
            //    {
            //        xmlSerializer.Serialize(xmlwriter, generic);
            //        xmlwriter.Close();
            //    }
            //    stream.Close();
            //    return generic;
            //}
            if (Checkok())
            {
                BackupData backup = new BackupData();
                using (StreamReader sr = new StreamReader(BackupFile))
                {
                    string a = sr.ReadToEnd();
                    backup = JsonSerializer.Deserialize<BackupData>(a);
                }
                return backup;
            }
            else
            {
                BackupData backup = new BackupData();
                return backup;
            }
           
        }

        public static void BackupDataAct(object data)
        {
            //Type type = data.GetType();
            //XmlSerializer xmlSerializer = new XmlSerializer(type);
            //using (TextWriter textWriter = new StreamWriter(BackupFile))
            //{
            //    xmlSerializer.Serialize(textWriter, data);
            //    textWriter.Close();
            //}

            string json = JsonSerializer.Serialize(data, data.GetType());
            using (StreamWriter sw = new StreamWriter(BackupFileclone))
            {
                sw.WriteLine(json);
            }
            using (StreamWriter sw = new StreamWriter(BackupFile))
            {
                _ = sw.WriteLineAsync(json);
            }
        }
        public static bool Checkok()
        {
            try
            {
                string a = string.Empty;
                BackupData backupData = new BackupData();
                using (StreamReader sr = new StreamReader(BackupFileclone))
                {
                   a = sr.ReadToEnd();
                }
                backupData =  JsonSerializer.Deserialize<BackupData>(a);
                if (backupData != null)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static void SetOK()
        {
            using (StreamWriter sw = new StreamWriter(CheckFile))
            {
                sw.Write("false");
            }
        }
        public static void SetNG()
        {
            using (StreamWriter sw = new StreamWriter(CheckFile))
            {
                sw.Write("true");
            }
        }
        public static bool CheckUnsual()
        {
            using (StreamReader sr = new StreamReader(CheckFile))
            {
                var a = sr.ReadToEnd();
                if (a.Contains("false"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
