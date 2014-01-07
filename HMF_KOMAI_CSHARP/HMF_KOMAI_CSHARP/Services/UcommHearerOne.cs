using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using SpeechLib;

namespace HMF_KOMAI_CSHARP.Services
{
    class UcommHearerOne : AbstractUcommHearer
    {

		//中継するデリゲート
        override public event _ISpeechRecoContextEvents_RecognitionEventHandler Recognition;           //認識完了時
        override public event _ISpeechRecoContextEvents_FalseRecognitionEventHandler FalseRecognition; //認識失敗時
        override public event _ISpeechRecoContextEvents_RecognitionEventHandler DictationRecognition;  //Dictationの認識完了時

        public UcommHearerOne()
        {
            //ルール認識 音声認識オブジェクトの生成
            this.RecognizerRule = new SpeechLib.SpInProcRecoContext();
            this.RecognizerDictation = new SpeechLib.SpInProcRecoContext();
            //マイクから拾ってね。
            this.RecognizerRule.Recognizer.AudioInput = AbstractUcommHearer.CreateMicrofon();
            this.RecognizerDictation.Recognizer.AudioInput = AbstractUcommHearer.CreateMicrofon();

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
            //認識失敗時のデフォルト処理
            this.RecognizerRule.FalseRecognition +=
                delegate(int streamNumber, object streamPosition, SpeechLib.ISpeechRecoResult isrr)
                { this.FalseRecognition(streamNumber, streamPosition, isrr); };
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

			this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "検索");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "メモ");
            this.RecognizerGrammarRuleGrammarRule.InitialState.AddWordTransition(null, "終了");

            //ルールを反映させる。
            this.RecognizerGrammarRule.Rules.Commit();
            this.RecognizerGrammarRule.CmdSetRuleState("TopLevelRule", SpeechRuleState.SGDSActive);
            this.RecognizerGrammarDictation.DictationSetState(SpeechRuleState.SGDSInactive);
        }
    }
}
