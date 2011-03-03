using System;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Codefire.Utilities;

namespace MotoTrak.Web
{
    public static class WebExtensions
    {
        public static MvcHtmlString DisplayMessage(this HtmlHelper html)
        {
            var msg = html.ViewContext.TempData["hostMessage"] as string;
            if (string.IsNullOrEmpty(msg)) return null;

            var msgType = MessageType.Information;
            if (html.ViewContext.TempData.ContainsKey("hostMessageType"))
            {
                msgType = (MessageType)html.ViewContext.TempData["hostMessageType"];
            }

            var className = "";
            switch (msgType)
            {
                case MessageType.Information:
                    className = "informationMessage";
                    break;
                case MessageType.Warning:
                    className = "warningMessage";
                    break;
                case MessageType.Error:
                    className = "errorMessage";
                    break;
            }

            var builder = new TagBuilder("div");
            builder.MergeAttribute("id", "uiMessage");
            builder.AddCssClass(className);
            builder.InnerHtml = msg;

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString CssLink(this HtmlHelper html, string cssFile)
        {
            var url = VirtualPathUtility.ToAbsolute(string.Format("~/Content/{0}", cssFile));

            var builder = new TagBuilder("link");
            builder.MergeAttribute("href", url);
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ScriptLink(this HtmlHelper html, string scriptFile)
        {
            var url = VirtualPathUtility.ToAbsolute(string.Format("~/Scripts/{0}", scriptFile));

            TagBuilder builder = new TagBuilder("script");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("type", "text/javascript");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString LimitResults(this HtmlHelper html, string name)
        {
            var builder = new TagBuilder("select");
            builder.MergeAttribute("style", "width:205px");
            if (!string.IsNullOrEmpty(name))
            {
                builder.MergeAttribute("name", name, true);
                builder.MergeAttribute("id", name);
            }

            var selectedValue = html.ViewData.GetOrDefault<int>(name, 25);
            var limitList = new int[] { 25, 50, 100, 250, 500, 1000 };
            var optionBuilder = new StringBuilder();
            foreach (var limit in limitList)
            {
                var limitBuilder = new TagBuilder("option");
                limitBuilder.MergeAttribute("value", limit.ToString());
                if (limit == selectedValue)
                {
                    limitBuilder.MergeAttribute("selected", "selected");
                }
                limitBuilder.InnerHtml = limit + " Records";
                optionBuilder.AppendLine(limitBuilder.ToString(TagRenderMode.Normal));
            }

            builder.InnerHtml = optionBuilder.ToString();

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static string Cycle(this HtmlHelper html, params string[] values)
        {
            var context = html.ViewContext.HttpContext;
            int index = Convert.ToInt32(context.Items["cycle_index"]);

            string returnValue = values[index % values.Length];

            context.Items["cycle_index"] = ++index;

            return returnValue;
        }
    }
}