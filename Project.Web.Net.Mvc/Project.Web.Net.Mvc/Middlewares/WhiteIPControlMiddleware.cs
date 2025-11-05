//using System.Net;

//namespace Project.Web.Net.Mvc.Middlewares
//{
//    public class WhiteIPControlMiddleware
//    {
//        private readonly RequestDelegate _requestDelegate;

//        private readonly string blackIPAddress = "::1";

//        public WhiteIPControlMiddleware(RequestDelegate requestDelegate)
//        {
//            _requestDelegate = requestDelegate;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var reqIpAdress = context.Connection.RemoteIpAddress;

//            bool AnyWhiteIPAdress=IPAddress.Parse(blackIPAddress).Equals(reqIpAdress);

//            if (!AnyWhiteIPAdress)
//            {
//                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
//                await context.Response.WriteAsync("Access Denied");
//            }
//            else { 
//            await _requestDelegate(context);
//            }
//        }
//    }
//}
