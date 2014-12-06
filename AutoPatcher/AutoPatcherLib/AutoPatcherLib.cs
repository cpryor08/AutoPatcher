using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

namespace AutoPatcherLib
{
    public class AutoPather
    {
        private static WebClient webClient;
        public static string WindowTitle = "";
        public static int ClientVersion = 1000;
        public static int ServerVersion = 1000;
        public static bool Patching = false;
        public static bool Downloading = false;
        private static string Host = "";
        public static long TotalBytesDownloaded = 0;
        public static long TotalBytes = 0;
        private static int CurrentFile = 0;
        public static long CurrentFileSize = 0;
        public static int CurrentFilePercentage = 0;
        private static List<string> FileQueue = new List<string>();
        public static void GetFileList()
        {
            string[] FileList = webClient.DownloadString(Host + "/patchinfo.php?version=" + ClientVersion).Split('#');
            long.TryParse(FileList[0], out TotalBytes);
            for (int i = 1; i < FileList.Length; i++)
            {
                if (FileList[i] != "" && FileList[i] != " ")
                {
                    string[] FileDetails = FileList[i].Split(' ');
                    if (!FileQueue.Contains(FileDetails[0]))
                        FileQueue.Add(FileDetails[0]);
                }
            }
        }
        public static int GetClientVersion()
        {
            if (File.Exists("version.dat"))
            {
                int.TryParse(File.ReadAllText("version.dat"), out ClientVersion);
            }
            else
            {
                FileStream FS = File.Create("version.dat");
                FS.Write(System.Text.ASCIIEncoding.ASCII.GetBytes("1000"), 0, 4);
                FS.Close();
            }
            return ClientVersion;
        }
        public static int GetServerVersion()
        {
            int.TryParse(webClient.DownloadString(Host + "/patchinfo.php"), out ServerVersion);
            ServerVersion = Math.Max(1000, ServerVersion);
            return ServerVersion;
        }
        public static int GetOverallPercentage()
        {
            TotalBytesDownloaded += CurrentFileSize;
            CurrentFileSize = 0;
            return (int)Math.Round((decimal)((decimal)TotalBytesDownloaded / (decimal)TotalBytes * 100));
        }
        public static void Initialize()
        {
            LoadSettings();
            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
        }
        public static void StartPatch()
        {
            Patching = true;
            GetFileList();
        }
        public static void RefreshExe()
        {
            try
            {
                webClient.DownloadFile(Host + "/patches/Conquer.exe", "Conquer.exe");
            }
            catch { }
        }
        public static bool DownloadNextFile()
        {
            if (CurrentFile < FileQueue.Count)
            {
                Downloading = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(Download));
                return true;
            }
            return false;
        }
        private static void Download(object sender)
        {
            string filePath = FileQueue[CurrentFile].Replace("patches/" + ClientVersion + "/", "");
            string dirPath = Path.GetDirectoryName(filePath);
            if (dirPath != "")
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
            webClient.DownloadFileAsync(new Uri(Host + "/" + FileQueue[CurrentFile]), filePath);
        }
        public static void EndPatch()
        {
            CurrentFile = 0;
            TotalBytesDownloaded = 0;
            TotalBytes = 0;
            CurrentFileSize = 0;
            CurrentFilePercentage = 0;
            FileQueue.Clear();
            ClientVersion++;
            FileStream FS = File.OpenWrite("version.dat");
            FS.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(ClientVersion.ToString()), 0, ClientVersion.ToString().Length);
            FS.Close();
        }
        private static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            CurrentFileSize = e.TotalBytesToReceive;
            CurrentFilePercentage = int.Parse(Math.Truncate(percentage).ToString());
        }
        private static void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            CurrentFile++;
            Downloading = false;
        }
        public static bool Connect()
        {
            return true;
        }
        private static void LoadSettings()
        {
            IniFile sF = new IniFile("settings.ini");
            WindowTitle = sF.ReadString("Main", "Title");
            Host = "http://" + sF.ReadString("Main", "Host");
            sF.Close();
        }
        public static void StartGame()
        {
            if (File.Exists("Conquer.exe"))
            {
                ProcessStartInfo PSI = new ProcessStartInfo();
                PSI.FileName = "Conquer.exe";
                PSI.Arguments = "blacknull";
                Process P = new Process();
                P.StartInfo = PSI;
                P.Start();
            }
        }
    }
}
