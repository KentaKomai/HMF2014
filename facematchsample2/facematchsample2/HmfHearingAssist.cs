using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;
using System.Windows.Forms;

namespace facematchsample2
{
    class HmfHearingAssist
    {
        //音声認識オブジェクト
        private SpeechLib.SpInProcRecoContext RecognizerRule = null;
        private SpeechLib.SpInProcRecoContext RecognizerDictation = null;

        //音声認識のための言語モデル
        private SpeechLib.ISpeechRecoGrammar RecognizerGrammarRule = null;
        private SpeechLib.ISpeechRecoGrammar RecognizerGrammarDictation = null;

        //音声認識のための言語モデルのルールのトップレベルオブジェクト.
        private SpeechLib.ISpeechGrammarRule RecognizerGrammarRuleGrammarRule = null;

        private string DictationString = "";
        private string MustMatchString = "";

        //中継するデリゲート
        public event _ISpeechRecoContextEvents_StartStreamEventHandler StartStream;           //ストリームが開始された時
        public event _ISpeechRecoContextEvents_HypothesisEventHandler Hypothesis;             //認識途中でなんか拾った時
        public event _ISpeechRecoContextEvents_RecognitionEventHandler Recognition;           //認識完了時
        public event _ISpeechRecoContextEvents_FalseRecognitionEventHandler FalseRecognition; //認識失敗時
        public event _ISpeechRecoContextEvents_EndStreamEventHandler EndStream;				  //終了時:w
        public event _ISpeechRecoContextEvents_RecognitionEventHandler DictationRecognition;  //Dictationの認識完了時

        /// <summary>
        /// constructor
        /// </summary>
        public HmfHearingAssist()
        {

            //ルール認識 音声認識オブジェクトの生成
            this.RecognizerRule = new SpeechLib.SpInProcRecoContext();
            this.RecognizerDictation = new SpeechLib.SpInProcRecoContext();
            //マイクから拾ってね。
            this.RecognizerRule.Recognizer.AudioInput = CreateMicrofon();
            this.RecognizerDictation.Recognizer.AudioInput = CreateMicrofon();

            //イベント設定(中継)

            //認識途中のデフォルト処理
            this.RecognizerRule.Hypothesis +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult result)
                { this.Hypothesis(streamNumber, streamPosition, result); };

            //認識完了時のデフォルト処理
            this.RecognizerRule.Recognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
                {
                    //ここでDictationでマッチした語を見て、 必ず入っていなければいけない文字列がなければ握りつぶす.
                    if (this.MustMatchString.Length >= 1
                         && this.DictationString.IndexOf(this.MustMatchString) <= -1
                       )
                    {//握りつぶす.
                        this.FalseRecognition(streamNumber, streamPosition, isrr);
                        return;
                    }
                    this.Recognition(streamNumber, streamPosition, srt, isrr);
                };
            //ストリーム開始時のデフォルト処理
            this.RecognizerRule.StartStream +=
                delegate(int streamNumber, object streamPosition)
                {
                    this.DictationString = ""; //開始時に前回マッチした文字列を消す.
                    this.StartStream(streamNumber, streamPosition);
                };
            //認識失敗時のデフォルト処理
            this.RecognizerRule.FalseRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult isrr)
                { this.FalseRecognition(streamNumber, streamPosition, isrr); };
            //ストリーム終了時のデフォルト処理
            this.RecognizerRule.EndStream +=
                delegate(int streamNumber, object streamPosition, bool streamReleased)
                { this.EndStream(streamNumber, streamPosition, streamReleased); };


            //Dictationでマッチした文字列. RuleよりDictationの方がマッチ順は早いらしい。
            this.RecognizerDictation.Recognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.SpeechRecognitionType srt, SpeechLib.ISpeechRecoResult isrr)
                {
                    //マッチした文字列の記録
                    this.DictationString = isrr.PhraseInfo.GetText(0, -1, true);
                    //コールバック用のデリゲートを呼ぶ.(これくらいあってもいいかな)
                    this.DictationRecognition(streamNumber, streamPosition, srt, isrr);
                };

            //言語モデルの作成
            this.RecognizerGrammarRule = this.RecognizerRule.CreateGrammar(0);
            this.RecognizerGrammarDictation = this.RecognizerDictation.CreateGrammar(0);

            //言語モデルのルールのトップレベルを作成する.
            this.RecognizerGrammarRuleGrammarRule = this.RecognizerGrammarRule.Rules.Add("TopLevelRule", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic);
            //文字列の追加.
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "検索");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "予定");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "認識");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "メモ");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "認証");

            //ルールを反映させる。
            this.RecognizerGrammarRule.Rules.Commit();
            this.RecognizerGrammarRule.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
            this.RecognizerGrammarDictation.DictationSetState(SpeechRuleState.SGDSInactive);
        }

        static public SpeechLib.SpObjectToken CreateMicrofon()
        {
            SpeechLib.SpObjectTokenCategory objAudioTokenCategory = new SpeechLib.SpObjectTokenCategory();
            objAudioTokenCategory.SetId(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech Server\v11.0\AudioInput", false);
            SpeechLib.SpObjectToken objAudioToken = new SpeechLib.SpObjectToken();
            objAudioToken.SetId(objAudioTokenCategory.Default, @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech Server\v11.0\AudioInput", false);
            return objAudioToken;
        }

        public void SetString(string str)
        {
            //現在のルールをすべて消す.
            this.RecognizerGrammarRule.Reset(0);
            //言語モデルのルールのトップレベルを作成する.
            this.RecognizerGrammarRuleGrammarRule = this.RecognizerGrammarRule.Rules.Add("TopLevelRule",
                SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic);

            //文字列の追加.
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, this.MustMatchString + str);

            //ルールを反映させる。
            this.RecognizerGrammarRule.Rules.Commit();
            //音声認識開始。(トップレベルのオブジェクトの名前で SpeechRuleState.SGDSActive を指定する.)
            this.RecognizerGrammarRule.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);

            //Dictationベースの音声認識もスタート.
            this.RecognizerGrammarDictation.DictationSetState(SpeechRuleState.SGDSActive);
        }

        public void Hearing()
        {
            //音声認識開始。(トップレベルのオブジェクトの名前で SpeechRuleState.SGDSActive を指定する.)
            this.RecognizerGrammarRule.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
        }
    }
}
