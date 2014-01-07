using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorService.Speech;

using HMF_KOMAI_CSHARP.Properties;

using SpeechLib;

namespace HMF_KOMAI_CSHARP.Services
{
    public class UcommSpeaker
    {

        private SpeechSynthesizer speaker;
        private SpVoice voice;
        private SpeechVoiceSpeakFlags voiceFlag;
		
        /// <summary>
        /// constructor
        /// </summary>
        public UcommSpeaker()
        {
            voice = new SpVoice();
            voice.Volume = 100;
            voice.Rate = 0;
            voiceFlag = SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
            speaker = new SpeechSynthesizer(Properties.Settings.Default.AZURE_CLIENT_ID, Properties.Settings.Default.AZURE_CLIENT_SECRET);
        }

        /// <summary>
        /// 認証前のアナウンス
        /// </summary>
        public void PromoteCertification()
        {
            voice.Speak("指紋センサーに指を置いて、認証を行ってください。", voiceFlag);
        }

        /// <summary>
        /// 認証完了のアナウンス
        /// </summary>
        public void CompleteCertificate(string username = "Test")
        {
            voice.Speak("認証が完了しました。" + CreateGreeting() + String.Format( " {0}さん", username), voiceFlag);
        }

        /// <summary>
        /// 検索結果を喋らせる
        /// </summary>
        /// <param name="str"></param>
        public void speechSearchResult(String str)
        {

        }

        /// <summary>
        /// スケジュールを喋らせる。
        /// TODO: スケジュール用のオブジェクトとか必要かも
        /// </summary>
        public void speechSchedule()
        {

        }

        /// <summary>
        /// 自由に喋らせる
        /// </summary>
        /// <param name="str">喋らせたい文字列</param>
        public void freeSpeech(String str)
        {
        }

        public void changeMode(String str) {
        }

        /// <summary>
        /// 読み上げスピードの変更
        /// </summary>
        /// <param name="positive"></param>
        public void changeSpeechSpeed(bool positive)
        {
        }

        /// <summary>
        /// 読み上げ音量の変更
        /// </summary>
        /// <param name="positive"></param>
        public void changeSpeechVolume(bool positive)
        {
        }

        private string CreateGreeting()
        {
            string greet = String.Empty;
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());
            if (now.Hour >= 6 && now.Hour <= 10)
                greet = Resources.SPEAK_GREETING_MORNING;
            else if (now.Hour >= 15)
                greet = Resources.SPEAK_GREETING_EVENING;
            else
                greet = Resources.SPEAK_GREETING_NIGHT;
			
            return greet;
        }

    }
}
