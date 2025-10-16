using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_Item_Quangcao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                View();
            }
        }
        void View()
        {
            string Chuoi = "";
            List<Data.Advertise> list = new List<Data.Advertise>();
            list = Business.AdvertiseService.Advertise_GetByTop("10","[Active]=1 and Position=2","Ord");
            for (int i = 0; i < list.Count; i++)
            {
                string duoianh = list[i].Image.Substring(list[i].Image.Count()-3);
                if (duoianh == "jpg" || duoianh == "JPG")
                {
                    Chuoi += "<a href='http://" + list[i].Link + "' target='" + list[i].Target + "' Title=\"" + list[i].Name + "\"> <img src=\"" + list[i].Image + "\"/> </a>";
                }
                if (duoianh == "swf" || duoianh == "SWF")
                {
                    
                    Chuoi += "<a href='http://" + list[i].Link + "' target='" + list[i].Target + "' Title=\"" + list[i].Name + "\"> <embed  height=\"480\" width=\"219\" allowscriptaccess=\"always\" wmode=\"transparent\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" src=\"" + list[i].Image + "\">";
    
                }
            }
            list.Clear();
            list = null;
            ltrViewImage.Text = Chuoi;
        }
    }
}