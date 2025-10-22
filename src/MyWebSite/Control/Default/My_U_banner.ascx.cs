using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_banner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            View();
        }
        void View()
        {
            List<Data.Advertise> listAD = new List<Data.Advertise>();
            listAD = Business.AdvertiseService.Advertise_GetByTop("1","position=1","Ord ");
            if (listAD.Count > 0)
            {
                ltBanner.Text = "<div class=\"img-head\" style=\" background-image: url('" + listAD[0].Image + "');\"> </div>";
            }
            listAD.Clear();
            listAD = null;
            
        }
    }
}