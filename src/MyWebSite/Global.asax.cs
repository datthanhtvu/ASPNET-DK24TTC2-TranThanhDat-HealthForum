using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
//using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using MyWebSite;
using MyWebSite.Common;
using MyWebSite.Data;
using MyWebSite.Business;

namespace MyWebSite
{
    public class Global : HttpApplication
    {
        public static string LangDefault = "";
        public static CookieClass Cookie = new CookieClass();

        void RegisterRouters(RouteCollection router)
        {
            RouteTable.Routes.MapPageRoute("Tin-hot", "Tin-noi-bat/{Hot}.htm", "~/NewsDetail.aspx");
            RouteTable.Routes.MapPageRoute("tin-moi", "Tin-moi/{New}.htm", "~/NewsDetail.aspx");
            RouteTable.Routes.MapPageRoute("ten-muc-hoi-dap", "Hoi-dap/{Enquiry}.htm", "~/Enquiry.aspx");
            RouteTable.Routes.MapPageRoute("phan-trang-hoi-dap", "Hoi-dap/{Enquiry}.htm/page={currentpage}", "~/Enquiry.aspx");
            RouteTable.Routes.MapPageRoute("detai-hoidap", "Hoi-dap-moi/{DetailHoidap}.htm", "~/EnquiryDetail.aspx");
            RouteTable.Routes.MapPageRoute("Gui-cau-hoi", "Gui-cau-hoi/{EnquiryUp}.htm", "~/EnquiryUp.aspx");
            RouteTable.Routes.MapPageRoute("ten-nhom-tin", "Tin-tuc/{Tag}.htm", "~/Category.aspx");
            RouteTable.Routes.MapPageRoute("phan-trang-tin", "Tin-tuc/{Tag}.htm/page={currentpage}", "~/Category.aspx");
            RouteTable.Routes.MapPageRoute("danh-sach-tin", "Tin-tuc/Tin-moi/{Name}.htm", "~/NewsDetail.aspx");
            //tìm kiếm
            RouteTable.Routes.MapPageRoute("phan-trang-tin-timkiem", "Tin-tuc/{Tagtimkiem}.htm/page={currentpage}", "~/SearchResultNews.aspx");
            RouteTable.Routes.MapPageRoute("phan-trang-hoi-dap-tim-kiem", "Hoi-dap/{Enquirytimkiem}.htm/page={currentpage}", "~/SearchResultNews.aspx");
            
            
            
            //RouteTable.Routes.MapPageRoute("chi-tiet-tin-tuc", "chi-tiet-tin-tuc/{title}.htm", "~/Modules/News/NewsDetail.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            RegisterRouters(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
        public static string GetLang()
        {
            return StringClass.Check(Cookie.GetCookie("Lang")) ? Cookie.GetCookie("Lang") : "";
        }
        public static string GetLangAdm()
        {

            return StringClass.Check(Cookie.GetCookie("LangAdm")) ? Cookie.GetCookie("LangAdm") : "";

        }
    }
}
