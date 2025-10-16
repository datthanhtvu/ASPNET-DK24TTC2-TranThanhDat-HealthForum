using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
  public  class MenuService
    {
      private static MenuDAL db = new MenuDAL();
        #region[GetByTop]
      public static List<Menu> Menu_GetByTop(string Top, string Where, string Order)
      {
          return db.Menu_GetByTop(Top,Where,Order);
      }
        #endregion
        #region[GetById]
      public static List<Menu> Menu_GetById(string Id)
      {
          return db.Menu_GetById(Id);
      }
        #endregion
        #region[Insert]
      public static bool Menu_Insert(Menu data)
      {
          return db.Menu_Insert(data);
      }
              #endregion
        #region[Update]
      public static bool Menu_Update(Menu data)
      {
          return db.Menu_Update(data);
      }
#endregion
        #region[Delete]
      public static bool Menu_Delete(string Id)
      {
          return db.Menu_Delete(Id);
      }
        #endregion
    }
}
