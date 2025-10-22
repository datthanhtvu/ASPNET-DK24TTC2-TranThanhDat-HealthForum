using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
   public class ConfigService
    {
       private static ConfigDAL db = new ConfigDAL();
       #region[GetByTop]
       public static List<Config> Config_GetByTop(string Top, string Where, string Order)
       {
           return db.Config_GetByTop(Top, Where, Order);
       }
       #endregion
       #region[GetById]
       public static List<Config> Config_GetById(string Id)
       {
           return db.Config_GetById(Id);
       }
       #endregion
       #region[Insert]
       public static bool Config_Insert(Config data)
       {
           return db.Config_Insert(data);
       }
       #endregion
       #region[Update]
       public static bool Config_Update(Config data)
       {
           return db.Config_Update(data);
       }
       #endregion
       #region[Delete]
       public static bool Config_Delete(string Id)
       {
           return db.Config_Delete(Id);
       }
       #endregion
    }
}
