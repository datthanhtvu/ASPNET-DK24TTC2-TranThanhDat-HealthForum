using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
   public class LanguageService
    {
       private static LanguageDAL db = new LanguageDAL();
        #region[GetByTop]
       public static List<Language> Language_GetByTop(string Top, string Where, string Order)
       {
           return db.Language_GetByTop(Top,Where,Order);
       }
        #endregion
        #region[GetById]
       public static List<Language> Language_GetById(string Id)
       {
           return db.Language_GetById(Id);
       }

        #endregion
        #region[Insert]
       public static bool Language_Insert(Language data)
       {
           return db.Language_Insert(data);
       }
        #endregion
        #region[Update]
       public static bool Language_Update(Language data)
       {
           return db.Language_Update(data);
       }
        #endregion
        #region[Delete]
       public static bool Language_Delete(string Id)
       {
           return db.Language_Delete(Id);
       }
        #endregion
    }
}
