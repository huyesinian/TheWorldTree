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
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Account/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        

       
    }
}