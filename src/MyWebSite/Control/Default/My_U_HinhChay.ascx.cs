using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_HinhChay : System.Web.UI.UserControl
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
         string ChuoiHTM="";
         List<Data.Advertise> listImg = new List<Data.Advertise>();
         listImg = Business.AdvertiseService.Advertise_GetByTop("10","[Active]=1 and Position=3","Ord");
         for (int i = 0; i < listImg.Count;i++ )
         {
             ChuoiHTM += "<a href=\"http://" + listImg[i].Link + "\" Title=\"" + listImg[i].Name + "\" ><img style=\"height:80px;width:150px\"  alt=\"" + listImg[i].Name + "\" src=\"" + listImg[i].Image + "\" /></a>";
         }
         listImg.Clear();
         listImg = null;
         ltrShowImg.Text = ChuoiHTM;
        }
    }
}