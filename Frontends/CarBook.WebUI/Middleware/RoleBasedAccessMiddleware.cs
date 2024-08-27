//using Microsoft.AspNetCore.Http;
//using System.Net;
//using System.Threading.Tasks;

//namespace CarBook.WebUI.Middleware
//{
//    public class RoleBasedAccessMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public RoleBasedAccessMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            // Endpointin Admin olup olmadığını kontrol et
//            if (context.Request.Path.StartsWithSegments("/Admin"))
//            {
//                // Kullanıcı rolü kontrolü (örneğin, sadece Admin rolüne izin ver)
//                if (!context.User.IsInRole("Admin"))
//                {
//                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//                    await context.Response.WriteAsync("401 Unauthorized: Admins Only");
//                    return;
//                }
//            }

//            // İstek devam edebilir
//            await _next.Invoke(context);
//        }
//    }
//    public static class RequestCultureMiddlewareExtensions
//    {
//        public static IApplicationBuilder UseRequestCulture(
//            this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<RoleBasedAccessMiddleware>();
//        }
//    }

//}
