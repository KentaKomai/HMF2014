using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMF_KOMAI_CSHARP.Services {
	class UcommRecord {
		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int mciSendString(string command, StringBuilder buff = null, int sizeBuff = 0, int callback = 0);
		private const string deviceName = "MIC";

		public void StartRec () {
			mciSendString("open new type waveaudio alias " + deviceName);
			mciSendString("set " + deviceName);
			mciSendString("record " + deviceName);
		}

		public void StopRec () {
			mciSendString("stop " + deviceName);

			var date = new DateTime();
			var saveVoiceMemo    = new SaveFileDialog();
			saveVoiceMemo.Filter = "Waveファイル(.wav)|*.wav";

			if (saveVoiceMemo.ShowDialog() == DialogResult.OK) {
				mciSendString("save " + deviceName + " " + saveVoiceMemo.FileName);
			}

			mciSendString("close " + deviceName);
		}
	}
}
