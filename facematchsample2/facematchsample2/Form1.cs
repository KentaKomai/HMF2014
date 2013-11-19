using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using OpenCvSharp;
using Gapi.Search;
using Gapi.Language;


namespace facematchsample2
{
    public partial class Form1 : Form
    {
        private CvCapture left_camera_capture;
        private CvCapture right_camera_capture;
        private IplImage left_camera_image;
        private IplImage right_camera_image;
        private IplImage camera_on_text_image;
        private Thread left_camera_thread;
        private Thread right_camera_thread;

        private CvFont font = new CvFont(FontFace.HersheySimplex, 1.0, 1.0, 0, 2, LineType.Link8);

        private Boolean warai_flg = false;
        HmfHearingAssist hearing_mod;
        HmfSpeechAssist speech_mod = new HmfSpeechAssist();

        public Form1()
        {
            InitializeComponent();
            hearing_mod = new HmfHearingAssist();
            checkBox1.Checked = false;

            this.label1.Parent = this.pictureBox1;
            label1.BackColor = Color.Transparent;

			left_camera_capture = Cv.CreateCameraCapture(0);
            right_camera_capture = Cv.CreateCameraCapture(0);

            left_camera_thread = new Thread(new ThreadStart(left_camera_roop));
            right_camera_thread = new Thread(new ThreadStart(right_camera_roop));
            left_camera_thread.Start();
	        right_camera_thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string speech = textBox1.Text;
            text_loop(speech);
        }

        private void left_camera_roop()
        {
            while ((left_camera_image = Cv.QueryFrame(left_camera_capture)) != null )
            {
                lock (pictureBox1)
                {
                    if (warai_flg) pictureBox1.Image = (HmfCameraAssist.FaceDe(left_camera_image)).ToBitmap();
                    else pictureBox1.Image = left_camera_image.ToBitmap();
                    System.Threading.Thread.Sleep(30);
                    Application.DoEvents();
                }
            }
        }

        private void right_camera_roop()
        {
            while ((right_camera_image = Cv.QueryFrame(right_camera_capture)) != null)
            {
                if (warai_flg) pictureBox2.Image = (HmfCameraAssist.FaceDe(right_camera_image)).ToBitmap();
                else pictureBox2.Image = right_camera_image.ToBitmap();
                System.Threading.Thread.Sleep(30);
                Application.DoEvents();
            }
        }

        private void text_loop(string speech_string)
        {
            label1.Visible = true;
            int interval = 0;
            label1.Text = speech_string;
            //speech_mod.freeSpeech(speech_string);
            speech_mod.changeMode(speech_string);
            while ((camera_on_text_image = Cv.QueryFrame(left_camera_capture)) != null)
            {
                if (interval >= 800) { break; }
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
                interval += 10;
            }
            label1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            left_camera_thread.Abort();
            right_camera_thread.Abort();
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            warai_flg = checkBox1.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.hearing_mod.Hypothesis +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult result)
                {
                    string strText = result.PhraseInfo.GetText(0, -1, true);
                };

            this.hearing_mod.Recognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
                {
                    string strText = isrr.PhraseInfo.GetText(0, -1, true);
                    text_loop(strText);
                };

            this.hearing_mod.StartStream +=
                delegate(int streamNumber, object streamPosition)
                {
                    text_loop("");
                };
            this.hearing_mod.FalseRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult isrr)
                {
                    text_loop( "--ERROR!--" );
                };

            this.hearing_mod.DictationRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
                {
                    string strText = isrr.PhraseInfo.GetText(0, -1, true);
                };
        }
    }
}
