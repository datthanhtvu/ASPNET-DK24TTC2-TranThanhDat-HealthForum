using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyWebSite.Data;
namespace MyWebSite.Business
{
  public  class RuleService
    {
      private static RuleDAL db = new RuleDAL();


        #region[GetById]
      public static List<Data.Rule> Rule_GetById(string Id)
        {
            return db.Rule_GetById(Id);
        }
        #endregion
        #region[GetByTop]
      public static List<Data.Rule> Rule_GetByTop(string Top, string Where, string Order)
        {
            return db.Rule_GetByTop(Top, Where, Order);
        }
        #endregion
        #region[Insert]
      public static bool Rule_Insert(Data.Rule data)
        {
            return db.Rule_Insert(data);
        }
        #endregion
        #region[pdate]
      public static bool Rule_Update(Data.Rule data)
        {
            return db.Rule_Update(data);
        }
        #endregion
        #region[Delete]
      public static bool Rule_Delete(string Id)
        {
            return db.Rule_Delete(Id);
        }
        #endregion
    }
}
