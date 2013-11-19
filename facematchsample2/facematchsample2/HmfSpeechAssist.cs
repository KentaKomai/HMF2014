using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;

namespace facematchsample2
{
    class HmfSpeechAssist
    {
        private SpVoice tts;
        private SpeechVoiceSpeakFlags speechFlg;
        //private ISpeechObjectTokens voiceInfo;

        /// <summary>
        /// constructor
        /// </summary>
        public HmfSpeechAssist()
        {
            this.tts = new SpVoice();
            this.tts.Volume = 100;
            this.tts.Rate = 0;
            this.speechFlg = SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
        }

        /// <summary>
        /// 認証前のアナウンス
        /// </summary>
        public void promoteCertification()
        {
            tts.Speak("認証してください", speechFlg);
        }

        /// <summary>
        /// 認証完了のアナウンス
        /// </summary>
        public void completeCertificate()
        {
            tts.Speak("認証が完了しました。おはようございます", speechFlg);
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
            tts.Speak(str, speechFlg);
        }

        public void changeMode(String str) {
            tts.Speak(str+"モードになりました。", speechFlg);
        }

        /// <summary>
        /// 読み上げスピードの変更
        /// </summary>
        /// <param name="positive"></param>
        public void changeSpeechSpeed(bool positive)
        {
            if (positive)
            {
                this.tts.Rate++;
            }
            else
            {
                this.tts.Rate--;
            }
        }

        /// <summary>
        /// 読み上げ音量の変更
        /// </summary>
        /// <param name="positive"></param>
        public void changeSpeechVolume(bool positive)
        {
            if (positive)
            {
                this.tts.Volume += 10;
            }
            else
            {
                this.tts.Volume -= 10;
            }
        }

    }
}
