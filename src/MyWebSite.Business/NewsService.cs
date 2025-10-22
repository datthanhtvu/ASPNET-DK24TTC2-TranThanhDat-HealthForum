using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;

namespace MyWebSite.Business
{
   public class NewsService
    {
        private static NewsDAL db = new NewsDAL();
        #region[GetByTop]
        public static List<News> News_GetByTop(string Top, string Where, string Order)
        {
            return db.News_GetByTop(Top,Where,Order);
        }
#endregion
               #region[ thống kê]
        public static List<News> News_ThongKe(string Dateform ,string Dateto)
        {
            return db.News_ThongKe(Dateform, Dateto);
        }
        #endregion
        #region[GetUser]
        public static List<News> News_User()
        {
            return db.News_User();
        }
        #endregion
        #region[ GetbyId]
        public static List<News> News_GetById(string Id)
        { 
         return db.News_GetById(Id);
        }
        #endregion
        #region[Insert]
        public static bool News_Insert(News data)
        {
            return db.News_Insert(data);
        }
        #endregion
        #region[Update]
        public static bool News_Update(News data)
        {
            return db.News_Update(data);
        }
      
       
       #endregion
        #region[Update]
        public static bool News_Update_Click(string Tag)
        {
            return db.News_Update_Click(Tag);
        }

        #region[News_Paging]
        public static List<Data.News> News_Paging(string CurentPage, string PageSize, string Where, string Order)
        {
            return db.News_Paging(CurentPage, PageSize, Where, Order);
        }
        #endregion
        #endregion
        #region[Delete]
        public static bool News_Delete(string Id)
        {
            return db.News_Delete(Id);
        }

        #endregion

    }
}
