using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 基本验证
    /// </summary>
    public abstract class BaseVerifyController : BaseController
    {
        /// <summary>
        /// 用户登录拦截验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out byte[] result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Account/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }


        /// <summary>
        /// 获取实体验证错误信息
        /// </summary>
        /// <returns></returns>
        public string GetEntityError()
        {
            var msg = string.Empty;
            foreach (var value in ModelState.Values)
            {
                if (value.Errors.Count > 0)
                {
                    foreach (var error in value.Errors)
                    {
                        msg = msg + error.ErrorMessage;
                    }
                }
            }
            return msg;
        }
    }
}