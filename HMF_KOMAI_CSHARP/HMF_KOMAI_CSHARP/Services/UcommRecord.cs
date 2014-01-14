using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMF_KOMAI_CSHARP.Services {
	class UcommRecord {
		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int mciSendString(string command, StringBuilder buff = null, int sizeBuff = 0, int callback = 0);
		private const string micDeviceName  = "MIC";
		private const string playDeviceName = "X1";

		/// <summary>
		/// 録音開始
		/// </summary>
		public void StartRec () {
			mciSendString("open new type waveaudio alias " + micDeviceName);
			mciSendString("set " + micDeviceName);
			mciSendString("record " + micDeviceName);
		}

		/// <summary>
		/// 録音終了・指定場所への保存処理
		/// </summary>
		private const string saveDir = @"C:\HME_VOICE_MEMO\";
		public void StopRec () {
			mciSendString("stop " + micDeviceName);

			var date     = DateTime.Now.ToString("yyyy-MM-dd");
			var fileName = saveDir + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".wav";

			if (!Directory.Exists(saveDir)) {
				Directory.CreateDirectory(saveDir);
			}

			mciSendString("save " + micDeviceName + " \"" + fileName + "\"");
			InsertVoiceMemo(date, fileName);

			mciSendString("close " + micDeviceName);
		}

		/// <summary>
		/// 再生開始（再生終わるまで次操作不能）
		/// </summary>
		/// <param name="filePath"></param>
		public void StartPlay (string filePath) {
			mciSendString("open \"" + filePath + "\" alias " + playDeviceName);
			mciSendString("play " + playDeviceName + " wait");
			mciSendString("close " + playDeviceName);
		}
		
		/// <summary>
		/// 以下、DB関連処理を記述。
		/// 後日別クラスに用意されるDBクラスを利用する処理に変更予定。
		/// </summary>
		private const  String DB_USER       = "hmfuser";
		private const  String DB_PASSWORD   = "";
		private const  String DB_NAME       = "hmf";
		private const  String DB_HOST       = "localhost";
		private static MySqlConnection conn = new MySqlConnection("userid=" + DB_USER + ";password=" + DB_PASSWORD + ";database=" + DB_NAME + ";Host=" + DB_HOST);
		private const  string FILE_TYPE      = "voice";

		private bool InsertVoiceMemo (string date, string fileName) {
			// personal_id は personal_tableに存在するレコードのidを参照している。
			// とりあえず整数値1をハードコーディングしておく。
			var sql = new MySqlCommand(@"INSERT INTO memo_table (personal_id ,  record_date,  file_type,  file_path)
										  VALUES                (1           , @record_date, @file_type, @file_path);", conn
										);
			sql.Parameters.AddWithValue("record_date", date);
			sql.Parameters.AddWithValue("file_type"  , FILE_TYPE);
			sql.Parameters.AddWithValue("file_path"  , fileName);

			try {
				conn.Open();
				return sql.ExecuteNonQuery() != -1 ? true : false ;
			} catch(MySqlException e) {
				MessageBox.Show("▂▅▇█▓▒░(’ω’)░▒▓█▇▅▂ うわあああああああああああ\r\n" + e.Message);
			} finally {
				if (conn.State == ConnectionState.Open) conn.Close();
			}

			return false;
		}

		public List<string> GetListVoiceMemo () {
			var sql = new MySqlCommand(@"SELECT file_path FROM memo_table WHERE file_type = @file_type ORDER BY memo_id DESC LIMIT 10", conn);
			sql.Parameters.AddWithValue("file_type", FILE_TYPE);

			var listFilePath = new List<string>();
			try {
				conn.Open();
				var reader = sql.ExecuteReader();
				while (reader.Read()) {
					listFilePath.Add(reader[0].ToString());
				}
			} catch (MySqlException e) {
				MessageBox.Show("▂▅▇█▓▒░(’ω’)░▒▓█▇▅▂ うわあああああああああああ\r\n" + e.Message);
			} finally {
				if (conn.State == ConnectionState.Open) conn.Close();
			}

			return listFilePath;
		}
	}
}