using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
  public  class MemberService
    {
      private static MemberDAL db = new MemberDAL();
        #region[GetByTop]
      public static List<Member> Member_GetByTop(string Top, string Where, string Order)
      {
          return db.Member_GetByTop(Top,Where,Order);
      }
        #endregion
        #region[GetById]
      public static List<Member> Member_GetById(string Id)
      {
          return db.Member_GetById(Id);
      }
        #endregion
        #region[Insert]
      public static bool Member_Insert(Member data)
      {
          return db.Member_Insert(data);
      }
        #endregion
        #region[Update]
      public static bool Member_Update(Member data)
      {
          return db.Member_Update(data);
      }
        #endregion
        #region[Delete]
      public static bool Member_Delete(string Id)
      {
          return db.Member_Delete(Id);
      }
        #endregion
    }
}
