namespace FeelOfTravel.Model.Utils
{
    using System;
    using System.Text;

    public static class ScriptGenerator
    {
        public static string InsertBoldTag(string textBoxClientId)
        {
            return GenerateWrapperCode(textBoxClientId, "insertBold", "<b>", "</b>");
        }

        public static string InsertItalicsTag(string textBoxClientId)
        {
            return GenerateWrapperCode(textBoxClientId, "insertItalics", "<i>", "</i>");
        }

        public static string InsertReturnCaretTag(string textBoxClientId)
        {
            return GenerateInsertCode(textBoxClientId, "insertReturnCaret", "<br/>");
        }

        public static string EnableSaveButton(string saveButtonClientId, string functionName)
        {
            Action<StringBuilder> body = (sb) =>
            {
                sb.Append(string.Format("var saveButton = document.getElementById('{0}');", saveButtonClientId));
                sb.Append("saveButton.disabled = false;");
            };

            var script = WrapSingleFunctionScript(body, "enableButton");
            return script;
        }

        //TODO: use GenerateCustomScript
        private static string WrapSingleFunctionScript(Action<StringBuilder> functionBody, string functionName)
        {
            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">");
            sb.Append(string.Format("function {0}()", functionName));
            sb.Append("{");
            
            functionBody(sb);

            sb.Append("} </script>");

            return sb.ToString();
        }

        public static string GenerateCustomScript(string body)
        {
            var sb = new StringBuilder();
            
            sb.Append("<script type=\"text/javascript\">");
            sb.Append(body);
            sb.Append("</script>");

            return sb.ToString();
        }

        private static string GenerateWrapperCode(string textBoxClientId, string functionName, 
            string startTag, string endTag)
        {
            Action<StringBuilder> body = (sb) =>
            {
                sb.Append(string.Format("var textBox = document.getElementById('{0}');", textBoxClientId));
                sb.Append(string.Format("wrapSelection(textBox, '{0}', '{1}');", startTag, endTag));
            };

            return WrapSingleFunctionScript(body, functionName);
        }

        private static string GenerateInsertCode(string textBoxClientId, string functionName, string singleTag)
        {
            Action<StringBuilder> body = (sb) =>
            {
                sb.Append(string.Format("var textBox = document.getElementById('{0}');", textBoxClientId));
                sb.Append(string.Format("replaceSelection(textBox, '{0}');", singleTag));
            };

            return WrapSingleFunctionScript(body, functionName);
        }
    }
}