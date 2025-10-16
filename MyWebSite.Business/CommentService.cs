using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
   public class CommentService
    {
       private static CommentDAL db = new CommentDAL();
       #region[GetByTop]
       public static List<Comment> Comment_GetByTop(string Top, string Where, string Order)
       {
           return db.Comment_GetByTop(Top, Where, Order);
       }
       #endregion
       #region[GetById]
       public static List<Comment> Comment_GetById(string Id)
       {
           return db.Comment_GetById(Id);
       }
       #endregion
       #region[Insert]
       public static bool Comment_Insert(Comment data)
       {
           return db.Comment_Insert(data);
       }
       #endregion
       #region[Update]
       public static bool Comment_Update(Comment data)
       {
           return db.Comment_Update(data);
       }
       #endregion
       #region[Delete]
       public static bool Comment_Delete(string Id)
       {
           return db.Comment_Delete(Id);
       }
       #endregion
       #region[Comment_Paging]
       public static List<Data.Comment> Comment_Paging(string CurentPage, string PageSize, string Where, string Order)
       {
           return db.Comment_Paging(CurentPage, PageSize, Where, Order);
       }
       #endregion
    }
}
