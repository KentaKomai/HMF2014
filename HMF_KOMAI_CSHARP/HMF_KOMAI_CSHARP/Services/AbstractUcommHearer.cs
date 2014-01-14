using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Threading.Tasks;

using SpeechLib;

namespace HMF_KOMAI_CSHARP.Services
{
    abstract class AbstractUcommHearer
    {
        //音声認識オブジェクト
        protected SpeechLib.SpInProcRecoContext RecognizerRule = null;
        protected SpeechLib.SpInProcRecoContext RecognizerDictation = null;

        //音声認識のための言語モデル
        protected SpeechLib.ISpeechRecoGrammar RecognizerGrammarRule = null;
        protected SpeechLib.ISpeechRecoGrammar RecognizerGrammarDictation = null;

        //音声認識のための言語モデルのルールのトップレベルオブジェクト.
        protected SpeechLib.ISpeechGrammarRule RecognizerGrammarRuleGrammarRule = null;

        protected string DictationString = "";
        protected string MustMatchString = "";
        //中継するデリゲート
        abstract public event _ISpeechRecoContextEvents_RecognitionEventHandler Recognition;           //認識完了時
        abstract public event _ISpeechRecoContextEvents_FalseRecognitionEventHandler FalseRecognition; //認識失敗時
        abstract public event _ISpeechRecoContextEvents_RecognitionEventHandler DictationRecognition;  //Dictationの認識完了時


		static public SpeechLib.SpObjectToken CreateMicrofon()
        {
            SpeechLib.SpObjectTokenCategory objAudioTokenCategory = new SpeechLib.SpObjectTokenCategory();
            objAudioTokenCategory.SetId(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech Server\v11.0\AudioInput", false);
            SpeechLib.SpObjectToken objAudioToken = new SpeechLib.SpObjectToken();
            objAudioToken.SetId(objAudioTokenCategory.Default, @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech Server\v11.0\AudioInput", false);
            return objAudioToken;
        }

        
    }
}
