using System;
using System.Web.Mvc;

namespace SocialBirds.CP.CommonCode
{
    public class AnyActionResult : ActionResult
    {
        public Object Data { get; set; }
        public ActionTypeEnum ActionType { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string AuthonticatioID { get; set; }
        public JsonRequestBehavior JsonRequestBehavior { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            //if (this.AuthonticatioID != "ABC")
            //{
            //    context.HttpContext.Response.Write("You are not authorized.");
            //    return;
            //}
            if (this.ActionType == ActionTypeEnum.PList)
            {
                Result res = new Result() { Data = this.Data, StatusCode = this.StatusCode, StatusMessage = this.StatusMessage };
                string str = "Not supported yet!.";//Plist.PlistDocument.CreateDocument(this.Data);
                context.HttpContext.Response.Write(str);
            }
            else if (this.ActionType == ActionTypeEnum.JSON)
            {
                JsonResult result = new JsonResult();
                result.JsonRequestBehavior = this.JsonRequestBehavior;
                Result res = new Result() { Data = this.Data, StatusCode = this.StatusCode, StatusMessage = this.StatusMessage };
                result.Data = res;
                result.ExecuteResult(context);
            }
            else if (this.ActionType == ActionTypeEnum.XML)
            {
                Result res = new Result() { Data = this.Data, StatusCode = this.StatusCode, StatusMessage = this.StatusMessage };
                string str = "Not Supported Yet";//Plist.PlistDocument.CreateDocument(res);
                context.HttpContext.Response.Write(str);
            }
            else if (this.ActionType == ActionTypeEnum.Help)
            {
                context.HttpContext.Response.Write("We Are working on help,,,, please wait.");
            }
        }
    }
    public class Result
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object Data { get; set; }
    }
    public enum ActionTypeEnum
    {
        JSON = 1,
        XML = 3,
        PList = 2,
        Help = 4
    }
}
