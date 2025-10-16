using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_Menu : System.Web.UI.UserControl
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
            string Chuoisub = "";
            List<Data.Menu> list = new List<Data.Menu>();
            List<Data.Menu> listsub = new List<Data.Menu>();
            list = Business.MenuService.Menu_GetByTop("50", "len([Level])=5 and [Active]=1 and [Index]=1", "[Level]");
            for (int i = 0; i < list.Count; i++)
            {
                listsub = Business.MenuService.Menu_GetByTop("50", "left([Level],len('" + list[i].Level + "'))=" + list[i].Level + " and len([Level])>len('" + list[i].Level + "')", "[Level]");
                if (listsub.Count > 0)
                {
                    Chuoi += "<li><a href=\"" + list[i].Link + "\" rel=\"ddsubmenu" + (i + 1) + "\"title =\""+list[i].Title+"\" >" + list[i].Name + "</a></li>";
                    Chuoisub += "<ul id=\"ddsubmenu" + (i + 1) + "\" class=\"ddsubmenustyle\">";
                    for (int j = 0; j < listsub.Count; j++)
                    {
                        Chuoisub += "<li><a href=\"" + listsub[j].Link + "\">" + listsub[j].Name + "</a></li>";
                    }
                    Chuoisub += "</ul>";
                }
                else
                {
                    Chuoi += "<li><a href=\"" + list[i].Link + "\">" + list[i].Name + "</a></li>";
                }
                listsub.Clear();
                listsub = null;
            }
            list.Clear();
            list = null;
            ltrMain.Text = Chuoi;
            ltrSub.Text = Chuoisub;
        }
    }
}