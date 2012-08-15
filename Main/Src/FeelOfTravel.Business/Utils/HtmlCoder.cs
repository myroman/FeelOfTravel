namespace FeelOfTravel.Business.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;

    // It have rules to encode html to prevent XSS.
    public static class HtmlCoder
    {
        private const string UOPENING_BRACKET = "&lt;";//unscreened tag
        private const string UCLOSING_BRACKET = "&gt;";//unscreened tag

        private static Dictionary<string, string> ScreenTagsMap
        {
            get
            {
                return new Dictionary<string, string> { { "&quot;", "\"" }, { "&#39;", "'" } };
            }
        }

        /// <summary>
        /// Screening html tags.
        /// </summary>
        /// <example>
        /// <br/> -> &lt;b&gt
        /// </example>
        public static string Encode(string s)
        {
            // Encode the string input
            StringBuilder sb = new StringBuilder(HttpUtility.HtmlEncode(s));

            // Selectively allow some tags.
            //unscreen tags without coded names
            foreach (var entry in ScreenTagsMap)
            {
                sb.Replace(entry.Key, entry.Value);
            }

            //unscreen named-tags
            foreach (string tag in new[] { "b", "/b", "i", "/i", "br","br/"})
            {
                UnscreenTagWithBody(sb, tag);
            }

            foreach (string tag in new[] { "img" })
            {
                UnscreenTag(sb, tag);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Use for tags like "<img src="..."/>", "<what_ever_tag attr="" />", etc.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="tag"></param>
        private static void UnscreenTag(StringBuilder stringBuilder, string tag)
        {
            string tagBegin = UOPENING_BRACKET + tag;
            const string TAG_CLOSE = "/" + UCLOSING_BRACKET;
            
            int tagOpenPosition = stringBuilder.ToString().IndexOf(tagBegin);

            while (tagOpenPosition > -1)
            {
                int tagClosePosition = stringBuilder.ToString().IndexOf(TAG_CLOSE, tagOpenPosition);
                if (tagClosePosition > -1)
                {
                    stringBuilder.Replace(tagBegin, "<" + tag, tagOpenPosition, tagBegin.Length);
                    
                    //refresh position
                    tagClosePosition = stringBuilder.ToString().IndexOf(TAG_CLOSE, tagOpenPosition);
                    stringBuilder.Replace(TAG_CLOSE, "/>", tagClosePosition, TAG_CLOSE.Length);
                }
                else return;

                tagOpenPosition = stringBuilder.ToString().IndexOf(tagBegin);
            }
        }

        /// <summary>
        /// Use for tags like "<b></b>", "<i></i>", etc.
        /// </summary>
        private static void UnscreenTagWithBody(StringBuilder stringBuilder, string tag)
        {
            stringBuilder.Replace(UOPENING_BRACKET + tag + UCLOSING_BRACKET, "<" + tag + ">");
        }
    }
}