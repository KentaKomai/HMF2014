using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gapi;
using Gapi.Search;
using Gapi.Language;

namespace facematchsample2
{
    class HmfGoogleService
    {
        public static SearchResults Search(string search_text) {
            SearchResults results = Searcher.Search(SearchType.Web, search_text);
            return results;
        }

		[Obsolete("翻訳APIもう使えない")]
        public static string Transrate(string transrat_text) {
            string transrated = Translator.Translate("Hello world!", Language.English, Language.Japanese);
            return transrated;
        }
    }
}
