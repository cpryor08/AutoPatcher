using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
namespace Designer
{
    public class Program
    {
        static void Main() { }
        private static Form1 mForm = new Form1();
        public static void Start()
        {
            new Thread(new ThreadStart(RunForm)).Start();
        }
        private static void RunForm()
        {
            System.Windows.Forms.Application.Run(mForm);
        }
        private delegate void ChangeValueDelegate(int Percent);
        private delegate void ChangeTitleDelegate(string Title);
        public static void SetTitle(string Title)
        {
            if (mForm.InvokeRequired)
                mForm.Invoke(new ChangeTitleDelegate(SetTitle), new object[] { Title });
            else
                mForm.Text = Title;
        }
        public static void ChangeProgress(int Percent)
        {
            if (mForm.dlProgressBar.InvokeRequired)
                mForm.dlProgressBar.Invoke(new ChangeValueDelegate(ChangeProgress), new object[] { Percent });
            else
            {
                mForm.dlProgressBar.Value = Percent;
                mForm.dlProgressBar.Update();
            }
        }
        public static void ChangeOverallProgress(int Percent)
        {
            if (mForm.overallProgressBar.InvokeRequired)
                mForm.overallProgressBar.Invoke(new ChangeValueDelegate(ChangeOverallProgress), new object[] { Percent });
            else
            {
                mForm.overallProgressBar.Value = Percent;
                mForm.overallProgressBar.Update();
            }
        }
        public static void SetClientVersion(int Version)
        {
            if (mForm.clientVersionLbl.InvokeRequired)
                mForm.clientVersionLbl.Invoke(new ChangeValueDelegate(SetClientVersion), new object[] { Version });
            else
                mForm.clientVersionLbl.Text = Version.ToString();
        }
        public static void SetServerVersion(int Version)
        {
            if (mForm.serverVersionLbl.InvokeRequired)
                mForm.serverVersionLbl.Invoke(new ChangeValueDelegate(SetServerVersion), new object[] { Version });
            else
                mForm.serverVersionLbl.Text = Version.ToString();
        }
        public static void FinishUpdating(int Num)
        {
            if (mForm.InvokeRequired)
                mForm.Invoke(new ChangeValueDelegate(FinishUpdating), new object[] { Num });
            else
            {
                mForm.dlProgressBar.Value = 100;
                mForm.overallProgressBar.Value = 100;
                mForm.downloadLabel.Text = "Finished Updating... Starting Client.";
                mForm.overallLabel.Text = "";
            }
        }
    }
}
