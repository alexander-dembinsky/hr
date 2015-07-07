using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HR.Infrastructure.Helpers
{
    public static class HtmlHelperExtensions
    {
        static string GetModelPropertyName<TModel>(Expression<Func<TModel, bool>> expr)
        {
            if (expr == null)
            {
                throw new ArgumentNullException("expr");
            }
            
            var lambda = expr as LambdaExpression;
            
            var property = lambda.Body as MemberExpression;

            if (property == null)
            {
                throw new NotSupportedException("Expression should have form (model) => model.Property");
            }

            string propertyName = property.Member.Name;
            
            return propertyName;
        }

        public static MvcHtmlString MaterializeCheckboxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expr, string label = null)
        {
            var lambda = expr as LambdaExpression;
            string propertyName = GetModelPropertyName(expr);

            var function = (Func<TModel, bool>) lambda.Compile();

            bool active = function(helper.ViewData.Model);
            
            TagBuilder inputTag = new TagBuilder("input");
            var attributes = new 
            {  
                type = "checkbox",
                name = propertyName,
                id = propertyName,
                value = active.ToString().ToLower()
            };

            inputTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));

            if (active)
            {
                inputTag.MergeAttribute("checked", "checked");
            }

            inputTag.MergeAttribute("data-val", "true");
            TagBuilder labelTag = new TagBuilder("label");
            labelTag.MergeAttribute("for", propertyName);
            labelTag.SetInnerText(label == null ? propertyName : label);
            
            string resultHtml = string.Format("{0}{1}", inputTag.ToString(), labelTag.ToString());

            return new MvcHtmlString(resultHtml);
        }

        public static MvcHtmlString MaterializeSwitch<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expr, string enabledLabel, string disabledLabel)
        {
            var lambda = expr as LambdaExpression;
            string propertyName = GetModelPropertyName(expr);

            var function = (Func<TModel, bool>) lambda.Compile();

            bool active = function(helper.ViewData.Model);

            var div = new TagBuilder("div");
            div.AddCssClass("switch");

            var label = new TagBuilder("label");

            var input = new TagBuilder("input");
            if (active)
            {
                input.MergeAttribute("checked", "checked");
            }

            input.MergeAttribute("type", "checkbox");
            input.MergeAttribute("name", propertyName);
            input.MergeAttribute("value", active.ToString().ToLower());

            var lever = new TagBuilder("span");
            lever.AddCssClass("lever");

            label.InnerHtml = string.Format("{0}{1}{2}{3}", enabledLabel, input.ToString(), lever.ToString(), disabledLabel);
            div.InnerHtml = label.ToString();

            return new MvcHtmlString(div.ToString());
        }
    }
}