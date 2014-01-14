using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

using HMF_KOMAI_CSHARP.DataModels;
using HMF_KOMAI_CSHARP.Services;

namespace HMF_KOMAI_CSHARP
{
    public partial class MainForm : Form
    {
        private User user;
        private CvCapture mainCameraCapture;
        private IplImage mainCameraImage;
		private UcommSpeaker speaker;

        private AbstractUcommHearer heaer;
		
        public MainForm(User user)
        {
			heaer = new UcommHearerOne();
            heaer.Recognition += 
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
				{
					string strText = isrr.PhraseInfo.GetText(0, -1, true);
					Console.WriteLine(strText);
				};
			heaer.FalseRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult isrr)
                {
                    Console.WriteLine("--ERROR!--");
                };
			heaer.DictationRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
                {
                    string strText = isrr.PhraseInfo.GetText(0, -1, true);
                };

            this.user = user;
            this.speaker = new UcommSpeaker();
            InitializeComponent();
            mainCameraCapture = Cv.CreateCameraCapture(0);
			Task.Factory.StartNew( mainCameraLoop );
            lblUserGuide.Parent = pbxMainCamera;
            setFormText();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainCameraCapture.Dispose();
            mainCameraImage.Dispose();
            Application.Exit();
        }

        private void mainCameraLoop()
        {
            while ((mainCameraImage = Cv.QueryFrame(mainCameraCapture)) != null)
            {
                pbxMainCamera.Image = mainCameraImage.ToBitmap();
                Application.DoEvents();
            }
        }

        private void setFormText()
        {
            lblUserStatus.Text = user.FirstName + " is LOGINED.";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainCameraImage.Dispose();
            mainCameraCapture.Dispose();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            speaker.CompleteCertificate(user.FirstName);
        }
    }
}
