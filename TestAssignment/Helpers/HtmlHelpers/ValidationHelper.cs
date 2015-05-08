using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TestAssignment.Helpers.HtmlHelpers
{
    public static class ValidationHelper
    {
        private static string closingSpan = "</span>";
        public static MvcHtmlString MyValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            TagBuilder errorLeftDiv = new TagBuilder("div");
            errorLeftDiv.AddCssClass("error-left");

            TagBuilder errorInnerDiv = new TagBuilder("div");
            errorInnerDiv.AddCssClass("error-inner");

            var errorSpan = new TagBuilder(helper.ValidationMessageFor(expression).ToString());
            var errorMessage = errorSpan.TagName.CutFrom('>').CutTo('<');


            if (errorMessage == "" || errorMessage == closingSpan)
            {
                return MvcHtmlString.Create("");
            }


            errorInnerDiv.InnerHtml += errorSpan.TagName;



            return MvcHtmlString.Create(errorLeftDiv.ToString(TagRenderMode.Normal)+errorInnerDiv.ToString(TagRenderMode.Normal));
        }
    }
}