using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TheWorldTree.HtmlExtension
{
    public static class ControlExtension
    {
        public static IHtmlContent LabelLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object attributes )
        {
            string result;
            TagBuilder lable = new TagBuilder("label");
            lable.MergeAttribute("class", "layui-form-label");
            var label = helper.LabelFor(expression, attributes);
            lable.InnerHtml.AppendHtml(label);
            using (var sw = new System.IO.StringWriter())
            {
                lable.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = sw.ToString();
            }

            return new HtmlString(result);
        }
    }
}
