using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SjAdmin.Models
{
    public class JsonpResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            string jsoncallback = (context.RouteData.Values["callback"] as string) ?? request["callback"];
            //respons
            if (!string.IsNullOrEmpty(jsoncallback))
            {
                if (string.IsNullOrEmpty(base.ContentType))
                {
                    base.ContentType = "application/x-javascript";
                }
                response.Write(string.Format("{0}(", jsoncallback));
            }
            base.MaxJsonLength = int.MaxValue;
            base.ExecuteResult(context);
            if (!string.IsNullOrEmpty(jsoncallback))
            {
                response.Write(");");
            }
        }
    }

    //extension methods for the controller to allow jsonp.
    public static class JsonpExtensions
    {
        public static JsonpResult Jsonp(this Controller controller, object data)
        {
            var result = new JsonpResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
            result.ExecuteResult(controller.ControllerContext);
            return result;
        }
    }
}