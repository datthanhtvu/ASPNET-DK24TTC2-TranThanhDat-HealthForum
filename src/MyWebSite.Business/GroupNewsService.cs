using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
   public class GroupNewsService
    {
       private static GroupNewsDAL db = new GroupNewsDAL();
       
       public static List<GroupNews> News_GetName_GroupNews(string Tag)
       {
           return db.GroupNews_GetByNewsTag(Tag);
       }
       #region[GetByTop]
       public static List<GroupNews> GroupNews_GetByTop(string Top, string Where, string Order)
       {
           return db.GroupNews_GetByTop(Top, Where, Order);
       }
       #endregion
       #region[GetById]
       public static List<GroupNews> GroupNews_GetById(string Id)
       {
           return db.GroupNews_GetById(Id);
       }
       #endregion
       #region[Insert]
       public static bool GroupNews_Insert(GroupNews data)
       {
           return db.GroupNews_Insert(data);
       }
       #endregion
       #region[Update]
       public static bool GroupNews_Update(GroupNews data)
       {
           return db.GroupNews_Update(data);
       }
       #endregion
       #region[Delete]
       public static bool GroupNews_Delete(string Id)
       {
           return db.GroupNews_Delete(Id);
       }
       #endregion
       #region[GroupNews_Update_Ord]
       public static bool GroupNews_Update_Ord(GroupNews data)
       {
           return db.GroupNews_Update_Ord(data);
       }
       #endregion
    }
}
