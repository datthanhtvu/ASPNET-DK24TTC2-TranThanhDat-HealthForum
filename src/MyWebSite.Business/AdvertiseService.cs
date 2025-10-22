using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
   public class AdvertiseService
    {
       private static AdvertiseDAL db = new AdvertiseDAL();
       #region[GetByTop]
       public static List<Advertise> Advertise_GetByTop(string Top, string Where, string Order)
       {
           return db.Advertise_GetByTop(Top, Where, Order);
       }
       #endregion
       #region[GetById]
       public static List<Advertise> Advertise_GetById(string Id)
       {
           return db.Advertise_GetById(Id);
       }
       #endregion
       #region[Insert]
       public static bool Advertise_Insert(Advertise data)
       {
           return db.Advertise_Insert(data);
       }
       #endregion
       #region[Update]
       public static bool Advertise_Update(Advertise data)
       {
           return db.Advertise_Update(data);
       }
       #endregion
       #region[Delete]
       public static bool Advertise_Delete(string Id)
       {
           return db.Advertise_Delete(Id);
       }
       #endregion
    }
}
