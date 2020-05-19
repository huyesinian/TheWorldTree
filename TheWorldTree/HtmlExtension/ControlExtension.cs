using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace TheWorldTree.HtmlExtension
{
    /// <summary>
    /// layui控件扩展
    /// </summary>
    public static class ControlExtension
    {
        /// <summary>
        /// layui 的lable
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="attributes">其他的属性</param>
        /// <returns></returns>
        public static IHtmlContent LabelLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object attributes = null)
        {
            string result;
            var name = (expression.Body as MemberExpression).Member.Name;//获取字段的名称
            TagBuilder label = new TagBuilder("label");
            label.MergeAttribute("class", "layui-form-label");
            label.MergeAttributes(new RouteValueDictionary(attributes));
            label.MergeAttribute("name", name);
            label.MergeAttribute("id", name);
            var ss = helper.LabelFor(expression);
            label.InnerHtml.AppendHtml(ss);
            using (var sw = new System.IO.StringWriter())
            {
                label.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = sw.ToString();
            }
            return new HtmlString(result);
        }

        /// <summary>
        /// layui文本框
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="type">文本类型</param>
        /// <param name="autocomplete">是否自动填充</param>
        /// <param name="verify">验证</param>
        /// <param name="attributes">属性</param>
        /// <returns></returns>
        public static IHtmlContent EditorLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string type = null, string para = null, string autocomplete = null, string verify = null, object attributes = null)
        {
            string result;
            var name = (expression.Body as MemberExpression).Member.Name;//获取字段的名称
            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("class", "layui-input");
            input.MergeAttributes(new RouteValueDictionary(attributes));
            input.Attributes.Add("type", type ?? "text");
            input.Attributes.Add("autocomplete", autocomplete ?? "off");
            if (verify != null)
            {
                input.Attributes.Add("lay-verify", verify);
            }
            input.MergeAttribute("name", name);
            input.MergeAttribute("id", name);
            input.MergeAttribute("value", para);
            using (var sw = new System.IO.StringWriter())
            {
                input.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = sw.ToString();
            }
            return new HtmlString(result);
        }

        /// <summary>
        /// layui文本域
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="verify">验证</param>
        /// <param name="attributes">属性</param>
        /// <returns></returns>
        public static IHtmlContent TextareaLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string para = null, string verify = null, object attributes = null)
        {
            string result;
            var name = (expression.Body as MemberExpression).Member.Name;//获取字段的名称
            TagBuilder textarea = new TagBuilder("textarea");
            textarea.MergeAttribute("class", "layui-textarea");
            textarea.MergeAttributes(new RouteValueDictionary(attributes));
            if (verify != null)
            {
                textarea.Attributes.Add("lay-verify", verify);
            }
            textarea.MergeAttribute("name", name);
            textarea.MergeAttribute("id", name);
            textarea.MergeAttribute("value", para);
            using (var sw = new System.IO.StringWriter())
            {
                textarea.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = sw.ToString();
            }
            return new HtmlString(result);
        }




        /// <summary>
        /// layui开开关
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="attributes">属性</param>
        /// <returns></returns>
        public static IHtmlContent SwitchLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string laytext = null, object attributes = null)
        {
            string result;
            var name = (expression.Body as MemberExpression).Member.Name;//获取字段的名称
            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("lay-skin", "switch");
            input.MergeAttributes(new RouteValueDictionary(attributes));
            input.Attributes.Add("lay-text", laytext ?? "NO|OFF");
            input.MergeAttribute("name", name);
            input.MergeAttribute("id", name);
            input.MergeAttribute("type", "checkbox");
            using (var sw = new System.IO.StringWriter())
            {
                input.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = sw.ToString();
            }
            return new HtmlString(result);
        }

        /// <summary>
        /// layui复选框
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static IHtmlContent BoxLayuiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items,string controlType ,int column = 0, object attributes = null)
        {
            //int moment = column;//暂存行数
            string result="";
            if (items != null && items.Any())
            {
                //int count = 1;
                ///获取表达式属性名称
                var name = (expression.Body as MemberExpression).Member.Name;//获取字段的名称
                foreach (var item in items)
                {
                    TagBuilder checkbox = new TagBuilder("input");
                    checkbox.Attributes.Add("type", controlType);
                    checkbox.Attributes.Add("name", name);
                    checkbox.Attributes.Add("value", item.Value);
                    checkbox.Attributes.Add("title", item.Text);
                    checkbox.Attributes.Add("lay-filter", controlType + "s");
                    if (item.Selected)
                    {
                        checkbox.Attributes.Add("checked", "checked");
                    }
                    if (attributes != null)
                    {
                        checkbox.MergeAttributes(new RouteValueDictionary(attributes));
                    }
                    using (var sw = new System.IO.StringWriter())
                    {
                        checkbox.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                        result += sw.ToString();
                    }
                }
               

            }
            return new HtmlString(result);
        }


    }
}
