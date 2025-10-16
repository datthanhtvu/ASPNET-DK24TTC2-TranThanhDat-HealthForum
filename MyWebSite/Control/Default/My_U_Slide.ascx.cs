using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
namespace MyWebSite.Control.Default
{
    public partial class My_U_Slide : System.Web.UI.UserControl
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
            string Chuoi="";
   
            
            List<Data.News> list = new List<Data.News>();
            list = Business.NewsService.News_GetByTop("6"," Active=1","[Date] desc");
            for (int i = 0; i < list.Count; i++)
            { 
            string nameshow=Common.StringClass.CatChuoi(list[i].Name,100) ;
            string contentshow=Common.StringClass.CatChuoi(list[i].Content,250) ;
             Chuoi+= " <div style=\"display: block; z-index: 2; visibility: visible;\" class=\"contentdiv\">";
            Chuoi+= " <div class=\"cat_image\">";
          Chuoi+= "<div class=\"imagesmain\">";
          Chuoi += " <div class=\"images\"> <a href=\"Tin-moi/" + list[i].Tag + ".htm\"> ";
           Chuoi += " <img  alt=\"" + list[i].Title + "\" src=\" "+list[i].Image+"\" /> </a>";
           Chuoi+="</div>";    
            Chuoi+=" </div>";
            Chuoi+="<div class=\"sliderPostInfo\">";
              Chuoi+=" <h2 class=\"feaSliderTitle\">";
              Chuoi += "<a rel=\"bookmark\" href=\"Tin-moi/" + list[i].Tag + ".htm\">" + nameshow + "</a>";
                Chuoi+=" </h2>";
                Chuoi+=" </div>";
                  Chuoi+=" </div>";
                 Chuoi+="  <div style=\"clear: both\"></div>";
                 Chuoi+="<div class=\"featuredPost lastPost\">";
                     Chuoi+=" <p style=\"vertical-align:bottom\">"+contentshow+"</p>";
                     Chuoi += "</div> </div> "; 
            }
            list.Clear();
            list = null;
            ltView.Text = Chuoi;
        }
    }
}