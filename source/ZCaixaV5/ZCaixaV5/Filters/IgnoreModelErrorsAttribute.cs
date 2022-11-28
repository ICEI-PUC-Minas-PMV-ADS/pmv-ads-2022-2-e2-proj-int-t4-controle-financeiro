/* 
 * Thanks to: http://mrbigglesworth79.blogspot.com.br/2011/12/partial-validation-with-data.html
 */

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ZCaixaV5.Filters
{
    public class IgnoreModelErrorsAttribute : ActionFilterAttribute
    {
        private readonly string _keysString;

        public IgnoreModelErrorsAttribute(string keys)
        {
            _keysString = keys;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;

            var keyPatterns = _keysString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var t in keyPatterns)
            {
                var keyPattern = t
                    .Trim()
                    .Replace(@".", @"\.")
                    .Replace(@"[", @"\[")
                    .Replace(@"]", @"\]")
                    .Replace(@"\[\]", @"\[[0-9]+\]")
                    .Replace(@"*", @"[A-Za-z0-9]+");
                var matchingKeys = modelState.Keys.Where(x => Regex.IsMatch(x, keyPattern));

                foreach (var matchingKey in matchingKeys)
                    modelState[matchingKey].Errors.Clear();
            }
        }
    }
}