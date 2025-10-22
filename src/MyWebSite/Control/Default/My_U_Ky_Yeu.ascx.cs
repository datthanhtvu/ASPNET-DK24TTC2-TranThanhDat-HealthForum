using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_Ky_Yeu : System.Web.UI.UserControl
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
            string Chuoihtm = "";
            List<Data.Advertise> listAdleft = new List<Data.Advertise>();
            listAdleft = Business.AdvertiseService.Advertise_GetByTop("5", "[Active]=1 and Position=4", "Ord");
            for (int i = 0; i < listAdleft.Count; i++)
            {
                Chuoihtm += "<a href=\"http://" + listAdleft[i].Link + "\" Title=\"" + listAdleft[i].Name + "\"> <img src=\"" + listAdleft[i].Image + "\"/></a> ";
            }
            listAdleft.Clear();
            listAdleft = null;
            ltrADleft.Text = Chuoihtm;
        
        }
    }
}