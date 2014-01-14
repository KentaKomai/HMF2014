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
			heaer = new UcommHearerOne(RecognitionEvent, FalseRecognitionEvent);
            SetHearerEvent();
            this.user = user;
            this.speaker = new UcommSpeaker();
            InitializeComponent();
            mainCameraCapture = Cv.CreateCameraCapture(0);
			Task.Factory.StartNew( mainCameraLoop );
            lblUserGuide.Parent = pbxMainCamera;
            setFormText();

			InitializeVoiceMemo();
        }

        private void SetHearerEvent()
        {
        }

        private void SetHeaerInstance(string matchKeyword)
        {

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

		private UcommRecord ucommRecord = new UcommRecord();
		private void startToolStripMenuItem_Click (object sender, EventArgs e) {
			ucommRecord.StartRec();
			startToolStripMenuItem.Enabled = false;
			stopToolStripMenuItem.Enabled  = true;
		}

		private void stopToolStripMenuItem_Click (object sender, EventArgs e) {
			ucommRecord.StopRec();
			startToolStripMenuItem.Enabled = true;
			stopToolStripMenuItem.Enabled  = false;

			InitializeVoiceMemo();
		}

		private void memoToolStripMenuItem_Click (object sender, EventArgs e) {

		}

		private void InitializeVoiceMemo () {
			voiceMemoToolStripMenuItem.DropDownItems.Clear();
			var listVoiceMemo = ucommRecord.GetListVoiceMemo();
			foreach (var filePath in listVoiceMemo) {
				voiceMemoToolStripMenuItem.DropDownItems.Add(filePath.ToString());
			}
		}

        private void RecognitionEvent(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isr)
        {
            string strText = isr.PhraseInfo.GetText(0, -1, true);
            if (this.heaer.GetType().Name == "UcommHearerOne")
            {
                if (strText == "検索")
                {
                    Console.WriteLine("One : " + strText);
                    this.heaer = new UcommHearerTwoSearch(RecognitionEvent, FalseRecognitionEvent);
                }
                else if (strText == "メモ")
                {
                    Console.WriteLine("One : " + strText);
                    this.heaer = new UcommHearerTwoMemo(RecognitionEvent, FalseRecognitionEvent);
                }
                else if (strText == "終了")
                {
                    Application.Exit();
                }

            }
            else if (this.heaer.GetType().Name == "UcommHearerTwoSearch")
            {
                Console.WriteLine("TwoSearch : " + strText);
                if (strText == "検索")
                {

                }
                else if (strText == "履歴")
                {

                }
                else if (strText == "戻る")
                {
                    this.heaer = new UcommHearerOne(RecognitionEvent, FalseRecognitionEvent);

                }

            }
            else if (this.heaer.GetType().Name == "UcommHearerTwoMemo")
            {
                Console.WriteLine("TwoMemo");
                if (strText == "登録")
                {

                }
                else if (strText == "一覧")
                {

                }
                else if (strText == "登録")
                {

                }
                else if (strText == "戻る")
                {
                    this.heaer = new UcommHearerOne(RecognitionEvent, FalseRecognitionEvent);
                }
            }
        }

		private void PlayVoiceMemo (object sender, ToolStripItemClickedEventArgs e) {
			ucommRecord.StartPlay(e.ClickedItem.Text);
		}

        private void FalseRecognitionEvent(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult isrr)
        {
            Console.WriteLine("FALSE RECOG");
        }
    }
}
