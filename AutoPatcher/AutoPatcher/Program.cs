using System;
using Designer;
using AutoPatcherLib;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace AutoPatcher
{
    public class Program
    {
        static void Main()
        {
            AutoPatcherLib.AutoPather.Initialize();
            Designer.Program.Start();
            Designer.Program.SetTitle(AutoPatcherLib.AutoPather.WindowTitle);
            if (AutoPatcherLib.AutoPather.Connect())
            {
                Designer.Program.SetClientVersion(AutoPatcherLib.AutoPather.GetClientVersion());
                Designer.Program.SetServerVersion(AutoPatcherLib.AutoPather.GetServerVersion());
                while (AutoPatcherLib.AutoPather.ClientVersion < AutoPatcherLib.AutoPather.ServerVersion)
                {
                    AutoPatcherLib.AutoPather.StartPatch();
                    while (AutoPatcherLib.AutoPather.DownloadNextFile())
                    {
                        while (AutoPatcherLib.AutoPather.Downloading)
                        {
                            Thread.Sleep(50);
                            Designer.Program.ChangeProgress(AutoPatcherLib.AutoPather.CurrentFilePercentage);
                        }
                        Designer.Program.ChangeOverallProgress(AutoPatcherLib.AutoPather.GetOverallPercentage());
                    }
                    Designer.Program.ChangeOverallProgress(0);
                    AutoPatcherLib.AutoPather.EndPatch();
                }
                AutoPatcherLib.AutoPather.RefreshExe();
            }
            Designer.Program.FinishUpdating(0);
            Thread.Sleep(1000);
            AutoPatcherLib.AutoPather.StartGame();
            Environment.Exit(0);
        }
    }
}
