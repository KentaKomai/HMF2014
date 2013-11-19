using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;

namespace facematchsample2
{
    class HmfListeningAssist
    {
        private SpeechLib.SpInProcRecoContext recognize_rule = null;
        private SpeechLib.ISpeechRecoGrammar RecognizerGrammarRule = null;
        private SpeechLib.ISpeechGrammarRule RecognizerGrammarRuleGrammarRule = null;

        public HmfListeningAssist() {
            this.recognize_rule = new SpeechLib.SpInProcRecoContext();
        }
    }
}
