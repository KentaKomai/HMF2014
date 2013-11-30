using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using OpenCvSharp;
using WpfFaceMatch.Models;

namespace WpfFaceMatch.Views {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow {
		private CvCapture left_camera_capture;
		private CvCapture right_camera_capture;
		private IplImage  left_camera_image;
		private IplImage  right_camera_image;
		private IplImage  camera_on_text_image;
		private Thread    left_camera_thread;
		private Thread    right_camera_thread;
		HmfSpeechAssist   speech_mod = new HmfSpeechAssist();

		public MainWindow() {
			InitializeComponent();
			speech_mod.setSpeechSpeed((int)slideSpeed.Value);
			speech_mod.setSpeechVolume((int)slideVolume.Value);
		}

		private void btnSpeek_Click (object sender, RoutedEventArgs e) {
			string speech = txtSpeek.Text;
            text_loop(speech);
		}

		private void text_loop(string speech_string) {
			label1.Visibility = Visibility.Collapsed;
			label1.Content    = speech_string;
            int interval = 0;
			//speech_mod.freeSpeech(speech_string);
			speech_mod.freeSpeech(speech_string);
			//while ((camera_on_text_image = Cv.QueryFrame(left_camera_capture)) != null)
			//{
			//	if (interval >= 800) { break; }
			//	Thread.Sleep(10);
			//	Application.DoEvents();
			//	interval += 10;
			//}
		}

		private void slideSpeed_ValueChanged (object sender, RoutedPropertyChangedEventArgs<double> e) {
			speech_mod.setSpeechSpeed((int)slideSpeed.Value);
		}

		private void slideVolume_ValueChanged (object sender, RoutedPropertyChangedEventArgs<double> e) {
			speech_mod.setSpeechVolume((int)slideVolume.Value);
		}

		private void txtSpeed_KeyDown (object sender, System.Windows.Input.KeyEventArgs e) {
		}
	}
}
