using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
 public   class ContactService
    {
     private static ContactDAL db = new ContactDAL();
        #region[GetByTop]
     public static List<Contact> Contact_GetByTop(string Top, string Where, string Order)
     {
         return db.Contact_GetByTop(Top,Where,Order);
     }
        #endregion
        #region[GetById]
     public static List<Contact> Contact_GetById(string Id)
     {
         return db.Contact_GetById(Id);
     }
        #endregion
        #region[Insert]
     public static bool Contact_Insert(Contact data)
     {
         return db.Contact_Insert(data);
     }
        #endregion
        #region[Update]
     public static bool Contact_Update(Contact data)
     {
         return db.Contact_Update(data);
     }
        #endregion
        #region[Delete]
     public static bool Contact_Delete(string Id)
     {
         return db.Contact_Delete(Id);
     }
        #endregion
    }
}
