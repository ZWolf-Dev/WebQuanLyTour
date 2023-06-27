using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(DuLich.App_Start.Startup))]
namespace DuLich.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Bật CORS(chia sẻ tài nguyền gốc chéo) để thực hiện yêu cầu bàng trình duyệt từ các miền khác nhau
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //Tạo đường dẫn url lấy token
                TokenEndpointPath = new PathString("/token"),
                //Đặt thời gian hết hạn của token
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Khai báo class sẻ sử dụng để xác thực thông tin người dùng
                Provider = new CheckUserApi()
            };
            //Tạo token
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}